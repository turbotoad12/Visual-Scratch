using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTests
{
    [TestClass]
    public class JsonFileTests
    {
        [TestMethod]
        public void Save_ValidProject_CreatesFileAtSpecifiedPath()
        {
            var tempPath = System.IO.Path.GetTempFileName();
            try
            {
                var project = new Visual_Scratch.Core.Project
                {
                    Info = new Visual_Scratch.Core.Project.Metadata
                    {
                        Name = "Test Project",
                        Author = "Unit Test",
                        Description = "This is a test project."
                    }
                };
                Visual_Scratch.Core.JsonFile.Save(tempPath, project);
                Assert.IsTrue(System.IO.File.Exists(tempPath));
            }
            finally
            {
                if (System.IO.File.Exists(tempPath))
                {
                    System.IO.File.Delete(tempPath);
                }
            }
        }
        [TestMethod]
        public void Load()
        {
            var tempPath = System.IO.Path.GetTempFileName();
            try
            {
                var project = new Visual_Scratch.Core.Project
                {
                    Info = new Visual_Scratch.Core.Project.Metadata
                    {
                        Name = "Test Project",
                        Author = "Unit Test",
                        Description = "This is a test project."
                    }
                };
                Visual_Scratch.Core.JsonFile.Save(tempPath, project);
                var loadedProject = Visual_Scratch.Core.JsonFile.Load<Visual_Scratch.Core.Project>(tempPath);
                Assert.IsNotNull(loadedProject);
                Assert.AreEqual("Test Project", loadedProject.Info.Name);
                Assert.AreEqual("Unit Test", loadedProject.Info.Author);
                Assert.AreEqual("This is a test project.", loadedProject.Info.Description);
            }
            finally
            {
                if (System.IO.File.Exists(tempPath))
                {
                    System.IO.File.Delete(tempPath);
                }
            }
        }
    }
    [TestClass]
    public class ProjectTests
    {
        [TestMethod]
        public void LoadFromFile_ValidProjectFile_ReturnsProjectWithCorrectMetadata()
        {
            var tempPath = System.IO.Path.GetTempFileName();
            var project = new Visual_Scratch.Core.Project
            {
                Info = new Visual_Scratch.Core.Project.Metadata
                {
                    Name = "Test Project",
                    Author = "Unit Test",
                    Description = "This is a test project."
                }
            };
            Visual_Scratch.Core.JsonFile.Save(tempPath, project);
            var loadedProject = Visual_Scratch.Core.Project.LoadFromFile(tempPath);
            Assert.IsNotNull(loadedProject);
            Assert.AreEqual("Test Project", loadedProject.Info.Name);
            Assert.AreEqual("Unit Test", loadedProject.Info.Author);
            Assert.AreEqual("This is a test project.", loadedProject.Info.Description);
        }
        [TestMethod]
        public void SaveToFile_ValidProject_SavesCorrectlyAndCanBeReloaded()
        {
            var tempPath = System.IO.Path.GetTempFileName();
            var project = new Visual_Scratch.Core.Project
            {
                Info = new Visual_Scratch.Core.Project.Metadata
                {
                    Name = "Test Project",
                    Author = "Unit Test",
                    Description = "This is a test project."
                }
            };
            project.SaveToFile(tempPath);
            var loadedProject = Visual_Scratch.Core.JsonFile.Load<Visual_Scratch.Core.Project>(tempPath);
            Assert.IsNotNull(loadedProject);
            Assert.AreEqual("Test Project", loadedProject.Info.Name);
            Assert.AreEqual("Unit Test", loadedProject.Info.Author);
            Assert.AreEqual("This is a test project.", loadedProject.Info.Description);
        }
        [TestMethod]
        public override void ToString()
        {
            var project = new Visual_Scratch.Core.Project
            {
                Info = new Visual_Scratch.Core.Project.Metadata
                {
                    Name = "Test Project",
                    Author = "Unit Test",
                    Description = "This is a test project."
                }
            };
            var jsonString = project.ToString();
            var serializedObject = System.Text.Json.JsonSerializer.Serialize(project);
            Assert.AreEqual(serializedObject, jsonString);
        }
        [TestMethod]
        public void CreateProject_ValidParameters_CreatesProjectWithDirectoryAndFile()
        {
            var tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetRandomFileName());
            var project = Visual_Scratch.Core.Project.CreateProject(tempPath, "New Project", "Author Name", "Project Description");
            Assert.IsNotNull(project);
            Assert.AreEqual("New Project", project.Info.Name);
            Assert.AreEqual("Author Name", project.Info.Author);
            Assert.AreEqual("Project Description", project.Info.Description);
            Assert.IsTrue(System.IO.Directory.Exists(tempPath));
            Assert.IsTrue(System.IO.File.Exists(System.IO.Path.Combine(tempPath, "game.sb3")));
        }
    }

}
