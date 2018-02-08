using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemporaryFile {
    public class FileExtension {
        string extension;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <exception cref="InvalidFileExtensionException">Caught when the input extension is incorrect in Format</exception>
        public FileExtension(string s) {
            s = s.ToLower();
            int count = s.Count(x => x == '.');
            if (count == 1) this.extension = s;
            else if (count == 0) this.extension = "." + s;
            else throw new InvalidFileExtensionException(s);
        }

        public static implicit operator string(FileExtension ex) {
            return ex.ToString();
        }

        public static implicit operator FileExtension(string s) {
            return new FileExtension(s);
        }

        public static FileExtension[] InitializeCompareGroup(params string[] arr) {
            try {
                IList<FileExtension> l = new List<FileExtension>();
                foreach (var s in arr) {
                    l.Add(s);
                }
                return l.ToArray();
            } catch (InvalidFileExtensionException) {
                throw;
            }
        }

        public override bool Equals(object obj) {
            return extension == obj.ToString();
        }

        public override string ToString() {
            return extension;
        }
    }
}
