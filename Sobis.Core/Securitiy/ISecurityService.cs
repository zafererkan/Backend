using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.Core.Securities
{
    public interface ISecurityService
    {
        string Read(string section, string key);
        long Write(string section, string key, string value);
        string Sifrele(string metin);
        string SifreCoz(string sifreliMetin);
        string base64Encode(string data);
        string base64Decode(string data);
    }
}
