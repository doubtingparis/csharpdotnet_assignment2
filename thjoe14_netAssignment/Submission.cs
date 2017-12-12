using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thjoe14_netAssignment
{
    public class Submission
    {
        //line setup: firstname,lastname,email,telephone,birthday,authkey
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }
        public string birthday { get; set; }
        public int authkey { get; set; }


        public Submission(string line)
        {
            var strArr = line.Split(",");

            firstName = strArr[0];
            lastName = strArr[1];
            email = strArr[2];
            telephone = strArr[3];
            birthday = strArr[4];
            authkey = Convert.ToInt32(strArr[5]);
        }

   
    }
}
