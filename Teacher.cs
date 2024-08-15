using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleApp4
{
     class Teacher : User
    {
        
        public override void Menu(Exam exam)
        {
            Console.WriteLine($"Welcome, {Name}! You are logged in as a Teacher.");
            bool exit = false;
            while (!exit)
                            {
Console.WriteLine("1. Add Question\n2. Edit Question\n3. Remove Question\n4. Show Question\n5.Exit");
                string choice = Console.ReadLine();
                try
                {

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Enter the number of question");
                            int number = int.Parse(Console.ReadLine());
                            exam.AddQuestion(number);
                            break;
                        case "2":
                            exam.DisplayQuestions();
                            Console.WriteLine("Enter the question number you want to edit:");
                            int index2 = int.Parse(Console.ReadLine()) - 1;
                            Console.WriteLine("Enter the new question text:");
                            string question2 = Console.ReadLine();
                            Console.WriteLine("Enter the new correct answer:");
                            string answer2 = Console.ReadLine();
                            exam.EditQuestion(index2, question2, answer2);
                            break;
                        case "3":
                            exam.DisplayQuestions();
                            Console.WriteLine("Enter the question number you want to remove:");
                            int index = int.Parse(Console.ReadLine()) - 1;
                            if (exam.RemoveQuestion(index))
                                Console.WriteLine("Question removed successfully!");
                            else
                                Console.WriteLine("Invalid question number.");
                            break;
                        case "4":
                            exam.DisplayQuestions();
                            break;
                        case "5":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine($"Sorry,{ex.Message}");
                }
            }
        }
    }
}
