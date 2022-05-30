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
    public partial class MakeTeam : Form
    {
        Dog leader = new Dog(3, 4, "Вожак");
        Dog strongDog = new Dog(4, 2, "Силач");
        Dog sage = new Dog(1, 5, "Мудрец");
        Dog youngDog = new Dog(3, 1, "Юнец");
        float speed = 1;
        int[] numbers = new int[4] { -1, -1, -1, -1 };
        int cointClick;

        public MakeTeam()
        {
            InitializeComponent();
            Init();
        }

        List<Button> teamButtons = new List<Button>();
        List<Button> dogButtons = new List<Button>();
        List<PictureBox> boxes = new List<PictureBox>();
        List<Dog> dogsList = new List<Dog>();
        bool[] isUsed = new bool[4];

        public void Init()
        {
            this.KeyDown += new KeyEventHandler(Esc);
            MakeList();
        }

        public void MakeList()
        {
            dogButtons.Add(leaderButton);
            dogButtons.Add(strongDogButton);
            dogButtons.Add(sageButton);
            dogButtons.Add(youngDogButton);

            teamButtons.Add(leftFirst);
            teamButtons.Add(rightFirst);
            teamButtons.Add(leftSecond);
            teamButtons.Add(RightSecond);

            dogsList.Add(leader);
            dogsList.Add(strongDog);
            dogsList.Add(sage);
            dogsList.Add(youngDog);

            boxes.Add(LFBox);
            boxes.Add(RFBox);
            boxes.Add(LSBox);
            boxes.Add(RSBox);
        }

        private void leaderClick(object sender, MouseEventArgs e)
        {           

            cointClick += 1;
            teamButtons[0].Visible = true;
            for (int i = 1; i < 4; i++)
            {
                dogButtons[i].Enabled = false;
                teamButtons[i].Visible = true;
            }

            isUsed[0] = true;

            leftFirst.Click += new EventHandler(LF_Click);
            rightFirst.Click += new EventHandler(RF_Click);
            leftSecond.Click += new EventHandler(LS_Click);
            RightSecond.Click += new EventHandler(RS_Click);
        }


        private void strongDogClick(object sender, EventArgs e)
        {
            cointClick += 1;
            teamButtons[1].Visible = true;
            for (int i = 0; i < 4; i++)
                if (i != 1)
                {
                    dogButtons[i].Enabled = false;
                    teamButtons[i].Visible = true;
                }

            isUsed[1] = true;

            leftFirst.Click += new EventHandler(LF_Click);
            rightFirst.Click += new EventHandler(RF_Click);
            leftSecond.Click += new EventHandler(LS_Click);
            RightSecond.Click += new EventHandler(RS_Click);
        }

        private void sageClick(object sender, EventArgs e)
        {
            cointClick += 1;
            teamButtons[2].Visible = true;
            for (int i = 0; i < 4; i++)
                if (i != 2)
                {
                    dogButtons[i].Enabled = false;
                    teamButtons[i].Visible = true;
                }

            isUsed[2] = true;

            leftFirst.Click += new EventHandler(LF_Click);
            rightFirst.Click += new EventHandler(RF_Click);
            leftSecond.Click += new EventHandler(LS_Click);
            RightSecond.Click += new EventHandler(RS_Click);
        }

        private void youngDogClick(object sender, EventArgs e)
        {
            cointClick += 1;
            teamButtons[3].Visible = true;
            for (int i = 0; i < 4; i++)
                if (i != 3)
                {
                    dogButtons[i].Enabled = false;
                    teamButtons[i].Visible = true;
                }

            isUsed[3] = true;

            leftFirst.Click += new EventHandler(LF_Click);
            rightFirst.Click += new EventHandler(RF_Click);
            leftSecond.Click += new EventHandler(LS_Click);
            RightSecond.Click += new EventHandler(RS_Click);
        }

        private void RS_Click(object sender, EventArgs e)
        {
            RSBox.Visible = true;
            for (int i = 0; i < 4; i++)
                if (!isUsed[i])
                {
                    dogButtons[i].Enabled = true;
                    teamButtons[i].Visible = false;
                }
            for (int i = 0; i < 4; i++)
                if (numbers[i] == -1)
                {
                    numbers[i] = 3;
                    break;
                }
            if (cointClick == 4)
            {
                ToHome.Enabled = true;
                Speed();
            }
        }

        private void LS_Click(object sender, EventArgs e)
        {
            LSBox.Visible = true;
            for (int i = 0; i < 4; i++)
                if (!isUsed[i])
                {
                    dogButtons[i].Enabled = true;
                    teamButtons[i].Visible = false;
                }
            for (int i = 0; i < 4; i++)
                if (numbers[i] == -1)
                {
                    numbers[i] = 2;
                    break;
                }
            if (cointClick == 4)
            {
                ToHome.Enabled = true;
                Speed();
            }
        }

        private void RF_Click(object sender, EventArgs e)
        {
            RFBox.Visible = true;
            for (int i = 0; i < 4; i++)
                if (!isUsed[i])
                {
                    dogButtons[i].Enabled = true;
                    teamButtons[i].Visible = false;
                }
            for (int i = 0; i < 4; i++)
                if (numbers[i] == -1)
                {
                    numbers[i] = 1;
                    break;
                }
            if (cointClick == 4)
            {
                ToHome.Enabled = true;
                Speed();
            }
        }

        private void LF_Click(object sender, EventArgs e)
        {
            LFBox.Visible = true;
            for (int i = 0; i < 4; i++)
                if (!isUsed[i])
                {
                    dogButtons[i].Enabled = true;
                    teamButtons[i].Visible = false;
                }
            for (int i = 0; i < 4; i++)
                if (numbers[i] == -1)
                {
                    numbers[i] = 0;
                    break;
                }
            if (cointClick == 4)
            {
                ToHome.Enabled = true;
                Speed();
            }
        }

        private void Again_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                dogButtons[i].Enabled = true;
                teamButtons[i].Visible = false;
                isUsed[i] = false;
                numbers[i] = -1;
                boxes[i].Visible = false;
            }
            cointClick = 0;
            speed = 1;
            SpeedText.Visible = false;
            ToHome.Enabled = false;
        }

        private void ToHome_Click(object sender, EventArgs e)
        {
            RaceGame race = new RaceGame(speed, 0, 350, 375);
            this.Hide();
            race.Show();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\10.png");
            for (int i = 0; i < 4; i++)
            {
                dogButtons[i].Enabled = true;
                teamButtons[i].Visible = false;
                isUsed[i] = false;
                boxes[i].Visible = false;
                numbers[i] = -1;
            }
            cointClick = 0;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "HomeGame")
                {
                    this.Hide();
                    form.Visible = true;
                    break;
                }
            }
        }

        private void MakeTheBest_Click(object sender, EventArgs e)
        {
            numbers[0] = 0;
            numbers[1] = 3;
            numbers[2] = 2;
            numbers[3] = 1;
            Speed();
            foreach (var box in boxes)
                box.Visible = true;
            ToHome.Enabled = true;
        }

        private void Speed()
        {
            var age = dogsList[numbers[3]].age + dogsList[numbers[2]].age + dogsList[numbers[0]].age * 0.1F + dogsList[numbers[1]].age * 0.1F;
            var power = dogsList[numbers[0]].power + dogsList[numbers[1]].power + dogsList[numbers[3]].power * 0.1F + dogsList[numbers[2]].power * 0.1F;
            speed = age + power;
            SpeedText.Text = " Скорость: " + 
                speed.ToString();
            SpeedText.Visible = true;
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
