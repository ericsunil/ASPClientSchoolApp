using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPClientSchoolApp.Models
{
    [MetadataType(typeof(PersonnelTableMetadata))]
    public partial class PersonnelTable
    {
        //to work with file
        //this property is not inside our table so NotMapped property is added
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        [DisplayName("Image")]
        public string ImagePath { get; set; }

        public PersonnelTable()
        {
            ImagePath = "~/AppFiles/Images/Default/default.png";
        }
    }
    public class PersonnelTableMetadata
    {
        [DisplayName("Type")]
        public string TypeToken { get; set; }

        [DisplayName("Designation")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Designation is Required")]
        public string DesignationToken { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        public string Position { get; set; }
        [DisplayName("Image")]
        public string ImageToken { get; set; }


        
    }
}