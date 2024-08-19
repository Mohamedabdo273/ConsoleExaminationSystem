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
                            Console.WriteLine("Enter the number of questions :");
                            int number = int.Parse(Console.ReadLine());
                            exam.AddQuestion(number);
                            break;
                        case "2":
                            exam.DisplayQuestions();
                            Console.WriteLine("Enter the question number you want to edit:");
                            int index2 = int.Parse(Console.ReadLine()) - 1;
                            Console.WriteLine("Enter the new question text:");
                            string updatedQuestionText = Console.ReadLine();
                            if (exam.EditQuestion(index2, updatedQuestionText))
                                Console.WriteLine("Edition done");
                            else
                                Console.WriteLine("Not found");
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
