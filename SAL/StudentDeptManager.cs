namespace SAL;
using BOL;
using DAL;

public class StudentDeptManager{

    public static List<Student> GetAllStudents(){
        return StudentDeptDB.GetAllStudentDB(); 
    }

    public static List<Department> GetAllDepartments(){
        return StudentDeptDB.GetAllDepartmentDB();
    }

    public static void AddStudent(Student stud){
       StudentDeptDB.InsertStudent(stud);
    }

    public static void DeleteStudent(int id){
        StudentDeptDB.RemoveStudent(id);
    }

    public static void Edit(Student student){
        StudentDeptDB.EditStudent(student);
    }
}