using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Framework.Models.DB
{
    public class SE_Student
    {
        public SE_Student()
        {
            Birth = DateTime.Now;
        }


        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentNo { get; set; }

        [Required]
        [StringLength(5)]
        public String StudentID { get; set; }

        [Required]
        [StringLength(20)]
        public String Name { get; set; }

        [DefaultValue("1990/01/01")]
        public DateTime Birth { get; set; }

        [StringLength(50)]
        public String Email { get; set; }

        [DefaultValue(1)]
        public bool Active { get; set; }

        public virtual ICollection<BS_Enrollment> Enrollments { get; set; }
    }
}