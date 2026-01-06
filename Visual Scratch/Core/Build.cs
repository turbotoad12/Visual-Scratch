using System;
using System.Collections.Generic;
using static Visual_Scratch.Core.Build;

namespace Visual_Scratch.Core
{
    public class Build
    {
        Project projectBuild;
        public static readonly List<string> SupportedPlatforms = new()
        {
            "Nintendo DS",
            "Nintendo 3DS",
            "Nintendo Wii U",
            "Nintendo Wii",
            "Nintendo GameCube",
            "Nintendo Switch",
            "Playstation Vita",
            "Playstation Portable (PSP)",
            "Playstation PS4"
        };
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

        public enum BuildTarget
        {
            NDS,
            _3DS,
            WiiU,
            Wii,
            GameCube,
            Switch,
            Vita,
            PSP,
            PS4
        }
        public class BuildOptions
        {
            public BuildTarget Target { get; set; }
            public string OutputPath { get; set; }
            public string InputPath { get; set; }

            public BuildOptions(BuildTarget target, string outputPath, string inputPath)
            {
                Target = target;
                OutputPath = outputPath;
                InputPath = inputPath;
            }
            /// <summary>
            /// Returns a string containing the Docker build command for the specified build target, input path, and
            /// output path.
            /// </summary>
            /// <remarks>The returned command can be used to invoke Docker for building an exporter
            /// image. Ensure that the Target property is set to a valid build target before calling this
            /// method. This only returns the Arguments, not the entire command.</remarks>
            /// <returns>A formatted string representing the Docker build command. The string includes the appropriate Dockerfile
            /// path based on the build target, as well as the input and output paths.</returns>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if the build target specified by the Target property is not supported.</exception>
            public override string ToString()
            {
                string dockerfilePath = Target switch
                {
                    BuildTarget.NDS => "docker/Dockerfile.nds",
                    BuildTarget._3DS => "docker/Dockerfile.3ds",
                    BuildTarget.WiiU => "docker/Dockerfile.wiiu",
                    BuildTarget.Wii => "docker/Dockerfile.wii",
                    BuildTarget.GameCube => "docker/Dockerfile.gamecube",
                    BuildTarget.Switch => "docker/Dockerfile.switch",
                    BuildTarget.Vita => "docker/Dockerfile.vita",
                    BuildTarget.PSP => "docker/Dockerfile.psp",
                    BuildTarget.PS4 => "docker/Dockerfile.ps4",
                    _ => throw new ArgumentOutOfRangeException(nameof(Target), "Unsupported build target.")
                };
                return String.Format("build -f {0} --target exporter -o \"{1}\" \"{2}\"", dockerfilePath, OutputPath, InputPath);
            }
        }

        public void BuildProject(BuildOptions options)
        {
            if (!DockerRunning())
            {
                throw new Exception("Docker is not running.");
            }
            switch (options.Target)
            {
                case BuildTarget.NDS:
                    throw new NotImplementedException("NDS build functionality is not yet implemented.");

                case BuildTarget._3DS:
                    // Get Build Arguments
                    string BuildArguments = options.ToString();
                    throw new NotImplementedException("3DS build functionality is not yet implemented.");

                case BuildTarget.WiiU:
                    throw new NotImplementedException("WiiU build functionality is not yet implemented.");

                case BuildTarget.Wii:
                    throw new NotImplementedException("Wii build functionality is not yet implemented.");

                case BuildTarget.GameCube:
                    throw new NotImplementedException("GameCube build functionality is not yet implemented.");

                case BuildTarget.Switch:
                    throw new NotImplementedException("Switch build functionality is not yet implemented.");

                case BuildTarget.Vita:
                    throw new NotImplementedException("Vita build functionality is not yet implemented.");

                case BuildTarget.PSP:
                    throw new NotImplementedException("PSP build functionality is not yet implemented.");

                case BuildTarget.PS4:
                    throw new NotImplementedException("PS4 build functionality is not yet implemented.");

                default:
                    throw new ArgumentOutOfRangeException(nameof(target), "Unsupported build target.");
            }
            throw new NotImplementedException("Build functionality is not yet implemented.");
        }
    }
}
