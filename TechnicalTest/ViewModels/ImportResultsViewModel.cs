using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechnicalTest.ViewModels
{
    public class ImportResultsViewModel
    {
        [Required(ErrorMessage = "Please select a file")]
        [DataType(DataType.Upload)]

        [Display(Name = "Please select a CSV file")]
        public HttpPostedFileBase File { get; set; }

        public FileUploadResponse Response { get; set; }
    }
}