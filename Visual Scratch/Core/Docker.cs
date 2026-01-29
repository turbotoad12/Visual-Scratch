using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Visual_Scratch.Core
{
    public class Docker
    {
        // Example build command:
        // docker build -f docker/Dockerfile.3ds --target exporter -o . .

        /// <summary>
        /// Determines whether the Docker daemon is currently running and accessible on the local machine.
        /// </summary>
        /// <remarks>This method checks Docker availability by attempting to execute the 'docker info'
        /// command. It does not verify the presence of specific containers or images, only that the Docker service is
        /// operational and reachable from the current environment.</remarks>
        /// <returns>true if Docker is running and responding to commands; otherwise, false.</returns>
        public static bool DockerRunning()
        {
            // Check if Docker is running by trying to get the list of containers
            try
            {
                var processInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "docker",
                    Arguments = "info",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using (var process = System.Diagnostics.Process.Start(processInfo))
                {
                    process.WaitForExit();
                    return process.ExitCode == 0;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets or sets the file system path to the Dockerfile used for building container images.
        /// </summary>
        public class DockerFile
        {
            /// <summary>
            /// Gets or sets the file system path associated with this instance.
            /// </summary>
            public string Path { get; set; }
        }
        /// <summary>
        /// Represents a single command-line argument for a Docker command, consisting of a name and a value.
        /// </summary>
        public class DockerArgument
        {
            /// <summary>
            /// Gets the name associated with the current instance.
            /// </summary>
            public string Name { get; }
            /// <summary>
            /// Gets the value represented by this instance.
            /// </summary>
            public string Value { get; }

            /// <summary>
            /// Returns a string that represents the current command-line option in the format "--Name=Value".
            /// </summary>
            /// <returns>A string containing the option name and value formatted as "--Name=Value".</returns>
            public override string ToString()
            {
                return String.Format("--{0}={1}", Name, Value);
            }

            // Constructer
            public DockerArgument(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }
        /// <summary>
        /// Represents the set of options used to configure a Docker image build operation.
        /// </summary>
        /// <remarks>Use this class to specify the Dockerfile, input and output paths, and any additional
        /// build arguments when initiating a Docker build process. The options provided determine how the Docker image
        /// is constructed and where build artifacts are read from and written to.</remarks>
        public class DockerBuildOptions
        {
            /// <summary>
            /// Gets or sets the Dockerfile associated with the build configuration.
            /// </summary>
            public DockerFile Dockerfile { get; set; }
            /// <summary>
            /// Gets or sets the file system path to the input file or directory.
            /// </summary>
            public string InputPath { get; set; }
            /// <summary>
            /// Gets or sets the file system path where output files are written.
            /// </summary>
            public string OutputPath { get; set; }
            /// <summary>
            /// Gets or sets the collection of arguments to be passed to the Docker command.
            /// </summary>
            /// <remarks>The collection is initialized with a default argument targeting the exporter.
            /// Additional arguments can be added or removed as needed to customize the Docker command
            /// invocation.</remarks>
            public List<DockerArgument> Arguments { get; set; } = new() { new("target", "exporter"), new("progress", "plain") }; // Adds one default argument, --target exporter.

            /// <summary>
            /// Optional progress reporter for standard output lines from Docker.
            /// </summary>
            public IProgress<string> OutputProgress { get; set; }

            /// <summary>
            /// Optional progress reporter for error output lines from Docker.
            /// </summary>
            public IProgress<string> ErrorProgress { get; set; }
        }
        /// <summary>
        /// Builds a Docker image using the specified build options and reports progress and errors asynchronously.
        /// </summary>
        /// <remarks>This method starts a Docker build process using the provided options and streams
        /// output and error messages to the specified progress reporters. If the cancellation token is triggered, the
        /// Docker process is terminated and the task is canceled. Ensure that Docker is installed and available on the
        /// system path before calling this method.</remarks>
        /// <param name="dockerBuildOptions">The options to use for the Docker build operation, including input and output paths, Dockerfile location,
        /// and additional build arguments. Cannot be null.</param>
        /// <param name="output">An optional progress reporter that receives standard output lines from the Docker build process. May be null
        /// if output reporting is not required.</param>
        /// <param name="error">An optional progress reporter that receives standard error lines from the Docker build process. May be null
        /// if error reporting is not required.</param>
        /// <param name="token">A cancellation token that can be used to cancel the Docker build operation.</param>
        /// <returns>A task that represents the asynchronous Docker build operation. The task completes when the build process
        /// finishes or is canceled.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the Docker build process exits with a non-zero exit code.</exception>
        static public async Task RunDocker(
            DockerBuildOptions dockerBuildOptions,
            IProgress<string> output = null,
            IProgress<string> error = null,
            CancellationToken token = default)
        {
            token.ThrowIfCancellationRequested();

            output ??= dockerBuildOptions?.OutputProgress;
            error ??= dockerBuildOptions?.ErrorProgress;

            var args = new StringBuilder();
            args.Append("build ");
            if (dockerBuildOptions.Dockerfile != null && !string.IsNullOrEmpty(dockerBuildOptions.Dockerfile.Path))
            {
                args.Append($"-f \"{dockerBuildOptions.Dockerfile.Path}\" ");
            }
            if (dockerBuildOptions.Arguments != null && dockerBuildOptions.Arguments.Any())
            {
                foreach (var arg in dockerBuildOptions.Arguments)
                {
                    args.Append($"{arg} ");
                }
            }
            if (!string.IsNullOrEmpty(dockerBuildOptions.OutputPath))
            {
                args.Append($"-o \"{dockerBuildOptions.OutputPath}\" ");
            }
            args.Append($"."); // This is for Input and Output Paths.

            var inputPath = dockerBuildOptions.InputPath;

            var psi = new ProcessStartInfo
            {
                FileName = "docker",
                Arguments = args.ToString().Trim(),
                WorkingDirectory = inputPath,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            StringBuilder sterr = new();
            using (var process = new Process { StartInfo = psi, EnableRaisingEvents = true })
            {
                var tcs = new TaskCompletionSource<int>();

                process.OutputDataReceived += (_, e) =>
                {
                    if (e.Data == null) return;
                    output?.Report(e.Data);
                    // Optional: parse progress here if Docker output has percentages.
                    // Otherwise just leave it or append to a log.
                };

                process.ErrorDataReceived += (_, e) =>
                {
                    if (e.Data == null) return;
                    error?.Report(e.Data);
                    // Log or surface errors.
                    sterr.AppendLine(e.Data);
                };

                process.Exited += (_, __) => tcs.TrySetResult(process.ExitCode);

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                using (token.Register(() =>
                {
                    try { if (!process.HasExited) process.Kill(); } catch { }
                    tcs.TrySetCanceled(token);
                }))
                {
                    var exitCode = await tcs.Task.ConfigureAwait(false);
                    token.ThrowIfCancellationRequested();
                    if (exitCode != 0) throw new InvalidOperationException($"Docker build failed with code {exitCode}.\n{sterr}");
                }
            }
        }
    }
}
