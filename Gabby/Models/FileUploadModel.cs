using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gabby.Models
{
    [Table("filesupload")]
    public class FileUploadModel
    {
        [Key]
        public int id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}