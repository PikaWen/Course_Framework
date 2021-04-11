using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Framework.Models.DB
{
    public class BS_Course
    {
        /// <summary>
        /// 流水號
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CourseNo { get; set; }

        /// <summary>
        /// 課號
        /// </summary>
        [Required]
        [StringLength(4)]
        public String CourseID { get; set; }

        /// <summary>
        /// 課程名字
        /// </summary>
        [Required]
        [StringLength(20)]
        public String Name { get; set; }

        /// <summary>
        /// 學分
        /// </summary>
        public int Credits { get; set; }

        /// <summary>
        /// 上課地點
        /// </summary>
        [Required]
        [StringLength(20)]
        public String Address { get; set; }

        /// <summary>
        /// 講師名字
        /// </summary>
        [Required]
        [StringLength(20)]
        public String TeacherName { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        [Required]
        [DefaultValue(1)]
        public bool Active { get; set; }

        public virtual ICollection<BS_Enrollment> Enrollments { get; set; }
    }
}