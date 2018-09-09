using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPClientSchoolApp.Models
{
    [MetadataType(typeof(AttendanceTableMetadata))]
    public partial class AttendanceTable
    {
    }

    public class AttendanceTableMetadata
    {
        [DisplayName("Student Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Student Name is Required")]
        public string StudentToken { get; set; }
    }
}