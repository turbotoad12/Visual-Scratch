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
        // Helps evolve the format later
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

        public static Project CreateProject(string path, string name, string author, string description)
        {

            Project project = new Project()
            {
                Sb3Path = Path.Combine(path, "game.sb3"),
                Info = new Metadata
                {
                    Name = name,
                    Author = author,
                    Description = description
                }
            };
            // Create Project stuffs here
            Directory.CreateDirectory(path);
            //TODO: Add the template sb3 file
            // Copy from the Visual Studio Commen Data folder
            using (var data = File.ReadAllBytes(Path.Combine("C:/Program Files (x86)/Common Files/Visual Scratch", "template - empty.sb3")))
            {
                File.WriteAllBytes(project.Sb3Path, data);
            }
            // Save the project file
            project.SaveToFile(Path.Combine(path, name + ".vsproj"));
            return project;
        }
    }
    
}