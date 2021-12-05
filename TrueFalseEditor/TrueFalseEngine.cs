using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TrueFalseEditor
{
    public class TrueFalseEngine
    {

        #region Private Fields

        private string fileName;
        private List<Question> list;

        #endregion

        #region Public Properties

        public int Count
        {
            get { return list.Count; }
        }

        public string FileName
        {
            set { fileName = value; }
        }

        public Question this[int index]
        {
            get { return list[index]; }
        }


        #endregion

        #region Constructors

        public TrueFalseEngine(string fileName)
        {
            this.fileName = fileName;
            list = new List<Question>();
        }

        #endregion

        #region Public Methods

        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }

        public void Remove(int index)
        {
            if (list != null && index >= 0 && index < list.Count)
                list.RemoveAt(index);
        }


        public  void Load()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Question>)xmlSerializer.Deserialize(fileStream);
            fileStream.Close();
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fileStream, list);
            }
        }

        #endregion

    }
}
