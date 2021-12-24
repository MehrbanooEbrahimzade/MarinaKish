using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MyFile
    {
        public MyFile(string fileName, string filePath, long size)
        {
            Id = Guid.NewGuid();
            Name = fileName;
            FilePath = filePath;
            Size = size;
        }

        private MyFile()
        {

        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// نام فایل
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// مسیر
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// اندازه
        /// </summary>
        public long Size { get; private set; }


    }
}
