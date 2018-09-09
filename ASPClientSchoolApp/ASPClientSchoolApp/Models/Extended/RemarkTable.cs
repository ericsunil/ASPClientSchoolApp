using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPClientSchoolApp.Models
{
    [MetadataType(typeof(RemarkTableMetadata))]
    public partial class RemarkTable
    {
    }
    public class RemarkTableMetadata
    {
        [DisplayName("Student Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Student Name is Required")]
        public string StudentToken { get; set; }

        [DisplayName("Teacher Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Teacher Name is Required")]
        public string TeacherToken { get; set; }

        public string MCD { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is Required")]
        public string Title { get; set; }
    }
}