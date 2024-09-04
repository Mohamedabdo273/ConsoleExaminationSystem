using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class TrueFalseQuestion : Question
    {
        public string CorrectAnswer { get; set; }

        public TrueFalseQuestion(string text="none", string correctAnswer = "none")
            : base(text)
        {
            CorrectAnswer = correctAnswer;
        }

        public override bool IsCorrect(string answer)
        {
            return answer.Equals(CorrectAnswer.ToString());
        }
        public override string ToString()
        {
            return "(True/False):\n";
        }
    }

}
