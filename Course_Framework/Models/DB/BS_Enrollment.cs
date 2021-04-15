using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Framework.Models.DB
{
    public class BS_Enrollment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int EnrollmentNo { get; set; }

        [Required]
        public int StudentNo { get; set; }

        [Required]
        public int CourseNo { get; set; }

        public virtual SE_Student Student { get; set; }
        public virtual BS_Course Course { get; set; }
    }
}