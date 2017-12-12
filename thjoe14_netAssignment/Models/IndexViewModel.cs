using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace thjoe14_netAssignment.Models
{
    public class IndexViewModel
    {
        [Required]
        [Display(Name = "First name")]
        [MinLength(2, ErrorMessage = "First name include more than 1 characters.")]
        [MaxLength(50, ErrorMessage = "First name ust include no more than 50 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [MinLength(2, ErrorMessage = "Last name must include 2 or more characters.")]
        [MaxLength(50, ErrorMessage = "Last name must include no more than 50 characters.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Submitted email is not valid.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Telephone")]
        [MinLength(2, ErrorMessage = "Telephone must include 2 or more characters.")]
        [MaxLength(20, ErrorMessage = "Telephone must include no more than 20 characters.")]
        [Phone(ErrorMessage = "Must be a phone number.")]
        public string Telephone { get; set; }

        [Required]
        [Display(Name = "Birthday")]
        [MinLength(6, ErrorMessage = "Birthday must include 6 or more characters.")]
        [MaxLength(50, ErrorMessage = "Birthday must include no more than 50 characters.")]
        public string Birthday { get; set; }

        [Required]
        [Display(Name = "Authentication key")]
        [AuthValidation(ErrorMessage = "Authentication key is not valid!")]
        public int Authentication { get; set; }



        //file locations in project folder
        private string AuthKeysPath = "authkeys.txt";
        private string TempKeysPath = "tempkeys.txt";


        //custom validation attribute
        public class AuthValidation : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                int input = Convert.ToInt32(value);

                return (ValidateAuthenticationKey(input));               
            }

            private string AuthKeysPath = "authkeys.txt";

            //validate authentication key
            public bool ValidateAuthenticationKey(int key)
            {
                string[] lines = File.ReadAllLines(AuthKeysPath);

                foreach (string line in lines)
                {
                    if (key == Int32.Parse(line))
                    {
                        return true;
                    }
                }
                return false;
            }
            public override string FormatErrorMessage(string name)
            {
                return base.FormatErrorMessage(name);
            }
        }

        //delete used authentication keys from file
        public void DeleteAuthenticationKey(int key)
        {
            using (var sr = new StreamReader(AuthKeysPath))
            using (var sw = new StreamWriter(TempKeysPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    //create new file without the deleted key
                    if (Int32.Parse(line) != key)
                        sw.WriteLine(line);
                }
            }
            //delete & overwrite
            File.Delete(AuthKeysPath);
            File.Move(TempKeysPath, AuthKeysPath);
        }

        //saves submission to txt file
        public Boolean SaveSubmission()
        {
            string path = "submissions.txt";
            //line setup: firstname,lastname,email,telephone,birthday,authkey
            string text = FirstName + "," + LastName + "," + Email + "," + Telephone + "," + Birthday + "," + Authentication;

            if (!File.Exists(path))
            {
                File.WriteAllText(path, text);
            }
            else
            {
                using (StreamWriter file = new StreamWriter(path, true))
                {
                    file.WriteLine(text);
                }
            }

            //write to file
            return true;
        }
    }
}
