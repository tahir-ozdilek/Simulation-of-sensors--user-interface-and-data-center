using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thesis_UI1
{
    public class Person
    {
        public int id;
        string name;
        string surname;
        DateTime birthDate;

        public List<Sensor> dataTypesToBeGenerated = new List<Sensor>();
        //public List<string> generatingParameters = new List<string>();
        public List<Question> questions = new List<Question>();
 
        public Person(int id, string name, string surname, DateTime birthDate)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.birthDate = birthDate;
        }

        public void addNewDataType(Sensor data)
        {
            dataTypesToBeGenerated.Add(data);
        }

        public void removeDataType(int index)
        {
            dataTypesToBeGenerated.RemoveAt(index);
        }

        /*public void addNewGeneratingParameter(string parameter)
        {
            generatingParameters.Add(parameter);
        }*/

        public void addNewQuestion(Question question)
        {
            questions.Add(question);
        }

        public void removeQuestion(int index)
        {
            questions.RemoveAt(index);
        }

        public string getFullName()
        {
            return name + surname;
        }
    }
}
