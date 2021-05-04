using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPattern.Flyweight
{
   public static class ImageProcessor
    {

        public static Dictionary<int, Image> Images = new Dictionary<int, Image>();

        public static Image AddImage(int ImageId)
        {
            if(!Images.ContainsKey(ImageId))
            {
                Image image = new Image();
                image.Id = ImageId;
                Images.Add(ImageId, image);
                
            }

            return Images[ImageId];

        }



    }
}
