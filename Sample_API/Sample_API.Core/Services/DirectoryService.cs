using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_API.Core.Services
{
    public class DirectoryService
    {
        public string WriteNewFile()
        {
            string fileData = Guid.NewGuid().ToString();
            string path = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "files", fileData);
            File.WriteAllText(path, fileData);
            return path;
        }

        public string[] ReadFiles() 
        {
            return Directory.GetFiles(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "files"));
        }
    }
}
