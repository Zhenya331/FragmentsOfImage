using Server.Models;
using Server.Services.IService;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Services.ServiceImplementation
{
    public class FragmentsImplementation : IFragments
    {
        public IEnumerable<Fragment> GetFragments(Image image, int rows, int columns)
        {
            int numOfImages = rows * columns;
            int widthFrag = image.Width / rows;
            int heightFrag = image.Height / columns;
            var imgarray = new List<Image>();
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    imgarray.Add(new Bitmap(widthFrag, heightFrag));
                    using (var graphics = Graphics.FromImage(imgarray[imgarray.Count - 1]))
                    {
                        var fragment = new Rectangle(0, 0, widthFrag, heightFrag);
                        var fragmentFromInputImage = new Rectangle(j * widthFrag, i * heightFrag, widthFrag, heightFrag);
                        graphics.DrawImage(image, fragment, fragmentFromInputImage, GraphicsUnit.Pixel);
                        RectangleF textBox = new RectangleF(0, 0, widthFrag, heightFrag);
                        graphics.DrawString($"({j * widthFrag}; {i * heightFrag})", new Font("Arial", 12), Brushes.Cyan, textBox);
                    }
                }
            }

            List<Fragment> fragments = new List<Fragment>();
            for (int i = 0; i < numOfImages; i++)
            {
                ImageConverter _imageConverter = new ImageConverter();
                byte[] byteFragment = (byte[])_imageConverter.ConvertTo(imgarray[i], typeof(byte[]));
                fragments.Add(new Fragment { FragmentData = byteFragment, Width = widthFrag, Height = heightFrag });
            }

            return fragments;
        }
    }
}