using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dogs
{
    public partial class RaceGame : Form
    {
        float TimeForRace;
        DogTeam team;
        Trees tree1;
        Trees tree2;
        Trees tree3;
        Trees tree4;
        Stump[] stumps = new Stump[6];
        List<Let> LetList = new List<Let>();
        public RaceGame(float speed)
        {
            InitializeComponent();
            Init(speed);
            Invalidate();
        }

        public void Init(float speed)
        {
            team = new DogTeam(350, 375);
            team.speed = speed;
            tree1 = new Trees(100, 0);
            tree2 = new Trees(700, 125);
            tree3 = new Trees(400, 250);
            tree4 = new Trees(250, 375);
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
                stumps[i] = new Stump(i*50, rnd.Next(10, 400));
            MakeList();
            TimeGo();
        }

        private void TimeGo()
        {
            TimerLet.Interval = 1;
            TimerLet.Tick += new EventHandler(updateLet);
            TimerTeam.Interval = 1;
            TimerTeam.Tick += new EventHandler(updateTeam);
            TimerLet.Start();
            TimerTeam.Start();
        }

        private void MakeList()
        {
            LetList.Add(tree1);
            LetList.Add(tree2);
            LetList.Add(tree3);
            LetList.Add(tree4);
            for (int i = 0; i < 6; i++)
                LetList.Add(stumps[i]);
        }

        private void updateTeam(object sender, EventArgs e)
        {
            if (IsCollide())
                ThisIsCollide();
            MoveTeam();
            TimeBox.Text = "Время в пути: " + TimeForRace;
            Invalidate();
            if (team.y <= 40)
                Results();
        }

        private void ThisIsCollide()
        {
            TimeForRace += 1;
            TimerTeam.Stop();
            TimerLet.Stop();
            CollideButton.Visible = true;
        }

        private void updateLet(object sender, EventArgs e)
        {
            for (int i = 0; i < LetList.Count; i++)
            {
                LetList[i] = MoveLet(LetList[i]);
            }
            Invalidate();
        }

        private void MoveTeam()
        {
            this.KeyDown += new KeyEventHandler(keyboard);
            TimeForRace += team.speed * 0.01F;
            team.y -= team.speed * 0.01F;
        }

        private Let MoveLet(Let let)
        {
            let.y += team.speed * 0.05F;
            return CreateNewLet(let);
        }

        private Let CreateNewLet(Let let)
        {
            if (let.y > 400)
            {
                Random rnd = new Random();
                float x = rnd.Next(10, 700);
                if (ThereIsNoOblect(x, -100))
                {
                    let.x = x;
                    let.y = -100;
                }
                else
                {
                    x += 100;
                    if (ThereIsNoOblect(x, -100))
                    {
                        let.x = x;
                        let.y = -100;
                    }
                }
            }
            return let;
        }

        private void keyboard(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "A":
                    team.x -= 0.01f;
                    break;
                case "D":
                    team.x += 0.01f;
                    break;
            }
        }

        private bool IsCollide()
        {
            for (int i = 0; i < LetList.Count; i++)
                if (Collide(LetList[i]))
                    return true;
            return false;
        }

        private bool Collide(Let let)
        {
            PointF delta = new PointF();
            delta.X = team.x - let.x;
            delta.Y = team.y - let.y;
            if (Math.Abs(delta.X) <= team.size / 2 + let.sizeX / 2)
                if (Math.Abs(delta.Y) <= team.size / 2 + let.sizeY / 2)
                {
                    return true;
                }
            return false;
        }

        private void OnePaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(team.TeamImg, team.x, team.y, team.size, team.size);
            for (int i = 0; i < LetList.Count; i++)
                DrawLet(LetList[i], e);
        }

        private void DrawLet(Let let, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(let.Img, let.x, let.y, let.sizeX, let.sizeY);
        }

        private void CollideButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LetList.Count; i++)
            {
                LetList[i].y -= 150;
            }
            CollideButton.Visible = false;
            TimeGo();
        }

        private bool ThereIsNoOblect(float x, float y)
        {
            if ((x >= team.x - team.size / 2 && x <= team.x + team.size / 2) && (y >= team.y - team.size / 2 && y <= team.y + team.size / 2))
                return false;
            for (int i = 0; i < LetList.Count; i++)
                if ((x >= LetList[i].x - LetList[i].sizeX / 2 && x <= LetList[i].x + LetList[i].sizeX / 2) && (y >= LetList[i].y - LetList[i].sizeY / 2 && y <= LetList[i].x + LetList[i].sizeY / 2))
                    return false;
            return true;
        }

        private void Results()
        {
            TimerTeam.Stop();
            TimerLet.Stop();
            if (TimeForRace <= 360)
                ResultBox.BackgroundImage = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\image\\win.jpg");
            ResultBox.Visible = true;
            TryAgain.Visible = true;
        }

        private void TryAgain_Click(object sender, EventArgs e)
        {
            MakeTeam makeTeam = new MakeTeam();
            this.Hide();
            makeTeam.Show();
        }
    }
}
