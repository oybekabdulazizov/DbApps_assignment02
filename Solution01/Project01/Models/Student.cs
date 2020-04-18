using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Project01.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [XmlAttribute]
        public string IndexNumber { get; set; }
        public string DOB { get; set; }
        public string EmailAddress { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public Studies Study { get; set; }

        public Student(string firstName, string surname, Studies study, string idNumber,
                        string dob, string email, string motherName, string fatherName)
        {
            FirstName = firstName;
            LastName = surname;
            IndexNumber = idNumber;
            DOB = dob;
            EmailAddress = email;
            FatherName = fatherName;
            MotherName = motherName;
            Study = study;
        }

        public Student()
        {
        }
    }
}
