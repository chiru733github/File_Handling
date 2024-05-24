using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;


namespace File_Handling
{
    class Person
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Country { get; set; }
    }
    internal class Program
    {
        static void WriteTocsv(string filepath)
        {
            try
            {
                if(!File.Exists(filepath))
                {
                    using (File.Create(filepath)) { }
                }
                List<Person> list =
                [
                    new Person() {Name="Chiru",Age=23,Country="India"},
                    new Person() {Name="Dileep",Age=24,Country="India"},
                    new Person() {Name="Gopi",Age=22,Country="Korea"},
                    new Person() {Name="Badri",Age=23,Country="India"}
                ];
                var ConfigPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false
                };
                using (StreamWriter writer = File.CreateText(filepath))
                using (CsvWriter csvWriter = new(writer, ConfigPersons))
                {
                    csvWriter.WriteRecords(list);
                };
                Console.WriteLine("Successfully created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void ReadToCSV(string filepath)
        {
            try
            {
                if(File.Exists(filepath))
                {
                    var Config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    { HasHeaderRecord = false };
                    using (StreamReader sr = File.OpenText(filepath))
                    using (CsvReader cr = new(sr, Config))
                    {
                        IEnumerable<Person> records = cr.GetRecords<Person>();
                        foreach (Person person in records)
                        {
                            Console.WriteLine($"Name is {person.Name}, Age is {person.Age} and" +
                                $"Country name is {person.Country}");
                        }
                    }
                }
                else Console.WriteLine("File is not exsist");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void Main(string[] args)
        {
            string filepath = @"C:\Users\pagad\source\repos\Problems\File_Handling\data.csv";
            WriteTocsv(filepath);
            //ReadTocsv
            ReadToCSV(filepath);
            
            //create file
            string Path = @"C:\Users\pagad\source\repos\Problems\File_Handling\new.txt";
            if (!File.Exists(Path))
            {
                File.Create(Path);
                Console.WriteLine("File is created.");
            }
            //remove existing file
            //File.Delete(Path);
            //Console.WriteLine("File is removed.");
            //write data in file.
            using(StreamWriter writer = File.CreateText(Path))
            {
                writer.WriteLine("Hello World");
                writer.WriteLine("C# is a programming language");
                Console.WriteLine("write data in a file.");
            }
            // Read the file.
            string line = File.ReadAllText(Path);
            Console.WriteLine(line);
            string[] lines = File.ReadAllLines(Path);
            foreach(string i in lines) Console.WriteLine(i);
            //create a file and write an array of strings to the file
            string[] arr = ["this is 1st line", "this is 2nd line"];
            string Path1 = @"C:\Users\pagad\source\repos\Problems\File_Handling\arrdata.txt";
            if(!File.Exists(Path1)) 
            {
                File.Create(Path1);
                Console.WriteLine("Arrdata text file is created.");
            }
            using(StreamWriter sw = File.CreateText(Path1))
            {
                foreach(string i in arr)
                {
                    sw.WriteLine(i);
                }
            }
            using(StreamReader sr = File.OpenText(Path1))
            {
                string? line1;
                while((line1 = sr.ReadLine())!=null)
                {
                    Console.WriteLine(line1);
                }
            }
            //Convert from c# object to Json.
            List<Person> list =
                [
                    new Person() {Name="Chiru",Age=23,Country="India"},
                    new Person() {Name="Dileep",Age=24,Country="India"},
                    new Person() {Name="Gopi",Age=22,Country="Korea"},
                    new Person() {Name="Badri",Age=23,Country="India"}
                ];
            var json = JsonConvert.SerializeObject(list);
            string filePath1 = @"C:\Users\pagad\source\repos\Problems\File_Handling\jsonFile.json";
            if (File.Exists(filePath1))
            {
                File.WriteAllText(filePath1, json);
                Console.WriteLine("Successfully add data in JSON file.");
            }
            if (File.Exists(filePath1))
            {
                var read = File.ReadAllText(filePath1);
                List<Person>? list2 = JsonConvert.DeserializeObject<List<Person>>(read);
                if (list2 is not null)
                {
                    foreach (Person person in list2) Console.WriteLine(person.Name);
                }
            }
            //check if a file exist, then read data from file,
            //else create new file and add data
            if(File.Exists(filePath1))
            {
                var read = File.ReadAllText(filePath1);
                Console.WriteLine(read);
            }
            else
            {
                File.Create(filePath1);
                string lines2 = "File handling in c#";
                File.WriteAllText(filePath1, lines2);
            }
            string filePath3 = @"C:\Users\pagad\source\repos\Problems\File_Handling\objFile.json";
            try
            {
                string d = File.ReadAllText(filePath3);
                Console.WriteLine(d);
            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex.Message); 
            }
            Console.ReadKey();
        }
        
    }
}