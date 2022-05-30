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

        public Let MoveLet(Let let, DogTeam team, List<Let> LetList)
        {
            let.y += team.speed * 0.05F;
            return CreateNewLet(let, LetList, team);
        }

        private Let CreateNewLet(Let let, List<Let> LetList, DogTeam team)
        {
            if (let.y > 400)
            {
                Random rnd = new Random();
                float x = rnd.Next(10, 700);
                if (ThereIsNoOblect(x, -100, team, LetList))
                {
                    let.x = x;
                    let.y = -100;
                }
                else
                {
                    x += 100;
                    if (ThereIsNoOblect(x, -100, team, LetList))
                    {
                        let.x = x;
                        let.y = -100;
                    }
                }
            }
            return let;
        }

        private bool ThereIsNoOblect(float x, float y, DogTeam team, List<Let> LetList)
        {
            if ((x >= team.x - team.sizeX / 2 && x <= team.x + team.sizeX / 2) && (y >= team.y - team.sizeY / 2 && y <= team.y + team.sizeY / 2))
                return false;
            for (int i = 0; i < LetList.Count; i++)
                if ((x >= LetList[i].x - LetList[i].sizeX / 2 && x <= LetList[i].x + LetList[i].sizeX / 2) && (y >= LetList[i].y - LetList[i].sizeY / 2 && y <= LetList[i].x + LetList[i].sizeY / 2))
                    return false;
            return true;
        }

        public bool Collide(Let let, DogTeam team)
        {
            PointF delta = new PointF();
            delta.X = team.x - let.x;
            delta.Y = team.y - let.y;
            if (Math.Abs(delta.X) <= team.sizeX / 2 + let.sizeX / 2 - 10)
                if (Math.Abs(delta.Y) <= team.sizeY / 2 + let.sizeY / 2)
                {
                    return true;
                }
            return false;
        }
    }

        internal class Trees : Let
    {
        public Trees(float x, float y)
        {
            this.Img = new Bitmap("C:\\Users\\UserHome\\Desktop\\омгврс\\image\\RaceTree.png");
            this.x = x;
            this.y = y;
            this.sizeX = 40;
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
