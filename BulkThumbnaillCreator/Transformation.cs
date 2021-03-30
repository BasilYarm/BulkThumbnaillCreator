using System.IO;
using System.Drawing;
using System.Configuration;

namespace BulkThumbnaillCreator
{
    class Transformation
    {
        static string _firstFormat = ConfigurationManager.AppSettings.Get("firstFormat");
        static string _lastFormat = ConfigurationManager.AppSettings.Get("lastFormat");

        public void ChangeOfNames(DirectoryInfo myDir, string newName)
        {
            string newDirectory = ConfigurationManager.AppSettings.Get("fileTranformName"); 

            FileInfo[] imageFile = myDir.GetFiles("*." + _firstFormat, SearchOption.AllDirectories);

            DirectoryInfo newDir = new DirectoryInfo(newDirectory);

            foreach (FileInfo n in newDir.GetFiles())
            {
                n.Delete();
            }

            for (int i = 0; i < imageFile.Length; i++)
            {
                imageFile[i].CopyTo(newDir.FullName + "\\" + newName + (i + 1).ToString() + "." + _lastFormat);
            }
        }

        public void ChangeOfSize(DirectoryInfo myDir, int width, int height)
        {
            string newDirectory = ConfigurationManager.AppSettings.Get("fileTranformSize");

            FileInfo[] imageFile = myDir.GetFiles("*." + _firstFormat, SearchOption.AllDirectories);

            DirectoryInfo newDir = new DirectoryInfo(newDirectory);

            foreach (FileInfo n in newDir.GetFiles())
            {
                n.Delete();
            }
            
            for (int i = 0; i < imageFile.Length; i++)
            {
                Image image = new Bitmap(myDir.FullName + "\\" + imageFile[i].Name);

                int newH, newW;

                var coefH = (double)height / (double)image.Height;
                var coefW = (double)width / (double)image.Width;

                // Installation of the new sizes of a photo depending on set heights and width.
                if (coefW > coefH)
                {
                    newH = (int)(image.Height * coefH);
                    newW = (int)(image.Width * coefH);
                }
                else
                {
                    newH = (int)(image.Height * coefW);
                    newW = (int)(image.Width * coefW);
                }

                // Creation of a new picture with the necessary sizes.
                Image res = new Bitmap(image, newW, newH);

                // Preservation of the received picture without change of a name in a necessary directory.
                res.Save(newDir.FullName + "\\" + imageFile[i].Name);
             }
        }
    }
}
