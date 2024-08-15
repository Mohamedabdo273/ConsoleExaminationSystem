using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Exam
    {
        private List<Question> questions = new List<Question>();
        Student student = new Student();
        public string AddQuestion(int number)
        {

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("Enter the question text:");
                string questionText = Console.ReadLine();

                Console.WriteLine("Enter the correct answer:");
                string correctAnswer = Console.ReadLine();

                questions.Add(new Question(questionText, correctAnswer));
            }
            return "Question added successfully!";
        }


        public string EditQuestion(int index, string question, string answer)
        {

            if (index >= 0 && index < questions.Count)
            {
                questions[index].Text = question;

                questions[index].Answer = answer;

                return "Question edited successfully!";
            }
            else
                return "Invalid question number.";

        }

        public bool RemoveQuestion(int index)
        {
            return questions.Remove(questions[index]);
        }

        public int TakeExam()
        {
            if (questions.Count == 0)
            {
                return 0;

            }
            else
            {
                int score = 0;
                foreach (var question in questions)
                {
                    Console.WriteLine($"*{question.Text}\n");
                    Console.WriteLine("Your answer : \n");
                    string answer = Console.ReadLine();
                    Console.WriteLine();
                    if (question.IsCorrect(answer))
                    {
                        score++;
                    }
                }

                // return $" Your score is: {score}/{questions.Count}";
                return score;
            }
        }

        public void DisplayQuestions()
        {
            if (questions.Count == 0)
            {
                Console.WriteLine("Sorry,No question found");
            }
            else
            {
                for (int i = 0; i < questions.Count; i++)
                    Console.WriteLine($"{i + 1}. {questions[i].Text}");
            }

        }
    }
}
