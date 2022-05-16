using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dogs
{
    internal class Let
    {
        public float x;
        public float y;
        public int sizeX;
        public int sizeY;
        public Image Img;
    }

    internal class Trees : Let
    {
        public Trees(float x, float y)
        {
            this.Img = new Bitmap("C:\\Users\\UserHome\\Desktop\\омгврс\\image\\RaceTree.png");
            this.x = x;
            this.y = y;
            this.sizeX = 60;
            this.sizeY = 100;
        }
    }

    internal class Stump : Let
    {
        public Stump(float x, float y)
        {
            this.Img = new Bitmap("C:\\Users\\UserHome\\Desktop\\омгврс\\image\\stump.png");
            this.x = x;
            this.y = y;
            this.sizeX = 30;
            this.sizeY = 10;
        }
    }
}
