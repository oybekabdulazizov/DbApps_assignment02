using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Project01.Models
{
    [Serializable]
    public class University
    {
        [XmlAttribute]
        public string Author { get; set; }

        [XmlAttribute(AttributeName = "CreatedAt")]
        [JsonPropertyName("CreatedAt")]
        public string DateCreated { get; set; }

        public HashSet<Student> Students { get; set; }

        public University()
        {
            Students = new HashSet<Student>();
            Author = "Oybek Abdulazizov";
            DateCreated= DateTime.Now.ToString("yyyy-mm-dd");
        }
    }
}
