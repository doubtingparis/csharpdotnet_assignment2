using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thjoe14_netAssignment.Models;

namespace thjoe14_netAssignment.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewSubmissions()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submitted(IndexViewModel svm)
        {
            //if form data are valid, this checks authkey too
            if (ModelState.IsValid)
            {
                IndexViewModel model = new IndexViewModel()
                {
                    FirstName = svm.FirstName,
                    LastName = svm.LastName,
                    Email = svm.Email,
                    Telephone = svm.Telephone,
                    Birthday = svm.Birthday,
                    Authentication = svm.Authentication
                };

                //save submission in file
                if (svm.SaveSubmission())
                {
                    //delete used key from file, if above submission was completed
                    //svm.DeleteAuthenticationKey(svm.Authentication);
                }

                return View(svm);
            }            
            else //form data is not valid
            {
                return View("Index");
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
