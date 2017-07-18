using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SlpGenerator
{
    public static class Util
    {
        public static string RemoveWhitespace(this string input)
        {
            int j = 0, inputlen = input.Length;
            char[] newarr = new char[inputlen];

            for (int i = 0; i < inputlen; ++i)
            {
                char tmp = input[i];

                if (!char.IsWhiteSpace(tmp))
                {
                    newarr[j] = tmp;
                    ++j;
                }
            }
            return new String(newarr, 0, j);
        }

        public static void SaveWindow(Window window, int dpi, string filename, Button btnToHide1, Button btnToHide2, Button btnToHide3, Button btnToHide4)
        {

            btnToHide1.Visibility = Visibility.Hidden;
            btnToHide2.Visibility = Visibility.Hidden;
            btnToHide3.Visibility = Visibility.Hidden;
            btnToHide4.Visibility = Visibility.Hidden;

            var rtb = new RenderTargetBitmap(
                (int)window.Width * 2, //width 
                (int)window.Height * 2, //height 
                dpi, //dpi x 
                dpi, //dpi y 
                PixelFormats.Pbgra32 // pixelformat 
                );
            rtb.Render(window);

            SaveRTBAsPNG(rtb, filename);
            btnToHide1.Visibility = Visibility.Visible;
            btnToHide2.Visibility = Visibility.Visible;
            btnToHide3.Visibility = Visibility.Visible;
            btnToHide4.Visibility = Visibility.Visible;
        }

        public static void SaveCanvas(Window window, Grid grid, int dpi, string filename)
        {
            Size size = new Size(window.Width, window.Height);

            grid.Measure(size);
            //canvas.Arrange(new Rect(size));

            var rtb = new RenderTargetBitmap(
                (int)window.Width, //width 
                (int)window.Height, //height 
                dpi, //dpi x 
                dpi, //dpi y 
                PixelFormats.Pbgra32 // pixelformat 
                );
            rtb.Render(grid);

            SaveRTBAsPNG(rtb, filename);
        }

        private static void SaveRTBAsPNG(RenderTargetBitmap bmp, string filename)
        {
            var enc = new System.Windows.Media.Imaging.PngBitmapEncoder();
            enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bmp));

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image file (*.png)|*.png";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFileDialog.ShowDialog() == true)
            {
                using (var stm = System.IO.File.Create(saveFileDialog.FileName))
                {
                    enc.Save(stm);
                }
            }

        }

    }
}
