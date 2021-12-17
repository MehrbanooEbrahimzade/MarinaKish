using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class File
    {
        public File(string fileName, string filePath)
        {
            Id = Guid.NewGuid();
            
            Name = fileName;
            
            FilePath = filePath;
            
            PlaceDate = DateTime.Now;
            
        }

        private File() { }

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
        public string Size { get; set; }

        /// <summary>
        /// زمان اضافه شدن
        /// </summary>
        public DateTime PlaceDate { get; private set; }

    }
}
