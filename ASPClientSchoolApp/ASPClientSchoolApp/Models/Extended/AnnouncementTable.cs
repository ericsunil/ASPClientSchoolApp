using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPClientSchoolApp.Models
{
    [MetadataType(typeof(AnnouncementTableMetadata))]
    public partial class AnnouncementTable
    {
    }

    public class AnnouncementTableMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "MCD is Required")]
        public string MCD { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is Required")]
        public string Title { get; set; }
    }
}