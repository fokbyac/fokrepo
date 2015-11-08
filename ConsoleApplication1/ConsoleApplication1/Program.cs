using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // consoleoutput
            // aperror
            // aperror_agriport.importexe

            DateTime startZeit = DateTime.Now;

            Task<Object> taskConsoleOutput =    new Task<Object>((obj) => tailConsoleOutput(obj), startZeit);
            Task<Object> taskAperror =          new Task<Object>((obj) => tailAperror(obj), startZeit);
            Task<Object> taskAperrorAPImport =  new Task<Object>((obj) => tailAperrorAPImport(obj), startZeit);

            taskConsoleOutput.Start();
            taskAperror.Start();
            taskAperrorAPImport.Start();

            Console.WriteLine("{0}", taskConsoleOutput.Result);


            Console.ReadLine();
            
        }

        static Object tailConsoleOutput(object startZeit)
        {            
            //DateTime taskStart = DateTime.Now;
            //Console.WriteLine("task1 start: {0}", taskStart);
            zeigeBeginn("task1");
            
            StreamReader sr = new StreamReader(@"C:\Users\User\Documents\tuning-primer_sh.txt");
            Console.WriteLine("task1: {0}", sr.BaseStream.Length);
            sr.BaseStream.Seek(-1024, SeekOrigin.End);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine("task1: {0}", line);
            }


            DateTime taskEnd = DateTime.Now;
            Console.WriteLine("task1 end: {0}", taskEnd);
            return "EndeTask1";
        }
        static Object tailAperror(Object startZeit)
        {
            DateTime taskStart = DateTime.Now;
            Console.WriteLine("task2 start: {0}", taskStart);

            StreamReader sr = new StreamReader(@"C:\Users\User\Documents\vmware.log");
            Console.WriteLine("task2: {0}", sr.BaseStream.Length);
            sr.BaseStream.Seek(-1024, SeekOrigin.End);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine("task2: {0}", line);
            }
            
            DateTime taskEnd = DateTime.Now;
            Console.WriteLine("task2 end: {0}", taskEnd);
            return "EndeTask2";
        }
        static Object tailAperrorAPImport(Object startZeit)
        {
            DateTime taskStart = DateTime.Now;
            Console.WriteLine("task3 start: {0}", taskStart);
            for (int i = 0; i < 100000000f; i++)
            {
            }
            DateTime taskEnd = DateTime.Now;
            Console.WriteLine("task3 end: {0}", taskEnd);
            return "EndeTask3";
        }

        static void zeigeBeginn(string taskname)
        {
            DateTime taskStart = DateTime.Now;
            Console.WriteLine("{0} start: {1:YYY-MM-DD}", taskname, taskStart);
        }

    }
}
