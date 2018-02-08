using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemporaryFile;
using System.IO;
using System.Collections.Generic;
namespace Test {
    [TestClass]
    public class TempFileTest {
        IList<TempFile> created_files = new List<TempFile>();

        [TestMethod]
        public void CreateFileTest() {
            TempFile file = TempFileGenerator.CreateTempFile();
            created_files.Add(file);
            Assert.AreEqual(File.Exists(file.FilePath), true);
            file.Dispose();
        }

        [TestMethod]
        public void DisposeFileTest() {
            for (int i = 0; i < 10; i++) {
                TempFile file = TempFileGenerator.CreateTempFile();
                created_files.Add(file);
                Assert.AreEqual(File.Exists(file.FilePath), true);
            }

            TempFileGenerator.Dispose();
            foreach (var f in created_files) {
                Assert.AreEqual(File.Exists(f.FilePath), false);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFilePrefixException))]
        public void InvalidFilePrefixTest() {
            TempFileGenerator.SetTempFilePrefix("\\");
        }

    }
}
