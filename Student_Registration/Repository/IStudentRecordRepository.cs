using Student_Registration.Models;

namespace Student_Registration.Repository
{
    public interface IStudentRecordRepository
    {
        //List all students
        public IEnumerable<StudentViewModel> GetStudentsList();

        //Add an Employee
        public void AddNewStudent(StudentViewModel student);
    }
}
