using System;
using System.IO;
using System.Text.Json;

namespace Visual_Scratch.Core
{
    public static class JsonFile
    {
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            // AllowTrailingCommas is NOT supported on .NET Framework
        };

        public static void Save<T>(string path, T data)
        {
            try
            {
                var json = JsonSerializer.Serialize(data, Options);
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to save JSON file: {path}", ex);
            }
        }

        public static T Load<T>(string path)
        {
            if (!File.Exists(path))
                return default(T);

            try
            {
                var json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<T>(json, Options);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to load JSON file: {path}", ex);
            }
        }
    }

    public class Project
    {
        // Helps you evolve the format later
        public int Version { get; set; } = 1;

        public Metadata Info { get; set; } = new Metadata();

        public class Metadata
        {
            public string Name { get; set; } = "";
            public string Author { get; set; } = "";
            public string Description { get; set; } = "";
        }

        // Path to the .sb3 file
        public string Sb3Path { get; set; } = "";

        /// <summary>
        /// Loads a project from the specified JSON file.
        /// </summary>
        /// <param name="path">The path to the JSON file containing the project data. The file must exist and be accessible.</param>
        /// <returns>A <see cref="Project"/> instance deserialized from the specified file.</returns>
        public static Project LoadFromFile(string path)
        {
            return JsonFile.Load<Project>(path);
        }
        /// <summary>
        /// Saves the current object to a file in JSON format at the specified path.
        /// </summary>
        /// <param name="path">The file system path where the JSON representation of the object will be saved. Cannot be null or empty.</param>
        public void SaveToFile(string path)
        {
            JsonFile.Save(path, this);
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}