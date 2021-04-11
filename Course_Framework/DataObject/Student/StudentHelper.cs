using Course_Framework.Models;
using Course_Framework.Models.DB;

using System;
using System.Linq;

namespace Course_Framework.DataObject.Student
{
    public class StudentHelper
    {
        private CourseDbContext _context = new CourseDbContext();
        public IQueryable<SE_Student> GetAllStudent()
        {
            try
            {
                return _context.SE_Student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertStudent(SE_Student data)
        {
            try
            {
                _context.SE_Student.Add(data);
                _context.SaveChanges();
                data.StudentID = $"S" + data.StudentNo.ToString().PadLeft(4, '0');

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateStudent(SE_Student data, int No = 0)
        {
            try
            {
                SE_Student sE_Student = _context.SE_Student.FirstOrDefault(m => m.StudentNo == No);
                if (sE_Student == null || sE_Student.StudentNo == 0)
                {
                    return false;
                }
                DateTime birth = DateTime.Now;
                if (DateTime.TryParse(data.Birth.ToString(), out birth))
                {
                    sE_Student.Birth = birth;
                }
                sE_Student.Name = string.IsNullOrEmpty(data.Name) ? "" : data.Name;
                sE_Student.Email = string.IsNullOrEmpty(data.Email) ? "" : data.Email;

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteStudent(int No = 0)
        {
            try
            {
                SE_Student sE_Student = _context.SE_Student.FirstOrDefault(m => m.StudentNo == No);
                if (sE_Student == null || sE_Student.StudentNo == 0)
                {
                    return false;
                }

                sE_Student.Active = false;

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
