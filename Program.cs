using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.pdfbox.pdmodel;
using org.pdfbox.util;
using System.IO;

namespace pdf2txt
{
    class Program
    {
        public static void pdf2txt(FileInfo pdffile, FileInfo txtfile)
        {
            PDDocument doc = PDDocument.load(pdffile.FullName);
            PDFTextStripper pdfStripper = new PDFTextStripper();
            string text = pdfStripper.getText(doc);
            
            StreamWriter swPdfChange = new StreamWriter(txtfile.FullName, false, Encoding.GetEncoding("gb2312"));
            swPdfChange.Write(text);
            swPdfChange.Close();
        }

        static void Main(string[] args)
        {
            FileInfo src = new FileInfo(args[0].ToString());
            FileInfo dst = new FileInfo(args[1].ToString());
            //FileInfo src = new FileInfo("d:\\3.pdf");
            //FileInfo dst = new FileInfo("d:\\3.txt");

            pdf2txt(src, dst);
        }
    }
}
