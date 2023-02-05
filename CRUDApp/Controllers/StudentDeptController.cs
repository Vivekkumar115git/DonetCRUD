using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDApp.Models;
using BOL;
using SAL;

namespace CRUDApp.Controllers;

public class StudentDeptController : Controller
{
    private readonly ILogger<StudentDeptController> _logger;

    public StudentDeptController(ILogger<StudentDeptController> logger)
    {
        _logger = logger;
    }

    public IActionResult Student()
    {   
        List<Student> stud=StudentDeptManager.GetAllStudents();
        this.ViewData["Student"]=stud;
        return View();
    }

    public IActionResult Department()
    {   
        List<Department> dept=StudentDeptManager.GetAllDepartments();
        this.ViewData["Department"]=dept;
        return View();
    }

    public IActionResult Insert(){
        return View();
    }
     
    [HttpPost] 
    public IActionResult InsertStudent([FromForm] Student student){
         StudentDeptManager.AddStudent(student); 
         
      
            return RedirectToAction("Student");
        
       
    }

    [HttpPost]
    public IActionResult Delete(int id){
       StudentDeptManager.DeleteStudent(id); 
       Console.WriteLine(id);
       return RedirectToAction("Student");
    }

    [HttpPost]
    public IActionResult Edit(int id){
        ViewBag.Id=id;  
        return View();
    }

    [HttpPost]
    public IActionResult EditStudent([FromForm] Student student){
        Console.WriteLine(student.Student_Id+" "+student.Student_Name+" "+student.Department_Id);
        StudentDeptManager.Edit(student); 
        return RedirectToAction("Student");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
