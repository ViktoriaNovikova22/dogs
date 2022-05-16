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
        int number = -1;
        int number2 = -1;
        int number3 = -1;
        int number4 = -1;
        int cointClick;

        public MakeTeam()
        {
            InitializeComponent();
            Init();
        }

        List<Button> teamButtons = new List<Button>();
        List<Button> dogButtons = new List<Button>();
        List<Dog> dogsList = new List<Dog>();
        bool[] isUsed = new bool[4];

        public void Init()
        {
            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\10.png");
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

        private void Again_Click(object sender, EventArgs e)
        {
            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\10.png");
            for (int i = 0; i < 4; i++)
            {
                dogButtons[i].Enabled = true;
                teamButtons[i].Visible = false;
                isUsed[i] = false;
            }
            cointClick = 0;
            number = -1;
            number2 = -1;
            number3 = -1;
            speed = 1;
            SpeedText.Visible = false;
            ToHome.Enabled = false;
        }

        private void ToHome_Click(object sender, EventArgs e)
        {
            RaceGame race = new RaceGame(speed);
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
            }
            cointClick = 0;
            number = -1;
            number2 = -1;
            number3 = -1;
            speed = 1;
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
            number = 0;
            number2 = 3;
            number3 = 2;
            number4 = 1;
            Speed();
            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
            ToHome.Enabled = true;
        }

        private void Speed()
        {
            var age = dogsList[number3].age + dogsList[number4].age + dogsList[number].age * 0.1F + dogsList[number2].age * 0.1F;
            var power = dogsList[number].power + dogsList[number2].power + dogsList[number3].power * 0.1F + dogsList[number4].power * 0.1F;
            speed = age + power;
            SpeedText.Text = " Скорость: " + 
                speed.ToString();
            SpeedText.Visible = true;
        }

        private void LF_Click(object sender, EventArgs e)
        {
            switch (cointClick)
            {
                case 1:
                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\11.png");
                    number = 0;
                    break;
                case 2:
                    switch (number)
                    {
                        case 0:
                            for (int i = 1; i < 4; i++)
                            {
                                teamButtons[i].Enabled = false;
                                dogButtons[i].Enabled = true;
                                cointClick--;
                            }
                            break;
                        case 1:
                            number2 = 0;
                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\4.png");
                            break;
                        case 2:
                            number2 = 0;
                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\9.png");
                            break;
                        case 3:
                            number2 = 0;
                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\16.png");
                            break;
                    }
                    break;
                case 3:
                    switch (number)
                    {
                        case 0:
                            for (int i = 1; i < 4; i++)
                            {
                                teamButtons[i].Enabled = false;
                                dogButtons[i].Enabled = true;
                                cointClick--;
                            }
                            break;
                        case 1:
                            switch (number2)
                            {
                                case 0:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 1:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 2:
                                    number3 = 0;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\5.png");
                                    break;
                                case 3:
                                    number3 = 0;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\3.png");
                                    break;
                            }
                            break;
                        case 2:
                            switch (number2)
                            {
                                case 0:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 2:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 1:
                                    number3 = 0;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\5.png");
                                    break;
                                case 3:
                                    number3 = 0;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\6.png");
                                    break;
                            }
                            break;
                        case 3:
                            switch (number2)
                            {
                                case 0:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 3:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 1:
                                    number3 = 0;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\6.png");
                                    break;
                                case 2:
                                    number3 = 0;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\3.png");
                                    break;
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (number)
                    {
                        case 0:
                            for (int i = 1; i < 4; i++)
                            {
                                teamButtons[i].Enabled = false;
                                dogButtons[i].Enabled = true;
                                cointClick--;
                            }
                            break;
                        case 1:
                            switch (number2)
                            {
                                case 0:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 1:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 2:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 0;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");                            
                                            number4 = 0;
                                            Speed();   
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (number2)
                            {
                                case 0:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 2:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 1:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 0;
                                            Speed();    
                                            ToHome.Enabled = true;                                         
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 0;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case 3:
                            switch (number2)
                            {
                                case 0:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 3:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 1:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 0;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
            }

            for (int i = 0; i < 4; i++)
                if (!isUsed[i])
                {
                    dogButtons[i].Enabled = true;
                    teamButtons[i].Visible = false;
                }

        //    if (cointClick == 1)
        //    {
        //        leftFirst.Visible = false;
        //        for (int i = 0; i < 4; i++)
        //            if (i != number)
        //            {
        //                dogButtons[i].Enabled = true;
        //                teamButtons[i].Visible = false;
        //            }
        //    }

        //    if (cointClick == 2)
        //    {
        //        leftFirst.Visible = false;
        //        teamButtons[number].Visible = false;
        //        for (int i = 0; i < 4; i++)
        //            if (i != number2 && i != number )
        //            {
        //                dogButtons[i].Enabled = true;
        //                teamButtons[i].Visible = false;
        //            }
        //    }

        //    if (cointClick == 3)
        //    {
        //        leftFirst.Visible = false;
        //        teamButtons[number].Visible = false;
        //        teamButtons[number2].Visible = false;
        //        for (int i = 0; i < 4; i++)
        //            if (i != 0 && i != number && i != number2)
        //            {
        //                dogButtons[i].Enabled = true;
        //                teamButtons[i].Visible = false;
        //            }
        //    }
        }

        private void RF_Click(object sender, EventArgs e)
        {
            switch (cointClick)
            {
                case 1:
                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\12.png");
                    number = 1;
                    break;
                case 2:
                    switch (number)
                    {
                        case 1:
                            for (int i = 1; i < 4; i++)
                            {
                                teamButtons[i].Enabled = false;
                                dogButtons[i].Enabled = true;
                                cointClick--;
                            }
                            break;
                        case 0:
                            number2 = 1;
                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\4.png");
                            break;
                        case 2:
                            number2 = 1;
                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\15.png");
                            break;
                        case 3:
                            number2 = 1;
                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\16.png");
                            break;
                    }
                    break;
                case 3:
                    switch (number)
                    {
                        case 1:
                            for (int i = 1; i < 4; i++)
                            {
                                teamButtons[i].Enabled = false;
                                dogButtons[i].Enabled = true;
                                cointClick--;
                            }
                            break;
                        case 0:
                            switch (number2)
                            {
                                case 0:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 1:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 2:
                                    number3 = 1;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\5.png");
                                    break;
                                case 3:
                                    number3 = 1;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\3.png");
                                    break;
                            }
                            break;
                        case 2:
                            switch (number2)
                            {
                                case 1:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 2:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 0:
                                    number3 = 1;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\5.png");
                                    break;
                                case 3:
                                    number3 = 1;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\7.png");
                                    break;
                            }
                            break;
                        case 3:
                            switch (number2)
                            {
                                case 1:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 3:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 0:
                                    number3 = 1;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\3.png");
                                    break;
                                case 2:
                                    number3 = 1;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\7.png");
                                    break;
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (number)
                    {
                        case 1:
                            for (int i = 1; i < 4; i++)
                            {
                                teamButtons[i].Enabled = false;
                                dogButtons[i].Enabled = true;
                                cointClick--;
                            }
                            break;
                        case 0:
                            switch (number2)
                            {
                                case 0:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 1:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 2:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 1;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 1;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (number2)
                            {
                                case 1:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 2:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 0:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 1;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (number3)
                                    {
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 0:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 1;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case 3:
                            switch (number2)
                            {
                                case 1:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 3:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 0:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 1;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (number3)
                                    {
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 0:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 1;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
            }
            for (int i = 0; i < 4; i++)
                if (!isUsed[i])
                {
                    dogButtons[i].Enabled = true;
                    teamButtons[i].Visible = false;
                }
            //if (cointClick == 1)
            //{
            //    rightFirst.Visible = false;
            //    for (int i = 0; i < 4; i++)
            //        if (i != 1)
            //        {
            //            dogButtons[i].Enabled = true;
            //            teamButtons[i].Visible = false;
            //        }
            //}

            //if (cointClick == 2)
            //{
            //    rightFirst.Visible = false;
            //    teamButtons[number].Visible = false;
            //    for (int i = 0; i < 4; i++)
            //        if (i != 1 && i != number)
            //        {
            //            dogButtons[i].Enabled = true;
            //            teamButtons[i].Visible = false;
            //        }
            //}

            //if (cointClick == 3)
            //{
            //    rightFirst.Visible = false;
            //    teamButtons[number].Visible = false;
            //    teamButtons[number2].Visible = false;
            //    for (int i = 0; i < 4; i++)
            //        if (i != 1 && i != number && i != number2)
            //        {
            //            dogButtons[i].Enabled = true;
            //            teamButtons[i].Visible = false;
            //        }
            //}
        }

        private void LS_Click(object sender, EventArgs e)
        {
            switch (cointClick)
            {
                case 1:
                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\14.png");
                    number = 2;
                    break;
                case 2:
                    switch (number)
                    {
                        case 2:
                            for (int i = 1; i < 4; i++)
                            {
                                teamButtons[i].Enabled = false;
                                dogButtons[i].Enabled = true;
                                cointClick--;
                            }
                            break;
                        case 0:
                            number2 = 2;
                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\9.png");
                            break;
                        case 1:
                            number2 = 2;
                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\15.png");
                            break;
                        case 3:
                            number2 = 2;
                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\8.png");
                            break;
                    }
                    break;
                case 3:
                    switch (number)
                    {
                        case 2:
                            for (int i = 1; i < 4; i++)
                            {
                                teamButtons[i].Enabled = false;
                                dogButtons[i].Enabled = true;
                                cointClick--;
                            }
                            break;
                        case 0:
                            switch (number2)
                            {
                                case 0:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 2:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 1:
                                    number3 = 2;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\5.png");
                                    break;
                                case 3:
                                    number3 = 2;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\6.png");
                                    break;
                            }
                            break;
                        case 1:
                            switch (number2)
                            {
                                case 1:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 2:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 0:
                                    number3 = 2;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\5.png");
                                    break;
                                case 3:
                                    number3 = 2;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\7.png");
                                    break;
                            }
                            break;
                        case 3:
                            switch (number2)
                            {
                                case 2:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 3:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 0:
                                    number3 = 2;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\6.png");
                                    break;
                                case 1:
                                    number3 = 2;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\7.png");
                                    break;
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (number)
                    {
                        case 2:
                            for (int i = 1; i < 4; i++)
                            {
                                teamButtons[i].Enabled = false;
                                dogButtons[i].Enabled = true;
                                cointClick--;
                            }
                            break;
                        case 0:
                            switch (number2)
                            {
                                case 0:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 2:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 1:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 2;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 2;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case 1:
                            switch (number2)
                            {
                                case 1:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 2:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 0:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 2;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (number3)
                                    {
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 0:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 2;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case 3:
                            switch (number2)
                            {
                                case 2:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 3:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 0:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 2;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                                case 1:
                                    switch (number3)
                                    {
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 0:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 2;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
            }
            for (int i = 0; i < 4; i++)
                if (!isUsed[i])
                {
                    dogButtons[i].Enabled = true;
                    teamButtons[i].Visible = false;
                }
            //if (cointClick == 1)
            //{
            //    leftSecond.Visible = false;
            //    for (int i = 0; i < 4; i++)
            //        if (i != number)
            //        {
            //            dogButtons[i].Enabled = true;
            //            teamButtons[i].Visible = false;
            //        }
            //}

            //if (cointClick == 2)
            //{
            //    leftSecond.Visible = false;
            //    teamButtons[number].Visible = false;
            //    for (int i = 0; i < 4; i++)
            //        if (i != number2 && i != number)
            //        {
            //            dogButtons[i].Enabled = true;
            //            teamButtons[i].Visible = false;
            //        }
            //}

            //if (cointClick == 3)
            //{
            //    leftSecond.Visible = false;
            //    teamButtons[number].Visible = false;
            //    teamButtons[number2].Visible = false;
            //    for (int i = 0; i < 4; i++)
            //        if (i != 2 && i != number && i != number2)
            //        {
            //            dogButtons[i].Enabled = true;
            //            teamButtons[i].Visible = false;
            //        }
            //}
        }

        private void RS_Click(object sender, EventArgs e)
        {
            switch (cointClick)
            {
                case 1:
                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\13.png");
                    number = 3;
                    break;
                case 2:
                    switch (number)
                    {
                        case 3:
                            for (int i = 1; i < 4; i++)
                            {
                                teamButtons[i].Enabled = false;
                                dogButtons[i].Enabled = true;
                                cointClick--;
                            }
                            break;
                        case 0:
                            number2 = 3;
                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\16.png");
                            break;
                        case 1:
                            number2 = 3;
                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\2.png");
                            break;
                        case 2:
                            number2 = 3;
                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\8.png");
                            break;
                    }
                    break;
                case 3:
                    switch (number)
                    {
                        case 3:
                            for (int i = 1; i < 4; i++)
                            {
                                teamButtons[i].Enabled = false;
                                dogButtons[i].Enabled = true;
                                cointClick--;
                            }
                            break;
                        case 0:
                            switch (number2)
                            {
                                case 0:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 3:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 1:
                                    number3 = 3;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\3.png");
                                    break;
                                case 2:
                                    number3 = 3;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\6.png");
                                    break;
                            }
                            break;
                        case 1:
                            switch (number2)
                            {
                                case 1:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 3:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 0:
                                    number3 = 3;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\3.png");
                                    break;
                                case 2:
                                    number3 = 3;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\7.png");
                                    break;
                            }
                            break;
                        case 2:
                            switch (number2)
                            {
                                case 2:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 3:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 0:
                                    number3 = 3;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\6.png");
                                    break;
                                case 1:
                                    number3 = 3;
                                    teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\7.png");
                                    break;
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (number)
                    {
                        case 3:
                            for (int i = 1; i < 4; i++)
                            {
                                teamButtons[i].Enabled = false;
                                dogButtons[i].Enabled = true;
                                cointClick--;
                            }
                            break;
                        case 0:
                            switch (number2)
                            {
                                case 0:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 3:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 1:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 3;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 3;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case 1:
                            switch (number2)
                            {
                                case 1:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 3:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 0:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 3;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (number3)
                                    {
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 0:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 3;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            switch (number2)
                            {
                                case 2:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 3:
                                    for (int i = 1; i < 4; i++)
                                    {
                                        teamButtons[i].Enabled = false;
                                        dogButtons[i].Enabled = true;
                                        cointClick--;
                                    }
                                    break;
                                case 0:
                                    switch (number3)
                                    {
                                        case 0:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 1:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 3;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                                case 1:
                                    switch (number3)
                                    {
                                        case 1:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 2:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 3:
                                            for (int i = 1; i < 4; i++)
                                            {
                                                teamButtons[i].Enabled = false;
                                                dogButtons[i].Enabled = true;
                                                cointClick--;
                                            }
                                            break;
                                        case 0:
                                            teamBox.Image = Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\1.png");
                                            number4 = 3;
                                            Speed();
                                            ToHome.Enabled = true;
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
            }
            for (int i = 0; i < 4; i++)
                if (!isUsed[i])
                {
                    dogButtons[i].Enabled = true;
                    teamButtons[i].Visible = false;
                }
            //if (cointClick == 1)
            //{
            //    RightSecond.Visible = false;
            //    for (int i = 0; i < 4; i++)
            //        if (i != number)
            //        {
            //            dogButtons[i].Enabled = true;
            //            teamButtons[i].Visible = false;
            //        }
            //}

            //if (cointClick == 2)
            //{
            //    RightSecond.Visible = false;
            //    teamButtons[number].Visible = false;
            //    for (int i = 0; i < 4; i++)
            //        if (i != number2 && i != number)
            //        {
            //            dogButtons[i].Enabled = true;
            //            teamButtons[i].Visible = false;
            //        }
            //}

            //if (cointClick == 3)
            //{
            //    RightSecond.Visible = false;
            //    teamButtons[number].Visible = false;
            //    teamButtons[number2].Visible = false;
            //    for (int i = 0; i < 4; i++)
            //        if (i != 3 && i != number && i != number2)
            //        {
            //            dogButtons[i].Enabled = true;
            //            teamButtons[i].Visible = false;
            //        }
            //}
        }
    }
}
