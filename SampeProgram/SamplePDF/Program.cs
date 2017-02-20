using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SamplePDF
{
    class Program : PdfFile
    {
        static string sourceLocation = ConfigurationManager.AppSettings["sourcePath"];
        static string targetPath = ConfigurationManager.AppSettings["targetPath"];

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Starting extraction .....");
            IList<PdfFile> files = GetAllFiles;

            foreach (PdfFile file in files)
            {
                int count = GetNumberofPages(file.SourcePath);
                for (int i = 1; i <= count; i++)
                {
                    string path = string.Format(@"{0}\Page{1}", file.TargetPath, i);
                    CreateDirectory(path);
                    string pdfTarget = string.Format(@"{0}\Page{1}.pdf", path, i);
                    ExtractPages(file.SourcePath, pdfTarget, i, i);
                    ExtractXml(pdfTarget);
                    DeleteFile(pdfTarget);
                }
                LogIndexFile(Path.GetDirectoryName(file.SourcePath), string.Format("Extracted [{0}/{1}] files: pdf name {2}", files.IndexOf(file) + 1, files.Count(), Path.GetFileName(file.SourcePath)));
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Extraction complete.....");
            Console.Read();
        }

        private static void DeleteFile(string pdfTarget)
        {
            try
            {
                File.Delete(pdfTarget);
            }
            catch(IOException ex)
            {
                Console.WriteLine("Drive not found");
            }
        }

        private static void LogIndexFile(string path, string text)
        {
            StreamWriter indexFile;
            if (!File.Exists(string.Format(@"{0}\Index.log", path)))
            {
                indexFile = File.CreateText(string.Format(@"{0}\Index.log", path));
            }
            else
            {
                indexFile = File.AppendText(string.Format(@"{0}\Index.log", path));
            }
            indexFile.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            indexFile.Close();
        }

        public static void ExtractXml(string pdfPath)
        {
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            string xmlPath = System.IO.Path.ChangeExtension(pdfPath, ".xml");
            //f.XmlOptions.ConvertNonTabularDataToSpreadsheet = true;
            f.OpenPdf(pdfPath);
            if(f.PageCount > 0)
            {
                int result = f.ToXml(xmlPath);
            }
        }

        public static void ExtractPages(string pdfPath, string pdfTarget, int i1, int i2)
        {
            try
            {
                PdfReader reader = null;
                Document sourceDocument = null;
                PdfCopy pdfCopyProvider = null;
                PdfImportedPage importedImage = null;

                reader = new PdfReader(pdfPath);
                sourceDocument = new Document(reader.GetPageSizeWithRotation(i1));

                pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(pdfTarget, System.IO.FileMode.Create));
                sourceDocument.Open();
                for (int i = i1; i <= i2; i++)
                {
                    importedImage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedImage);
                }
                sourceDocument.Close();
                reader.Close();
            }
            catch(IOException ex)
            {
                Console.WriteLine("Invlaid drive");
            }
        }

        public static int GetNumberofPages(string path)
        {
            PdfReader reader = null;
            reader = new PdfReader(path);
            return reader.NumberOfPages;
            
        }

        public static void CreateDirectory(string path)
        {
            if(!Directory.Exists(path))
            {
                try
                {
                    DirectorySecurity securityRules = new DirectorySecurity();
                    DirectoryInfo dir = Directory.CreateDirectory(path);
                    dir.SetAccessControl(securityRules);
                }
                catch(IOException ex)
                {
                    Console.WriteLine("Invalid Drive");
                }
            }
        }

        public static IList<PdfFile> GetAllFiles
        {
            get
            {
                 List<PdfFile> pdffiles = new List<PdfFile>();
                try
                {
                    DirectoryInfo di = new DirectoryInfo(sourceLocation);
                    List<FileInfo> files = di.GetFiles("*.pdf").ToList();
                    foreach (FileInfo file in files)
                    {
                        CreateDirectory(string.Format(@"{0}\{1}", targetPath, file.Name.Split('.')[0]));
                        pdffiles.Add(new PdfFile(string.Format(@"{0}\{1}", sourceLocation, file.Name), string.Format(@"{0}\{1}", targetPath, file.Name.Split('.')[0])));
                    }
                    return pdffiles;
                }
                catch(DirectoryNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(IOException ex1)
                {
                    Console.WriteLine("Invalid drive");
                }
                return pdffiles;
            }
        }
    }

    public class PdfFile
    {
        public PdfFile(string source, string target)
        {
            SourcePath = source;
            TargetPath = target;
        }
        public PdfFile()
        {

        }
        public string SourcePath { get; set; }
        public string TargetPath { get; set; }
    }
}
