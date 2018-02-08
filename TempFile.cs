using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace TemporaryFile {
    public class TempFile : IDisposable {
        public static  string FILE_PREFIX = "";
        string tmp_file_path = "";
        public string FilePath { get { return tmp_file_path; } }

        public TempFile() {
            tmp_file_path = Path.GetTempFileName();
            if(!FILE_PREFIX.Equals("")) File.Move(tmp_file_path, FILE_PREFIX + tmp_file_path);
        }
        /// <summary>
        /// Create a Temporary File
        /// </summary>
        /// <param name="extension"></param>
        /// <exception cref="InvalidFileExtensionException">Thrown when the extension is not valid</exception>
        /// <exception cref="IOException">Thrown when the Path.GetTempFileName() is failed</exception>
        public TempFile(FileExtension extension) {
            try {
                string p = Path.GetTempFileName();
                tmp_file_path = Path.ChangeExtension(p, extension);
                File.Move(p, FILE_PREFIX + tmp_file_path);
            } catch (InvalidFileExtensionException) {
                throw;
            } catch (IOException) {
                throw;
            }
        }

        public TempFile(byte[] b) : this() {
            File.WriteAllBytes(tmp_file_path, b);
        }

        public TempFile(byte[] b, FileExtension extension) : this(extension) {
            File.WriteAllBytes(tmp_file_path, b);
        }
        
        public TempFile(Stream s) : this() {
            _CopyStream(s, tmp_file_path);
        }

        public TempFile(Stream s, FileExtension extension) : this(extension) {
            _CopyStream(s, tmp_file_path);
        }

        private void _CopyStream(Stream stream, string destPath) {
            using (FileStream fs = new FileStream(tmp_file_path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 4096, FileOptions.RandomAccess)) {
                stream.CopyTo(fs);
            }
        }

        public void OpenByDefault() {
            var process = Process.Start(tmp_file_path);
        }

        public void Dispose() {
            if (File.Exists(tmp_file_path)) {
                File.Delete(tmp_file_path);
            }
        }

        public Stream InitStream() {
            return new FileStream(tmp_file_path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 4096, FileOptions.RandomAccess);
        }
    }
}
