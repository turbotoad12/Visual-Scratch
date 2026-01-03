using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Visual_Scratch.Core
{
    public class SE
    {
        /// <summary>
        /// Gets the full file system path to the Visual Scratch executable for Windows installations.
        /// </summary>
        /// <remarks>This method constructs the path based on the standard Program Files (x86) location.
        /// The returned path may not exist if Visual Scratch is not installed on the system.</remarks>
        /// <returns>A string containing the absolute path to 'scratch-windows.exe' located in the Program Files (x86) directory.</returns>
        static public string GetSEPath() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Visual Scratch", "scratch-windows.exe");

        static public void LaunchSb3(string sb3FilePath)
        {
            var sePath = GetSEPath();
            if (!File.Exists(sePath))
            {
                throw new FileNotFoundException("Visual Scratch executable not found.", sePath);
            }
            if (!File.Exists(sb3FilePath))
            {
                throw new FileNotFoundException("SB3 file not found.", sb3FilePath);
            }
            var processInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = sePath,
                Arguments = $"\"{sb3FilePath}\"",
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(processInfo);
        }
    }
}
