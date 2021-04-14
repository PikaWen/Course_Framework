using Course_Framework.DataObject.Course;
using Course_Framework.DataObject.Student;
using Course_Framework.Models.DB;

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Course_Framework.Areas.Student.Controllers
{
    public class StudentController : Controller
    {
        private StudentHelper _studentHelper = new StudentHelper();
        private CourseHelper _courseHelper = new CourseHelper();

        // GET: Student/Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentList()
        {
            List<SE_Student> studentList = _studentHelper.GetAllStudent().Where(m => m.Active == true).ToList();
            return View(studentList);
        }

        public ActionResult StudentEditArea(int no = 0)
        {
            SE_Student result = new SE_Student();
            result = _studentHelper.GetAllStudent().FirstOrDefault(m => m.StudentNo == no && m.Active == true);
            if (result == null || result.StudentNo == 0)
            {
                result = new SE_Student();
            }
            return View(result);
        }

        [HttpPost]
        public ActionResult AddStudent(SE_Student data)
        {
            data.Active = true;
            data.StudentID = "00000";
            bool insertcheck = _studentHelper.InsertStudent(data);
            return new JsonResult { Data = new { success = insertcheck } };
        }

        [HttpPost]
        public ActionResult DeleteStudent(int no = 0)
        {
            bool deletecheck = _studentHelper.DeleteStudent(no);
            return new JsonResult { Data = new { success = deletecheck } };
        }

        [HttpPost]
        public ActionResult UpdateStudent(SE_Student form, int No = 0)
        {
            bool updatecheck = _studentHelper.UpdateStudent(form, No);
            return new JsonResult { Data = new { success = updatecheck } };
        }

        #region 選課

        public ActionResult SelectionCourseIndex()
        {
            return View();
        }

        public ActionResult SelectionCourseEditArea()
        {
            var studentlist = _studentHelper.GetAllStudent().Where(m => m.Active == true).ToList();
            var courselist = _courseHelper.GetAllCourse().Where(m => m.Active == true).ToList();
            ViewBag.StudentList = studentlist;
            ViewBag.CourseList = courselist.Select(n => new SelectCourse()
            {
                CourseNo = n.CourseNo,
                CourseID = n.CourseID,
                CourseName = n.Name,
                isSelect = false
            }).ToList();

            return View();
        }

        public ActionResult SelectionCourseList()
        {
            List<SelectionCourseModel> models = new List<SelectionCourseModel>();
            var studentlist = _studentHelper.GetAllStudent().Where(m => m.Active == true).ToList();
            var enrollmentsList = _studentHelper.GetAllEnrollment().Where(m => m.Course.Active == true && m.Student.Active == true).ToList();
            if (enrollmentsList.Count > 0 && studentlist.Count > 0)
            {
                models = (from p in studentlist
                          select new SelectionCourseModel()
                          {
                              StudentNo = p.StudentNo,
                              StudentID = p.StudentID,
                              StudentName = p.Name,
                              Courses = string.Join("、", enrollmentsList.Where(m => m.StudentNo == p.StudentNo)?.Select(m => m.Course.Name))
                          }).Where(m => !string.IsNullOrEmpty(m.Courses)).ToList();

            }
            return View(models);
        }

        public ActionResult GetStudentEnrollment(int no = 0)
        {
            List<BS_Enrollment> studentdata = _studentHelper.GetAllEnrollment().Where(m => m.StudentNo == no).ToList();
            var course = _courseHelper.GetAllCourse().Where(m => m.Active == true).ToList();
            List<SelectCourse> model = new List<SelectCourse>();
            model = course.Select(m => new SelectCourse()
            {
                CourseName = m.Name,
                CourseNo = m.CourseNo,
                CourseID = m.CourseID,
                isSelect = studentdata.Count > 0 ? (studentdata.Any(n => n.CourseNo == m.CourseNo) ? true : false) : false
            }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEnrollment(string[] data, int No = 0)
        {
            List<BS_Enrollment> model = new List<BS_Enrollment>();
            if (data != null && data.Count() > 0)
            {
                model = (from p in data
                         select new BS_Enrollment()
                         {
                             StudentNo = No,
                             CourseNo = int.TryParse(p, out int a) ? a : 0
                         }).Where(m => m.CourseNo != 0).ToList();
            }
            bool insertcheck = _studentHelper.InsertEnrollment(model);
            return new JsonResult { Data = new { success = insertcheck } };
        }

        [HttpPost]
        public ActionResult DeleteEnrollment(int no = 0)
        {
            bool deletecheck = _studentHelper.DeleteEnrollment(no);
            return new JsonResult { Data = new { success = deletecheck } };
        }

        [HttpPost]
        public ActionResult UpdateEnrollment(string[] data, int No = 0)
        {
            List<BS_Enrollment> model = new List<BS_Enrollment>();
            if (data != null && data.Count() > 0)
            {
                model = (from p in data
                         select new BS_Enrollment()
                         {
                             StudentNo = No,
                             CourseNo = int.TryParse(p, out int a) ? a : 0
                         }).Where(m => m.CourseNo != 0).ToList();
            }

            bool updatecheck = _studentHelper.UpdateEnrollment(model, No);
            return new JsonResult { Data = new { success = updatecheck } };
        }
        #endregion

    }
}
