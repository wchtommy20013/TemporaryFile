using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemporaryFile {
    public class InvalidFilePrefixException : Exception {

        public InvalidFilePrefixException(string fname) : base("檔案名稱存在不適用的字符: [" + fname + "]") { }

    }
}
