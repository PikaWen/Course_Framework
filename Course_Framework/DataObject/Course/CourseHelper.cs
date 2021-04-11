using Course_Framework.Models;
using Course_Framework.Models.DB;

using System;
using System.Linq;

namespace Course_Framework.DataObject.Course
{
    public class CourseHelper
    {
        private CourseDbContext _context = new CourseDbContext();
        public IQueryable<BS_Course> GetAllCourse()
        {
            try
            {
                return _context.BS_Course;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertCourse(BS_Course data)
        {
            try
            {
                _context.BS_Course.Add(data);
                _context.SaveChanges();
                data.CourseID = $"C" + data.CourseNo.ToString().PadLeft(3, '0');

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateCourse(BS_Course data, int No = 0)
        {
            try
            {
                BS_Course bS_Course = _context.BS_Course.FirstOrDefault(m => m.CourseNo == No);
                if (bS_Course == null || bS_Course.CourseNo == 0)
                {
                    return false;
                }

                bS_Course.Address = string.IsNullOrEmpty(data.Address) ? "" : data.Address;
                bS_Course.Credits = data.Credits;
                bS_Course.Name = string.IsNullOrEmpty(data.Name) ? "" : data.Name;
                bS_Course.TeacherName = string.IsNullOrEmpty(data.TeacherName) ? "" : data.TeacherName;

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteCourse(int No = 0)
        {
            try
            {
                BS_Course bS_Course = _context.BS_Course.FirstOrDefault(m => m.CourseNo == No);
                if (bS_Course == null || bS_Course.CourseNo == 0)
                {
                    return false;
                }

                bS_Course.Active = false;

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}