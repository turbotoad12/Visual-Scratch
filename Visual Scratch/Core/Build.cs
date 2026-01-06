using System;
using System.Collections.Generic;

namespace Visual_Scratch.Core.Build
{
    public class Build
    {
        Project projectBuild = null;
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

        private string GetBuildCommand(BuildTarget buildTarget, string outputPath, string inputPath)
        {
            string dockerfilePath = buildTarget switch
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
                _ => throw new ArgumentOutOfRangeException(nameof(buildTarget), "Unsupported build target.")
            };

            return $"build -f {dockerfilePath} --target exporter -o \"{outputPath}\" \"{inputPath}\"";
        }

        public void BuildProject(string outputPath, BuildTarget target)
        {
            if (!DockerRunning())
            {
                throw new Exception("Docker is not running.");
            }
            switch (target)
            {
                case BuildTarget.NDS:
                    throw new NotImplementedException("NDS build functionality is not yet implemented.");

                case BuildTarget._3DS:
                    // Get Build Command
                    var BuildCommand = 
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
