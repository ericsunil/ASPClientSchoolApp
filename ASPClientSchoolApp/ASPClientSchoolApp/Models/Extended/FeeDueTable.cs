using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPClientSchoolApp.Models
{
    [MetadataType(typeof(FeeDueTableMetadata))]
    public partial class FeeDueTable
    {
    }
    public class FeeDueTableMetadata
    {
        [DisplayName("Student Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Student Name is Required")]
        public string StudentToken { get; set; }
        public string MCD { get; set; }
        public Nullable<bool> IsCleared { get; set; }
        public string Detail { get; set; }
    }

}