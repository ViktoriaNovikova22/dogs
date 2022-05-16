using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace dogs
{
    internal class DogTeam
    {
        public float x;
        public float y;
        public float speed = 1;
        public bool IsWinner = false;
        public int size;
        public Image TeamImg;
        public DogTeam(float x, float y)
        {
            TeamImg = new Bitmap("C:\\Users\\UserHome\\Desktop\\омгврс\\image\\TeamImg.jpg");
            this.x = x;
            this.y = y;
            this.size = 25;
        }
    }
}
