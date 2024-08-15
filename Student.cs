using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp4
{
    public class Student : User
    {
        public override void Menu(Exam exam)
        {
            Console.WriteLine($"Welcome, {Name}! You are logged in as a Student.\n");
            Console.WriteLine($"{Name} , you completed the exam.  Your score is:{exam.TakeExam()}");
        }
    }
}
