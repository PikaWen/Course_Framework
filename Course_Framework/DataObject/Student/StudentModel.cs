namespace Course_Framework.DataObject.Student
{
    public class SelectionCourseModel
    {
        public int StudentNo { get; set; }
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string Courses { get; set; }
    }

    public class SelectCourse
    {
        public int CourseNo { get; set; }
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public bool isSelect { get; set; }
    }
}