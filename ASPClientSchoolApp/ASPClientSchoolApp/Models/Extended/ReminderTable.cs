using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPClientSchoolApp.Models
{
    [MetadataType(typeof(ReminderTableMetadata))]
    public partial class ReminderTable
    {
    }

    public class ReminderTableMetadata
    {
        [DisplayName("Event Type")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Event Type is Required")]
        public string EventTypeToken { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Detail is Required")]
        public string Detail { get; set; }
        public string MCD { get; set; }
    }


}