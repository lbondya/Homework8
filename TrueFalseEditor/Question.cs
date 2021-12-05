using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueFalseEditor
{

    /// <summary>
    /// Вопрос
    /// </summary>
    public class Question
    {

        /// <summary>
        /// Текс вопроса
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// ответ на вопрос (да/нет)
        /// </summary>
        public bool TrueFalse { get; set; }

        public Question(string text, bool trueFalse)
        {
            Text = text;
            TrueFalse = trueFalse;
        }

        public Question() { }

    }
}
