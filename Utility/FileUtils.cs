using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class FileUtils
    {
        public static string GetNewFileName(string fileName)
        {
            string[] fileNameSplit = fileName.Split('.');

            return fileNameSplit[0] + "_" + DateTime.Now.ToString("ddd MMM dd yyyy") + "." + fileNameSplit[1];
        }
    }
}
