using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thjoe14_netAssignment.Models;
using System.IO;

namespace thjoe14_netAssignment.Controllers
{
    public class SubmissionController : Controller
    {
        private string submissionsPath = "submissions.txt";


        public ActionResult ViewSubmissions()
        {
            ViewSubmissionViewModel viewModel = new ViewSubmissionViewModel
            {
                SubmissionsCollection = getallSubmissions()
            };
            return View(viewModel);

        }
        public ActionResult Index()
        {
            return View();
        }

        //line setup: firstname,lastname,email,telephone,birthday,authkey
        private List<Submission> getallSubmissions()
        {
            List<Submission> temp = new List<Submission>();

            using (var reader = new StreamReader(submissionsPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    temp.Add(new Submission(line));
                }

            }
            return temp;
        }
    }
}