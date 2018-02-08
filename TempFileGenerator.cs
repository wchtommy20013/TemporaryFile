using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace TemporaryFile {
    public class TempFileGenerator {
        private static char[] INVALID_CHARACTER_IN_FILE = new char[] { '\\', '/', ':', '*', '?', '\"', '<', '>', '|' };

        private static IList<TempFile> files = new List<TempFile>();
        #region Create TempFile
        public static TempFile CreateTempFile() {
            try {
                TempFile f = new TempFile();
                files.Add(f);
                return f;
            } catch {
                throw;
            }
        }
        public static TempFile CreateTempFile(FileExtension extension) {
            try {
                TempFile f = new TempFile(extension);
                files.Add(f);
                return f;
            } catch {
                throw;
            }
        }
        public static TempFile CreateTempFile(byte[] b) {
            try {
                TempFile f = new TempFile(b);
                files.Add(f);
                return f;
            } catch {
                throw;
            }
        }
        public static TempFile CreateTempFile(byte[] b, FileExtension extension) {
            try {
                TempFile f = new TempFile(b, extension);
                files.Add(f);
                return f;
            } catch {
                throw;
            }
        }
        public static TempFile CreateTempFile(Stream s) {
            try {
                TempFile f = new TempFile(s);
                files.Add(f);
                return f;
            } catch {
                throw;
            }
        }
        public static TempFile CreateTempFile(Stream s, FileExtension extension) {
            try {
                TempFile f = new TempFile(s, extension);
                files.Add(f);
                return f;
            } catch {
                throw;
            }
        }
        #endregion


        public static void SetTempFilePrefix(string prefix) {
            foreach(var c in prefix) {
                if (c <= 31 || INVALID_CHARACTER_IN_FILE.Contains(c)) throw new InvalidFilePrefixException(prefix);
            }
            TempFile.FILE_PREFIX = prefix;
        }

        public static void Dispose() {
            foreach(var f in files) {
                f.Dispose();
            }
            files.Clear();
        }
    }
}
