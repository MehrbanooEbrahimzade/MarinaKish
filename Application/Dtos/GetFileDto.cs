using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Application.Dtos
{
    public class GetFileDto
    {
        public FilesDto File { get; set; }
        public MemoryStream Memory { get; set; }
    }
}
