using Microsoft.AspNetCore.Mvc;
using StudentManagmen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagmen.ViewModels;
using Microsoft.AspNetCore.Hosting.Internal;
using System.IO;

namespace StudentManagmen.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly HostingEnvironment hostingEnvironment;

        public HomeController (IStudentRepository studentRepository, HostingEnvironment hostingEnvironment)
        {
            _studentRepository = studentRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        /*[Route("")]
        [Route("Home")]
        [Route("Home/Index")]*/
        public IActionResult Index()
        {
            IEnumerable<Student> students = _studentRepository.GetStudents();
            return View(students);
            
        }

        //[Route("Home/Details/{id?}")]
        public IActionResult Details(int id)
        {

            Student student = _studentRepository.GetStudent(id);
            
            if(student == null)
            {
                Response.StatusCode = 404;
                return View("StudentNotFound", id);
            }

            //instance of HomeDetailsViewModel and save student info with titlepage 
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Student = student,
                PageTitle = "student detail information"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    uniqueFileName = ProcessUploadedFile(model);
                }

                Student newStudent = new Student { Name = model.Name, Email = model.Email, ClassName = model.ClassName, PhotoPath = uniqueFileName };
                _studentRepository.Add(newStudent);

                return RedirectToAction("Details", new { id = newStudent.Id });
            }

            return View();

        }

        //1.view
        // views model
        //2.adjust page 
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Student student = _studentRepository.GetStudent(id);
            
            StudentEditViewModel studentEditView = new StudentEditViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                ClassName = student.ClassName,
                ExistingPhotoPath = student.PhotoPath
            };

            return View(studentEditView);
        }

        [HttpPost]
        public IActionResult Edit(StudentEditViewModel model)
        {
            //check if the data is vaild
            if (ModelState.IsValid)
            {
                Student student = _studentRepository.GetStudent(model.Id);
                student.Email = model.Email;
                student.Name = model.Name;
                student.ClassName = model.ClassName;

                if (model.Photo != null) 
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath1 = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath1);

                        student.PhotoPath = ProcessUploadedFile(model);
                    }

                    _studentRepository.Update(student);

                }

               Student updateStudent = _studentRepository.Update(student);
               return RedirectToAction("Index");
            }

            return View(model);
        }

        //for reUse we better create a string for uploadFile
        //a function save photo to only path, and return only name
        private string ProcessUploadedFile(StudentCreateViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }

            }

            return uniqueFileName;
        }
    }
}
