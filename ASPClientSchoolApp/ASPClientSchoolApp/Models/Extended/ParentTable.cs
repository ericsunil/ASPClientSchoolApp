using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPClientSchoolApp.Models
{
    [MetadataType(typeof(ParentTableMetadata))]
    public partial class ParentTable
    {
    }
    public class ParentTableMetadata
    {
        [DisplayName("Entry Token")]
        public string EntryToken { get; set; }
        [DisplayName("Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }
        [DisplayName("Parent Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Parent Name is Required")]
        public string ParentName { get; set; }
    }
}