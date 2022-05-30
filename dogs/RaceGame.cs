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
        public RaceGame(float speed, float TimeRace, float x, float y)
        {
            InitializeComponent();
            TimeForRace = TimeRace;
            Init(speed, x, y);
            Invalidate();
        }

        public void Init(float speed, float x, float y)
        {
            team = new DogTeam(x, y);
            team.speed = speed;
            tree1 = new Trees(100, 0);
            tree2 = new Trees(700, 125);
            tree3 = new Trees(400, 250);
            tree4 = new Trees(250, 325);
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
                stumps[i] = new Stump(i*50, rnd.Next(10, 400));
            this.KeyDown += new KeyEventHandler(Esc);
            MakeList();
            TimeGo();
        }

        private void TimeGo()
        {
            TimerLet.Interval = 1;
            TimerLet.Tick += new EventHandler(updateLet);
            TimerTeam.Interval = 1;
            TimerTeam.Tick += new EventHandler(updateTeam);
            timerForCollide.Interval = 1;
            timerForCollide.Tick += new EventHandler(CollideTick);
            TimerLet.Start();
            TimerTeam.Start();
            timerForCollide.Start();
        }


        private void updateTeam(object sender, EventArgs e)
        {
            TimeForRace = team.MoveTeam(team, TimeForRace);
            TimeBox.Text = "Время в пути: " + TimeForRace;
            this.KeyPress += new KeyPressEventHandler(key);
            if (team.y <= 70)
                    Results();
            Invalidate();
        }

        private void updateLet(object sender, EventArgs e)
        {
            for (int i = 0; i < LetList.Count; i++)
            {
                LetList[i] = LetList[i].MoveLet(LetList[i], team, LetList);
            }
            Invalidate();
        }

        private bool IsCollide()
        {
            foreach (var let in LetList)
                if (let.Collide(let, team))
                    return true;
            return false;
        }


        private void OnePaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.DrawImage(team.TeamImg, team.x, team.y, team.sizeX, team.sizeY);
            foreach (var let in LetList)
                DrawLet(let, e);
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
            Labyrinth();
        }

        private void Results()
        {
            TimerTeam.Stop();
            TimerLet.Stop();
            if (TimeForRace <= 60)
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

        private void key(object sender, KeyPressEventArgs e)
        {
            team.Move(e);
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

        private void CollideTick(object sender, EventArgs e)
        {
            if (IsCollide())
                ThisIsCollide();
        }

        private void ThisIsCollide()
        {
            TimeForRace += 10;
            TimerTeam.Stop();
            TimerLet.Stop();
            timerForCollide.Stop();
            CollideButton.Visible = true;
        }

        private void Labyrinth()
        {
            TimerTeam.Stop();
            TimerLet.Stop();
            timerForCollide.Stop();
            this.Hide();
            Lab lab = new Lab(TimeForRace, team.speed, team.x, team.y);
            lab.Show();
        }

        private void Esc(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }
    }
}
