using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemporaryFile {
    public class FileExtensionGroup {
        private IList<FileExtension> list;

        public FileExtensionGroup(params string[] arr) {
            try {
                list = new List<FileExtension>();
                foreach (var s in arr) {
                    list.Add(new FileExtension(s));
                }
            } catch (InvalidFileExtensionException) {
                throw;
            }
        }


        public bool Match(string extension) {
            try {
                FileExtension ext = new FileExtension(extension);
                return list.Any(x => x.Equals(ext));
            } catch {
                throw;
            }
        }
        public bool Match(FileExtension ext) {
            return list.Any(x => x.Equals(ext));
        }
    }
}
