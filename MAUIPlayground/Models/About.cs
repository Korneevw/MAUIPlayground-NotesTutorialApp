using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIPlayground.Models
{
    internal class About
    {
        public string Title => "Notes";
        public int FontSize => 22;
        public string Version => AppInfo.VersionString;
        public string AuthorURL => "https://vk.com/korne9999";
    }
}
