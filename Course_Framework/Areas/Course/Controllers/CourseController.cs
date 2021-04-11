using Course_Framework.DataObject.Course;
using Course_Framework.Models.DB;

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Course_Framework.Areas.Course.Controllers
{
    public class CourseController : Controller
    {
        private CourseHelper _courseHelper = new CourseHelper();

        // GET: Course/Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CourseList()
        {
            List<BS_Course> courseList = _courseHelper.GetAllCourse().Where(m => m.Active == true).ToList();
            return View(courseList);
        }

        public ActionResult CourseEditArea(int no = 0)
        {
            BS_Course result = new BS_Course();
            result = _courseHelper.GetAllCourse().FirstOrDefault(m => m.CourseNo == no && m.Active == true);
            if (result == null || result.CourseNo == 0)
            {
                result = new BS_Course();
            }
            return View(result);
        }

        [HttpPost]
        public ActionResult AddCourse(BS_Course data)
        {
            data.Active = true;
            data.CourseID = "0000";
            bool insertcheck = _courseHelper.InsertCourse(data);
            return new JsonResult { Data = new { success = insertcheck } };
        }

        [HttpPost]
        public ActionResult DeleteCourse(int no = 0)
        {
            bool deletecheck = _courseHelper.DeleteCourse(no);
            return new JsonResult { Data = new { success = deletecheck } };
        }

        [HttpPost]
        public ActionResult UpdateCourse(BS_Course form, int No = 0)
        {
            bool updatecheck = _courseHelper.UpdateCourse(form, No);
            return new JsonResult { Data = new { success = updatecheck } };
        }
    }
}