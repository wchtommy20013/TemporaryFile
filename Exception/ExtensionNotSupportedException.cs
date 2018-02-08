using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemporaryFile {
    public class ExtensionNotSupportedException : Exception{

        public ExtensionNotSupportedException(string ext)
        : base("不支援的檔案格式: [" + ext + "]") { }

        public ExtensionNotSupportedException(FileExtension ext)
        : base("不支援的檔案格式: [" + ext.ToString() + "]") { }
    }
}
