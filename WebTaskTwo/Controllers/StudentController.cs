using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTaskTwo.Models;

namespace WebTaskTwo.Controllers
{  
    public class StudentController : Controller
    {
        static IList<Student> studentList = new List<Student>{
                new Student() { StudentId = 1,Profession="Student", Name = "John", Age = 18, Gender = "Male", Address="Dewas", AddmissionDate = new DateTime(), Fees= 5000} ,
                new Student() { StudentId = 2,Profession="Student", Name = "Steve",  Age = 21, Gender = "Male", Address="Dewas", AddmissionDate = new DateTime(), Fees= 6000} ,
                new Student() { StudentId = 3, Profession="Teacher",Name = "Bill",  Age = 25, Gender = "Male", Address="Dewas", AddmissionDate = new DateTime(), Fees= 7000} ,
                new Student() { StudentId = 4, Profession="Student",Name = "Ram" , Age = 20, Gender = "Male", Address="Dewas", AddmissionDate = new DateTime(), Fees= 8000 } ,
                new Student() { StudentId = 5, Profession="Teacher",Name = "Ron" , Age = 31, Gender = "Female", Address="Dewas", AddmissionDate = new DateTime(), Fees= 2000 } ,
                new Student() { StudentId = 5, Profession="Teacher",Name = "Ron" , Age = 31, Gender = "Female", Address="Dewas", AddmissionDate = new DateTime(), Fees= 2000 } ,
                new Student() { StudentId = 6, Profession="Teacher",Name = "Chris" , Age = 17, Gender = "Male", Address="Dewas", AddmissionDate = new DateTime(), Fees= 1000 } ,
                new Student() { StudentId = 7, Profession="Student",Name = "Rob" , Age = 19, Gender = "Male", Address="Dewas", AddmissionDate = new DateTime(), Fees= 500 }
            };
    
        // GET: Student
        public ActionResult Index()
        {
            return View(studentList);
        }

        public ActionResult Edit(int id)
        {
            var std = studentList.Where(s => s.StudentId == id).FirstOrDefault();
            return View(std);
        }

        [HttpPost]
        public ActionResult EditStudent(Student std)
        {
            if (ModelState.IsValid)
            { //checking model state
                var student = studentList.Where(s => s.StudentId == std.StudentId).FirstOrDefault();
                studentList.Remove(student);
                studentList.Add(std);
                return RedirectToAction("Index");
            }
            return View("edit", std);
        }
        public ActionResult Details(int id)
        {
           var stddet = studentList.Where(s => s.StudentId == id).FirstOrDefault();
            ViewBag.Student = stddet;
           return View();
        }
        
        [HttpDelete]
        public ActionResult Delete(int id) 
        {
            var student = studentList.Where(s => s.StudentId == id).FirstOrDefault();
            studentList.Remove(student);
            return View();
        }


        [HttpPost]
        public ActionResult Edit(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student();
                student.Profession = formCollection["Profession"];
                student.Name = formCollection["Name"];
                student.Gender = formCollection["Gender"];
                student.Age = Convert.ToInt32(formCollection["Age"]);
                student.Address = formCollection["Address"];
                student.AddmissionDate = Convert.ToDateTime(formCollection["AddmissionDate"]);
                student.Fees = Convert.ToInt32(formCollection["Fees"]);
             

                RedirectToAction("Index");
            }
            return View();
        }
    }
}