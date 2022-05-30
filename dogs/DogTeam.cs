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
        public int sizeX;
        public int sizeY;
        public Image TeamImg;
        public DogTeam(float x, float y)
        {
            TeamImg = new Bitmap("C:\\Users\\UserHome\\Desktop\\омгврс\\image\\team.png");
            this.x = x;
            this.y = y;
            this.sizeX = 35;
            this.sizeY = 80;
        }

        public float MoveTeam(DogTeam team, float TimeForRace)
        {
            TimeForRace += team.speed * 0.01F;
            team.y -= team.speed * 0.05F;
            return TimeForRace;
        }

        public void Move(KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "a":
                    x -= 0.01f;
                    y -= 0.0005f;
                    break;
                case "d":
                    x += 0.01f;
                    y -= 0.0005f;
                    break;
            }
        }
    }
}
