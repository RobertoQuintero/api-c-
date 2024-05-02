using System.Collections;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.Reflection.PortableExecutable;

namespace ImpresoraServidor.Models
{
    public class DatosTicket
    {
        public string rutaLogo { get; set; }
        public string headerLines1 { get; set; }
        public string headerLines2 { get; set; }
        public string headerLines3 { get; set; }
        public string headerLines4 { get; set; }
        public string headerLines5 { get; set; }
        public string headerLines6 { get; set; }
        public string headerLines7 { get; set; }
        public string headerLines8 { get; set; }

        ArrayList headerLines = new ArrayList();

        int count = 0;

        int maxChar = 35;
        int maxCharDescription = 17;

        int imageHeight = 0;

        float leftMargin = 0;
        float topMargin = 3;

        string fontName = "Lucida Console";
        int fontSize = 9;

        bool lineaEmilio = false;
        Font printFont = null;
        SolidBrush myBrush = new SolidBrush(Color.Black);
        Graphics gfx = null;

        string line = null;
        public void PrintTicket(string impresora)
        {


            printFont = new Font(fontName, fontSize, FontStyle.Regular);
            PrintDocument pr = new PrintDocument();
            pr.PrinterSettings.PrinterName = impresora;
            pr.PrintPage += new PrintPageEventHandler(pr_PrintPage);
            pr.Print();
        }
        private void pr_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            gfx = e.Graphics;

            if (headerLines1.Length > maxChar)
            {
                int currentChar = 0;
                int headerLenght = headerLines1.Length;

                while (headerLenght > maxChar)
                {
                    line = headerLines1.Substring(currentChar, maxChar);
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                    currentChar += maxChar;
                    headerLenght -= maxChar;
                }
                line = headerLines1;
                gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                count++;
            }
            else
            {
                line = headerLines1;
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                count++;
            }

        }

        private float YPosition()
        {
            return topMargin + (count * printFont.GetHeight(gfx) + imageHeight);
        }

    }
}
