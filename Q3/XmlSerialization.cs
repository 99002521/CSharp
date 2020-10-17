using System;
using System.IO;
using System.Xml.Serialization;


namespace AssessmentRetry
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }

        public override string ToString()
        {
            return string.Format($"The name: {Name} from {Address} is available at {Phone}");
        }
    }
    class SerializationXML
    {
        static void Main(string[] args)
        {
            xmlExample();
            Console.ReadKey();
        }

        private static void xmlExample()
        {
            Console.WriteLine("Select the option you want to perform : Read or Write(r/w)");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "r")
                deserializingXml();
            else if (choice.ToLower() == "w")
                serializingXml();
            else
                Console.WriteLine("Please provide a valid input");
        }

        private static void deserializingXml()
        {
            try
            {
                XmlSerializer sl = new XmlSerializer(typeof(Student));
                FileStream fs = new FileStream("Data.xml", FileMode.Open, FileAccess.Read);
                Student s = (Student)sl.Deserialize(fs);
                Console.WriteLine(s);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void serializingXml()
        {
            Student s = new Student();
            Console.WriteLine("Enter the name of student:");
            s.Name = Console.ReadLine();
            Console.WriteLine("Enter the Address :");
            s.Address = Console.ReadLine();
            Console.WriteLine("Enter the Contact Number");
            s.Phone = long.Parse(Console.ReadLine());
            FileStream fs = new FileStream("Data.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer sl = new XmlSerializer(typeof(Student));
            sl.Serialize(fs, s);
            fs.Flush();
            fs.Close();
        }
    }

}