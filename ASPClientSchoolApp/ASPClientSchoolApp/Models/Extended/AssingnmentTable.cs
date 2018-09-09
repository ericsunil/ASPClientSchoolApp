using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPClientSchoolApp.Models
{
    [MetadataType(typeof(AssignmentTableMetadata))]
    public partial class AssignmentTable
    {
    }
    public class AssignmentTableMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "MCD is Required")]
        public string MCD { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is Required")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is Required")]
        public string Description { get; set; }
    }
}