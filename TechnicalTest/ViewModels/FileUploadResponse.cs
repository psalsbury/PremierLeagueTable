using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnicalTest.ViewModels
{
    public class FileUploadResponse
    {
        public string Message { get; set; }

        public FileUploadResponseStatus Status { get; set; }
    }
}