using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vDesktop
{
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public string job { get; set; }
        public Student student { get; set; }
    }

    public class Student
    {
        public int grade { get; set; }
        public int classNo { get; set; }
    }
}
