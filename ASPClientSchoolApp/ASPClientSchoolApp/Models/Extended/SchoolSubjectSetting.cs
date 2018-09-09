using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPClientSchoolApp.Models
{
    [MetadataType(typeof(SchoolSubjectSettingMetadata))]
    public partial class SchoolSubjectSetting
    {
    }
    public class SchoolSubjectSettingMetadata
    {
        [DisplayName("School Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "School is Required")]
        public string SchoolToken { get; set; }

        [DisplayName("Subject Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Subject is Required")]
        public string SubjectToken { get; set; }

        [DisplayName("Grade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Grade is Required")]
        public string GradeToken { get; set; }
    }

}