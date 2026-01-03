using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Visual_Scratch;
namespace UnitTests
{
    [TestClass]
    public class Scratch_Everywhere_Tests
    {
        [TestMethod]
        public void GetSEPath_ReturnsExpectedPath()
        {
            var expectedPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Visual Scratch", "scratch-windows.exe");
            var actualPath = Visual_Scratch.Core.SE.GetSEPath();
            Assert.AreEqual(expectedPath, actualPath);
        }
    }
}
