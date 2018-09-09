using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPClientSchoolApp.Models
{
    [MetadataType(typeof(AboutTableMetadata))]
    public partial class AboutTable
    {

    }

    public class AboutTableMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Introduction is Required")]
        public string Introduction { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Rules is Required")]
        public string Rules { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Facilities is Required")]
        public string Facilities { get; set; }
    }
}