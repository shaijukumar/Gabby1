using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gabby.Models
{
    public class AluMember
    {
        public int AluMemberID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Upload File")]
        public string ImagePath { get; set; }

        [Display(Name="Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        public string Details { get; set; }

        //public HttpPostedFileBase ImageFile { get; set; }
    }
}