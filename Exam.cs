using ConsoleApp4;
using System;
using System.Runtime.Intrinsics.X86;
using static System.Net.Mime.MediaTypeNames;

public class Exam
{
    private List<Question> questions = new List<Question>();
    
    public string AddQuestion(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Console.WriteLine("Choose the type of question to add:");
            Console.WriteLine("1. Multiple Choice");
            Console.WriteLine("2. True/False");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter the question text:");
                    string questionText = Console.ReadLine();
                    Console.WriteLine("Enter the number of options:");
                    int numberOfOptions = int.Parse(Console.ReadLine());
                    AddMultipleChoiceQuestion(questionText, numberOfOptions);
                    Console.WriteLine("Multiple-choice question added successfully!");
                    break;
                case "2":
                    Console.WriteLine("Enter the question text:");
                    string questionTexts = Console.ReadLine();
                    Console.WriteLine("Enter the correct answer (True/False):");
                    string correctAnswer = Console.ReadLine().ToLower();
                    AddTrueFalseQuestion(questionTexts, correctAnswer);
                    Console.WriteLine("True/False question added successfully!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        return "Questions added successfully!";
    }

    private void AddMultipleChoiceQuestion(string questionText, int numberOfOptions)
    {
        List<string> options = new List<string>();
        for (int i = 0; i < numberOfOptions; i++)
        {
            Console.WriteLine($"Enter option {i + 1}:");
            string option= Console.ReadLine();
            options.Add(option);
        }
        Console.WriteLine("Enter the number of the correct option:");
        int correctOptionIndex = int.Parse(Console.ReadLine()) - 1;

        questions.Add(new MultipleChoiceQuestion(questionText, options, correctOptionIndex));
        
    }

    private void AddTrueFalseQuestion(string questionText, string correctAnswer)
    {
        questions.Add(new TrueFalseQuestion(questionText, correctAnswer));
    }

    public bool EditQuestion(int index,string updatedQuestionText)
    {
        int found = 0;
        if (index >= 0 && index < questions.Count)
        {
            found = 1;
            if (questions[index] is MultipleChoiceQuestion multipleChoiceQuestion)
            {
                multipleChoiceQuestion.DisplayOptions();
                Console.WriteLine("Enter the number of options:");
                int numberOfOptions = int.Parse(Console.ReadLine());
                List<string> options = new List<string>();
                for (int i = 0; i < numberOfOptions; i++)
                {
                    Console.WriteLine($"Enter option {i + 1}:");
                    string option = Console.ReadLine();
                    options.Add(option);
                }
                Console.WriteLine("Enter the number of the correct option:");
                int correctOptionIndex = int.Parse(Console.ReadLine()) - 1;

                questions[index] = new MultipleChoiceQuestion(updatedQuestionText, options, correctOptionIndex);

            }
            else if (questions[index] is TrueFalseQuestion)
            {
                
                Console.WriteLine("Enter the new correct answer (True/False):");
                string updatedCorrectAnswer = Console.ReadLine().ToLower();

                questions[index] = new TrueFalseQuestion(updatedQuestionText, updatedCorrectAnswer);
            }
            else
            {
                return false;
            }
            return true;
        }

        return false;
    }
    public bool RemoveQuestion(int index)
    {
        int found = 0;
        if (index >= 0 && index < questions.Count)
        {
            found = 1;
            questions.Remove(questions[index]);
        }
        if (found == 1)
            return true;
        else
            return false;
    }
    public int TakeExam()
    {
        if (questions.Count == 0)
        {
            return 0;
        }

        int score = 0;
        
        foreach (var question in questions)
        {
            
            Console.WriteLine(question.Text);

            if (question is MultipleChoiceQuestion multipleChoiceQuestion) 
            {
                multipleChoiceQuestion.DisplayOptions();
            }
            else
                Console.WriteLine("(True/False):\n");

            Console.WriteLine("Your answer:\n");
            string answer = Console.ReadLine();
            if (question.IsCorrect(answer))
            {
                score++;
            }
        }

        return score;
    }

    public void DisplayQuestions()
    {

        if (questions.Count == 0)
        {
            Console.WriteLine("No questions found.");
        }
        else
        {
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {questions[i].Text}");
            }
        }
    }
    
}
