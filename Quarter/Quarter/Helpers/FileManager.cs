﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Helpers
{
    public class FileManager
    {
        public static string Save(string rootPath,string folder,IFormFile file)
        {
            string newFileName = file.FileName;
            newFileName = newFileName.Length>64?newFileName.Substring(newFileName.Length - 64, 64):newFileName;
            newFileName = Guid.NewGuid().ToString() + newFileName;

            string path = Path.Combine(rootPath, folder, newFileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return newFileName;
        }

        public static bool Delete(string rootPath, string folder, string fileName)
        {
            string deletepath = Path.Combine(rootPath, folder, fileName);

            if (File.Exists(deletepath))
            {
                File.Delete(deletepath);
                return true;
            }

            return false;
        }
    }
}
