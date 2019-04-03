using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace CAS_DOCENTE
{
    public class Worker
    {
        string filePath = @"d:/test.txt";

        public void StartProcessing(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);

                using (File.Create(filePath)) { }
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath))
                {
                    for (int index = 1; index <= 20; index++)
                    {
                        //execute when task has been cancel  
                        cancellationToken.ThrowIfCancellationRequested();
                        file.WriteLine("Its Line number : " + index + "\n");
                        Thread.Sleep(1500);   // wait to 1.5 sec every time  
                    }

                    if (Directory.Exists(@"d:/done"))
                        Directory.Delete(@"d:/done");
                    Directory.CreateDirectory(@"d:/done");
                }
            }
            catch (Exception ex)
            {
                ProcessCancellation();
                File.AppendAllText(filePath, "Error Occured : " + ex.GetType().ToString() + " : " + ex.Message);
            }
        }
        private void ProcessCancellation()
        {
            Thread.Sleep(10000);
            File.AppendAllText(filePath, "Process Cancelled");
        }
    }
}