using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPClientSchoolApp.Models
{
    [MetadataType(typeof(GradeMetadata))]
    public partial class Grade
    {
    }
    public class GradeMetadata
    {
        [DisplayName("Class Name in Alphabet")]
        public string ClassAlpha { get; set; }
        [DisplayName("Class Name in Roman")]
        public string ClassRoman { get; set; }
        
        [DisplayName("Class Name in Numeric")]
        public Nullable<int> ClassNumeric { get; set; }

    }
}