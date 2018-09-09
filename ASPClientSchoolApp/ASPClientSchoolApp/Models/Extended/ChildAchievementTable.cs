using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPClientSchoolApp.Models
{
    [MetadataType(typeof(ChildAchievementTableMetadata))]
    public partial class ChildAchievementTable
    {
    }

    public class ChildAchievementTableMetadata
    {
        [DisplayName("Student Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Student Name is Required")]
        public string StudentToken { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "MCD is Required")]
        public string MCD { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Detail is Required")]
        public string Detail { get; set; }
    }

}