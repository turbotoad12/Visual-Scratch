using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Visual_Scratch.Core
{
    public class SE
    {
        private static readonly HashSet<string> InvalidTags = new(StringComparer.OrdinalIgnoreCase)
        {
            "0.34",
            "0.33"
        };

        static public string GetSEPath() =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
            "Visual Scratch", "scratch-windows.exe");

        static public Uri ScratchEverywhereUri =>
            new Uri("https://github.com/ScratchEverywhere/ScratchEverywhere");

        /// <summary>
        /// Downloads the source code ZIP from the main branch (avoids broken release tags).
        /// </summary>
        static public async Task<string> DownloadSEZip(string folderDestination)
        {
            const string branch = "main";

            string fileName = $"{branch}.zip";
            string outputPath = Path.Combine(folderDestination, fileName);

            string zipUrl =
                $"https://github.com/ScratchEverywhere/ScratchEverywhere/archive/refs/heads/{branch}.zip";

            using (var client = new WebClient())
                await client.DownloadFileTaskAsync(zipUrl, outputPath);

            return outputPath; // <-- this is the final filename you can unzip
        }


        /// <summary>
        /// Finds the latest non-invalid release tag.
        /// </summary>
        private static async Task<string> GetLatestValidTag()
        {
            // Use GitHub releases API to fetch recent tags and skip any marked invalid
            var request = (HttpWebRequest)WebRequest.Create(
                "https://api.github.com/repos/ScratchEverywhere/ScratchEverywhere/releases?per_page=10");
            request.Method = "GET";
            request.UserAgent = "VisualScratch";
            request.Accept = "application/vnd.github+json";

            try
            {
                using (var response = (HttpWebResponse)await request.GetResponseAsync())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = await reader.ReadToEndAsync();
                    var tags = ExtractTags(content);

                    foreach (var tag in tags)
                    {
                        if (!InvalidTags.Contains(tag))
                            return tag;
                    }

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        private static IEnumerable<string> ExtractTags(string json)
        {
            int idx = 0;
            while (idx >= 0 && idx < json.Length)
            {
                idx = json.IndexOf("\"tag_name\":\"", idx, StringComparison.OrdinalIgnoreCase);
                if (idx < 0) yield break;

                idx += "\"tag_name\":\"".Length;
                int start = idx;
                int end = json.IndexOf('"', start);
                if (end < 0) yield break;

                yield return json.Substring(start, end - start);
                idx = end + 1;
            }
        }

        static public void LaunchSb3(string sb3FilePath)
        {
            var sePath = GetSEPath();
            if (!File.Exists(sePath))
                throw new FileNotFoundException("Visual Scratch executable not found.", sePath);

            if (!File.Exists(sb3FilePath))
                throw new FileNotFoundException("SB3 file not found.", sb3FilePath);

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
