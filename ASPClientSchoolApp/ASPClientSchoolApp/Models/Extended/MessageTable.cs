using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPClientSchoolApp.Models
{
    [MetadataType(typeof(MessageTableMetadata))]
    public partial class MessageTable
    {
    }

    public class MessageTableMetadata
    {
        [DisplayName("Messaage From")]
        public string FromToken { get; set; }
        [DisplayName("Message To")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is Required")]
        public string ToToken { get; set; }

    }

}