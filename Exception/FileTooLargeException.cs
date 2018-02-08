using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemporaryFile {
    public class FileTooLargeException: Exception {
        public FileTooLargeException(string size)
        : base("檔案過大: 超過" +size) { }

        public FileTooLargeException(string message, System.Exception inner)
            : base(message, inner) { }

    }
}
