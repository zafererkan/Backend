using Microsoft.Extensions.Options;
using Sobis.BLL.Abstract.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.BLL.Concrete.Options
{
    public class OptionManager : IOptionService
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public string Default { get; set; }
        public string Read(string section, string key, string Path)
        {
            Default = Default ?? String.Empty;
            StringBuilder StrBuild = new StringBuilder(256);
            GetPrivateProfileString(section, key, Default, StrBuild, 255, Path);
            return StrBuild.ToString();
        }
        public long Write(string section, string key, string value, string Path)
        {
            return WritePrivateProfileString(section, key, value, Path);
        }
    }
}
