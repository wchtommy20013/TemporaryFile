using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemporaryFile;
namespace Test {
    [TestClass]
    public class FileExtensionTest {
        [TestMethod]
        public void Extension_With_No_Dot() {
            FileExtension ext = new FileExtension("csv");
            Assert.AreEqual(".csv", ext.ToString());

            ext = "csv";
            Assert.AreEqual(".csv", (string)ext);

        }

        [TestMethod]
        public void Extension_With_One_Dot() {
            FileExtension ext = new FileExtension(".csv");
            Assert.AreEqual(".csv", ext.ToString());

            ext = ".csv";
            Assert.AreEqual(".csv", (string)ext);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFileExtensionException))]
        public void Extension_With_Multiple_Dot() {
            FileExtension ext = new FileExtension(".csv.bak");
        }
    }
}
