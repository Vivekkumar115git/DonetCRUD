namespace DAL;
using BOL;
using MySql.Data.MySqlClient;


public class StudentDeptDB{

    public static List<Student> GetAllStudentDB(){
        List<Student> students=new List<Student>();
        
        string conString = @"server=localhost;uid=root;"+"pwd=Vivek#123;database=dotnet";
        MySqlConnection con=new MySqlConnection(conString);
        
        string query=" SELECT student.student_id,student.student_name,department.dept_name FROM Student join department ON student.dept_id=department.dept_id ";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        con.Open();
        MySqlDataReader reader=cmd.ExecuteReader();
        while(reader.Read()){
            int StudentId=int.Parse(reader["student_id"].ToString());
            string StudentName=reader["student_name"].ToString();
        
            string DeptName=reader["dept_name"].ToString();
            Student stud=new Student{
                Student_Id=StudentId,
                Student_Name=StudentName,
                Department_Name=DeptName
                };
            students.Add(stud);    
            }
        con.Close();
        return students;
    }

    public static List<Department> GetAllDepartmentDB(){
        List<Department> department=new List<Department>();
        string conString="server=localhost;uid=root;"+"password=Vivek#123;database=dotnet";
        MySqlConnection con =new MySqlConnection(conString);
        string query="SELECT * from department";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        con.Open();
        MySqlDataReader reader=cmd.ExecuteReader();
        while(reader.Read()){
            int DepId=int.Parse(reader["dept_id"].ToString());
            string DepName=reader["dept_name"].ToString();
            Department deptDb=new Department{
                Department_Id=DepId,
                Department_Name=DepName
            };
            department.Add(deptDb);

        }
        con.Close();

        return department;
    }

    public static void InsertStudent(Student student){
       
        string conString="server=localhost;uid=root;"+"password=Vivek#123;database=dotnet";
        MySqlConnection con =new MySqlConnection(conString);
        string query="insert into student values('"+student.Student_Id+ "','"+student.Student_Name+ "','"+student.Department_Id+"')";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        con.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Record is inserted...");
        
        con.Close();
        

        
    }

    public static void RemoveStudent(int id){
       
        string conString="server=localhost;uid=root;"+"password=Vivek#123;database=dotnet";
        MySqlConnection con =new MySqlConnection(conString);
        string query="DELETE FROM student WHERE student_id="+id;
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        con.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Record is Delete...");
        
        con.Close();
        

        
    }

    public static void EditStudent(Student stud){
       
        string conString="server=localhost;uid=root;"+"password=Vivek#123;database=dotnet";
        MySqlConnection con =new MySqlConnection(conString);
        string query="UPDATE student SET student_Name='"+stud.Student_Name+"', dept_id='"+stud.Department_Id+"'WHERE student_id='"+stud.Student_Id+"'";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        con.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Record is Update...");
        
        con.Close();
        

        
    }
}