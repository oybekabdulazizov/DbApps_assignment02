using Project01.Models;
using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Project01
{
    class Program
    {
        public static void Main(string[] args)
        {
            University university = new University();

            var source = args.Length > 0 ? args[0] :
                            @"C:\Users\CEM\Users\Documents\GitRepos\DbApps_assignment02\Solution01\Project01\Files\data.csv";

            var outpurPath = args.Length > 1 ? args[1] :
                            @"C:\Users\CEM\Documents\GitRepos\DbApps_assignment02\Solution01\Project01\Files\output";

            var outputType = args.Length > 2 ? args[2] : "xml";

            Console.WriteLine($"{source}\n{outpurPath}\n{outputType}");

            try
            {
                if (File.Exists(source) == false)
                {
                    throw new FileNotFoundException(@"C:\Users\CEM\Documents\GitRepos\DbApps_assignment02\Solution01\Project01\Files\log.txt", $"{DateTime.UtcNow} The source file was not found\n");
                }

                var lines = File.ReadAllLines(source);
                foreach (var line in lines)
                {
                    var wordSplitter = line.Split(",");

                    if (wordSplitter.Length < 9)
                    {
                        File.AppendAllText(
                                            @"C:\Users\CEM\Documents\GitRepos\DbApps_assignment02\Solution01\Project01\Files\log.txt",
                                            $"{DateTime.UtcNow} There is an error on line {line}\n");
                        continue;
                    }

                    university.Students.Add(new Student(wordSplitter[0], wordSplitter[1],
                                                new Studies(wordSplitter[2], wordSplitter[3]),
                                                wordSplitter[4], wordSplitter[5], wordSplitter[6],
                                                wordSplitter[7], wordSplitter[8]));
                }

                // XML 
                using var writer = new FileStream($"{outpurPath}.{outputType}", FileMode.Create);
                var xmlSerializer = new XmlSerializer(typeof(University));
                xmlSerializer.Serialize(writer, university);

                // Json 
                string jsonString = JsonSerializer.Serialize(university);
                string jsonFile = @"C:\Users\CEM\Documents\GitRepos\DbApps_assignment02\Solution01\Project01\Files\output.json";
                File.WriteAllText(jsonFile, jsonString);
            }
            catch (FileNotFoundException ex)
            {
                File.AppendAllText(
                                    @"C:\Users\CEM\Documents\GitRepos\DbApps_assignment02\Solution01\Project01\Files\log.txt",
                                    $"{DateTime.UtcNow} The file does not exist: {ex.FileName}");
            }
        }
    }
}
