
namespace UserRegisterApp
{
    internal class FileOperation
    {
        private readonly string _fileName;
        private readonly string _password;
        private readonly string _name;
        public string Name { get; set; }
        public string Password { get; set; }

        public FileOperation(string fileName)
        {
            _fileName = fileName;
            _password = Password;
            _name = Name;
        }


        //string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
        //string path2 = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
        //var directory = System.IO.Path.GetDirectoryName(path);


        public void createFile()
        {
            if (!File.Exists(_fileName))
            {
                using (StreamWriter sw = File.CreateText(_fileName))
                {
                    sw.WriteLine(@"{0} / {1}", Name, Password);
                }
            }
        }
        public void upDateFile()
        {
            if (File.Exists(_fileName))
            {
                using (StreamWriter sw = File.AppendText(_fileName))
                {
                    sw.WriteLine(@"{0} / {1}", Name, Password);
                }
            }
        }
        public void viewFile()
        {
            if (File.Exists(_fileName))
            {
                using (StreamReader sr = File.OpenText(_fileName))
                {
                    var s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                   
                }
            }
        }



    }
}
            

   

