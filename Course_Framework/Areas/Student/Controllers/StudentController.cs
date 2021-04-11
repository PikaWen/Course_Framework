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

        // GET: Course/Course
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
    }
}
