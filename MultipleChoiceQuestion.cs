using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class MultipleChoiceQuestion : Question
    {
        public List<string> Options { get; set; }
        public int CorrectOptionIndex { get; set; }

        public MultipleChoiceQuestion(string text="none", List<string> options=null, int correctOptionIndex=0)
            : base(text)
        {
            Options = options;
            CorrectOptionIndex = correctOptionIndex;
        }

        public override bool IsCorrect(string answer)
        {
            return int.Parse(answer) == CorrectOptionIndex;
        }

        public  void DisplayOptions()
        {
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Options[i]}");
            }
        }
    }

}
