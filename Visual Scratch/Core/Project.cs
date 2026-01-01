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
        /// <summary>
        /// Serializes the specified data to JSON and writes it to the file at the given path.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="path">The file path where the JSON data will be saved. Cannot be null or empty.</param>
        /// <param name="data">The object to serialize and save to the file.</param>
        /// <exception cref="InvalidOperationException">Thrown if the data cannot be serialized or the file cannot be written.</exception>
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
        /// <summary>
        /// Loads an object of type T from a JSON file at the specified path.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize from the JSON file.</typeparam>
        /// <param name="path">The file system path to the JSON file to load. Cannot be null or empty.</param>
        /// <returns>An instance of type T deserialized from the JSON file, or the default value of T if the file does not exist.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the file exists but cannot be read or deserialized as type T.</exception>
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
    /// <summary>
    /// Represents a project, including its metadata, file paths, and methods for loading, saving, and creating project
    /// instances.
    /// </summary>
    /// <remarks>The Project class provides functionality to manage project data, including serialization to
    /// and from JSON files, and creation of new projects using a template file. It encapsulates project metadata and
    /// file path information, and offers static and instance methods for common project operations. This class is not
    /// thread-safe; concurrent access to the same instance should be synchronized by the caller if used in
    /// multithreaded scenarios.</remarks>
    public class Project
    {
        // Helps evolve the format later
        public int Version { get; set; } = 1;

        public Metadata Info { get; set; } = new Metadata();
        /// <summary>
        /// Represents descriptive metadata information, including name, author, and description details.
        /// </summary>
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
        /// <summary>
        /// Returns a JSON-formatted string that represents the current object.
        /// </summary>
        /// <remarks>The returned JSON string includes all public properties of the object. This method is
        /// useful for logging, debugging, or serializing the object for transmission. The output format may vary
        /// depending on the object's structure and the default settings of the underlying JSON serializer.</remarks>
        /// <returns>A string containing the JSON representation of the current object.</returns>
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        /// <summary>
        /// Creates a new project in the specified directory using a template file and initializes its metadata.
        /// </summary>
        /// <remarks>The method copies a template project file to the specified directory and sets the
        /// project's metadata. The template file must exist in the application's common data folder. If the target
        /// directory does not exist, it will be created.</remarks>
        /// <param name="path">The directory path where the new project will be created. The directory will be created if it does not
        /// exist.</param>
        /// <param name="name">The name to assign to the new project.</param>
        /// <param name="author">The author of the new project.</param>
        /// <param name="description">A description of the new project.</param>
        /// <returns>A <see cref="Project"/> instance representing the newly created project, with its metadata initialized and
        /// project file copied from the template.</returns>
        /// <exception cref="FileNotFoundException">Thrown if the project template file cannot be found in the expected location.</exception>
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

            File.WriteAllBytes(Path.Combine(project.Sb3Path), Properties.Resources.template_empty_sb3);
            
            return project;
        }
    }
    
}