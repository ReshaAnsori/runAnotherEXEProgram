using System;
using System.Configuration;
using System.Diagnostics;

namespace runAnotherEXEProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ErrorStts = ConfigurationManager.AppSettings["DebugConsole"].ToLower() == "true";
            try
            {
                var path = ConfigurationManager.AppSettings["EXETarget"];
                var exeName = path.Split("\\")[path.Split("\\").Length - 1];
                //Process[] processes = Process.GetProcessesByName("chrome");
                Process[] processes = Process.GetProcessesByName(exeName.Replace(".exe", string.Empty));
                foreach (var process in processes)
                {
                    process.Kill();
                }
                //Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe");
                Process.Start(path);
                Console.WriteLine("==================================== Success Execute ====================================");
            }
            catch (Exception e)
            {
                ErrorStts = true;
                Console.WriteLine("==================================== Filed Execute ====================================");
                Console.WriteLine("Exception : " + e.Message);
            }
            if (ErrorStts)
                Console.ReadKey();
        }
    }
}
