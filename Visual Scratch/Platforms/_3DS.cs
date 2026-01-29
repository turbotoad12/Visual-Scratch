using System;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Scratch.Platforms
{
    /// <summary>
    /// Provides build and metadata functionality for the Nintendo 3DS platform.
    /// Handles Makefile metadata injection for title, description, and author.
    /// </summary>
    internal class _3DS : IPlatform 
    {
        /// <summary>
        /// Gets or sets the display title used in the generated 3DS build.
        /// This value is written into the Makefile as APP_TITLE.
        /// </summary>
        public string Name => Project.Info.Name;

        /// <summary>
        /// Gets or sets the descriptive text for the 3DS application.
        /// This value is written into the Makefile as APP_DESCRIPTION.
        /// </summary>
        public string Description => Project.Info.Description;

        /// <summary>
        /// Gets or sets the author name associated with the 3DS build.
        /// This value is written into the Makefile as APP_AUTHOR.
        /// </summary>
        public string Author => Project.Info.Author;

        public Core.Project Project { get; set; }

        public Core.Docker.DockerBuildOptions BuildOptions { get; set; }

        /// <summary>
        /// Builds the project for the Nintendo 3DS platform.
        /// Currently not implemented.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// Thrown because the build pipeline has not yet been implemented.
        /// </exception>
        public async Task BuildAsync(IProgress<int> progress, CancellationToken cancellationToken)
        {
            // Check if docker is running
            if (!Core.Docker.DockerRunning())
                throw new InvalidOperationException("Docker is not running. Please start Docker and try again.");

            progress.Report(5);
            
            // Run Prepare()
            await Task.Run(() => Prepare(progress), cancellationToken);

            progress.Report(50);

            // Run DockerBuild()
            await Task.Run(() => DockerBuild(cancellationToken), cancellationToken);
        }

        public async Task Prepare(IProgress<int> progress)
        {
            // Assume we are in the project root directory.
            Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "build", "3DS"));
            progress.Report(10);

            // Store Current Directory to return to later
            string originalDirectory = Environment.CurrentDirectory;
            progress.Report(13);

            // Change to build/3DS directory
            Environment.CurrentDirectory = Path.Combine(originalDirectory, "build", "3DS");
            progress.Report(15);

            // Clone the 3DS Scratch Everywhere exporter repository
            string ZipName = await Core.SE.DownloadSEZip(Environment.CurrentDirectory);
            progress.Report(35);

            // Clean previous contents and unzip to current directory
            CleanDirectory(Environment.CurrentDirectory, ZipName);
            ZipFile.ExtractToDirectory(ZipName, Environment.CurrentDirectory);
            string extractedRoot = null;
            foreach (var dir in Directory.GetDirectories(Environment.CurrentDirectory))
            {
                if (Path.GetFileName(dir).StartsWith("ScratchEverywhere", StringComparison.OrdinalIgnoreCase))
                {
                    extractedRoot = dir;
                    break;
                }
            }

            if (!string.IsNullOrEmpty(extractedRoot))
            {
                foreach (var entry in Directory.EnumerateFileSystemEntries(extractedRoot))
                {
                    string destination = Path.Combine(Environment.CurrentDirectory, Path.GetFileName(entry));

                    if (Directory.Exists(entry))
                    {
                        if (Directory.Exists(destination))
                            Directory.Delete(destination, true);

                        Directory.Move(entry, destination);
                    }
                    else
                    {
                        if (File.Exists(destination))
                            File.Delete(destination);

                        File.Move(entry, destination);
                    }
                }

                Directory.Delete(extractedRoot, true);
            }
            progress.Report(40);

            // Delete the zip file
            File.Delete(ZipName);

            // Update Makefile with metadata
            WriteMakeFile(Path.Combine(Environment.CurrentDirectory, "make", "Makefile_3ds"));
            progress.Report(45);

            // Move game.sb3 to romfs/project.sb3
            Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "romfs"));

            File.Copy(
                Path.Combine(originalDirectory, Project.Sb3Path),
                Path.Combine(Environment.CurrentDirectory, "romfs", "project.sb3"),
                true
            );

            await Task.CompletedTask;
        }

        public async Task DockerBuild(CancellationToken cancellationToken)
        {
            await Core.Docker.RunDocker(
                BuildOptions,
                BuildOptions?.OutputProgress,
                BuildOptions?.ErrorProgress,
                cancellationToken
            );


            await Task.CompletedTask;
        }


        /// <summary>
        /// Updates the Makefile with the current platform metadata values.
        /// Rewrites APP_TITLE, APP_DESCRIPTION, and APP_AUTHOR fields.
        /// </summary>
        /// <exception cref="FileNotFoundException">
        /// Thrown if the Makefile cannot be located.
        /// </exception>
        public void WriteMakeFile(string makefilePath)
        {
            if (!File.Exists(makefilePath))
                throw new FileNotFoundException("Makefile not found.", makefilePath);

            string text = File.ReadAllText(makefilePath);

            text = SetMakeVar(text, "APP_TITLE", Name);
            text = SetMakeVar(text, "APP_DESCRIPTION", Description);
            text = SetMakeVar(text, "APP_AUTHOR", Author);

            File.WriteAllText(makefilePath, text);
        }

        private string SetMakeVar(string content, string variable, string newValue)
        {
            string pattern = $@"^{variable}\s*:?=\s*.*$";
            string replacement = $"{variable} := {newValue}";

            return Regex.Replace(
                content,
                pattern,
                replacement,
                RegexOptions.Multiline
            );
        }

        private static void CleanDirectory(string directory, string fileToPreserve)
        {
            foreach (var file in Directory.GetFiles(directory))
            {
                if (string.Equals(file, fileToPreserve, StringComparison.OrdinalIgnoreCase))
                    continue;

                File.Delete(file);
            }

            foreach (var dir in Directory.GetDirectories(directory))
            {
                Directory.Delete(dir, true);
            }
        }
    }
}
