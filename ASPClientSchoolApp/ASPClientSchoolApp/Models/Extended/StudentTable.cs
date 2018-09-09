using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPClientSchoolApp.Models
{
    [MetadataType(typeof(StudentTableMetadata))]
    public partial class StudentTable
    {
        //to work with file
        //this property is not inside our table so NotMapped property is added
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        [DisplayName("Image")]
        public string ImagePath { get; set; }

        public StudentTable()
        {
            ImagePath = "~/AppFiles/Images/Default/default.png";
        }
    }
    public class StudentTableMetadata
    {
        [DisplayName("Grade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Grade is Required")]
        public string GradeToken { get; set; }
        [DisplayName("Parent Name")]
        public string ParentToken { get; set; }
        [DisplayName("Image")]
        public string ImageToken { get; set; }
        [DisplayName("Student Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Student Name is Required")]
        public string StudentName { get; set; }
    }
}