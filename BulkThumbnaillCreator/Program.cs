using System;
using System.IO;
using System.Threading.Tasks;
using System.Configuration;

namespace BulkThumbnaillCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();

            Console.ReadKey();
        }

        static void Run()
        {
            // The address of a directory with pictures for processing.
            string nameFile = ConfigurationManager.AppSettings.Get("nameFile");

            // Directory in which there are pictures for processing.
            DirectoryInfo myDir = new DirectoryInfo(nameFile);

            // The new sizes of pictures.
            int sizeW = Convert.ToInt32(ConfigurationManager.AppSettings.Get("sizeW"));
            int sizeH = Convert.ToInt32(ConfigurationManager.AppSettings.Get("sizeH"));

            Transformation transfomation = new Transformation();

            while (true)
            {
                View.Menu();

                switch (View.EnterNumber(3, () => View.Menu()))
                {
                    case 1:
                        {
                            string namePictures = View.EnterNamePictures();

                            Task transformName = new Task(() => transfomation.ChangeOfNames(myDir, namePictures));

                            transformName.Start();
                        } 
                        break;

                    case 2:
                        {
                            Task transformSize = new Task(() => transfomation.ChangeOfSize(myDir, sizeW, sizeH));

                            transformSize.Start();

                            View.DisplayMessageSize();
                        } 
                        break;

                    case 3: View.ExitProgram(); break;
                }
            }
        }
    }
}
