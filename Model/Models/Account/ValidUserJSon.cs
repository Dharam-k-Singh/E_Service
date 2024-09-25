using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Account
{
    public class ValidUserJSon
    {
        public Alogritham algo { get; set; }
        public Data details { get; set; }
    }

    public class Alogritham
    {
        public string alg { get; set; }
        public string typ { get; set; }
    }

    public class Data
    {
        public string unique_name { get; set; }
        public string email { get; set; }
        public string nbf { get; set; }
        public string exp { get; set; }
        public string iat { get; set; }
    }
}
