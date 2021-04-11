using Course_Framework.Models.DB;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Course_Framework.Models
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext() : base("name=CourseDbContext") { }
        public DbSet<SE_Student> SE_Student { get; set; }
        public DbSet<BS_Course> BS_Course { get; set; }
        public DbSet<BS_Enrollment> BS_Enrollment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //var se_student = modelBuilder.Entity<SE_Student>();
            //var bs_course = modelBuilder.Entity<BS_Course>();
            //var bs_enrollment = modelBuilder.Entity<BS_Enrollment>();

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}