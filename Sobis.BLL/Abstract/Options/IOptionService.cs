using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.BLL.Abstract.Options
{
    public interface IOptionService
    {
        string Read(string section, string key, string Path);
        long Write(string section, string key, string value, string Path);
    }
}
