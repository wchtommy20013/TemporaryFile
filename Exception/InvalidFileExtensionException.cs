using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemporaryFile {
    public class InvalidFileExtensionException : Exception {
        public InvalidFileExtensionException(string message)
            : base("錯誤的副檔名: " + message) { }
        public InvalidFileExtensionException(string message, System.Exception inner)
            : base(message, inner) { }
    }
}
