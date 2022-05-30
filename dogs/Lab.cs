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
    public partial class Lab : Form
    {
        LabClass lab = new LabClass();
        predStat pred;
        int chopTree = 2;
        public Lab(float TimeRace, float predSpeed, float predx, float predy)
        {
            InitializeComponent();
            pred = new predStat(TimeRace, predSpeed, predx, predy);
            lab.CreateMap();
        }

        private void LabPaint(object sender, PaintEventArgs e)
        {
            for (int x = 0; x < lab.width; x++)
                for (int y = 0 ; y < lab.height; y++)
                {
                    switch (lab.Map[x, y])
                    {
                        case LabClass.State.Cell:
                            DrawBox(x, y, Brushes.White, e.Graphics);
                            break;
                        case LabClass.State.Wall:
                            DrawTree(x, y, e.Graphics);
                            break;
                        case LabClass.State.Visited:
                            DrawBox(x, y, Brushes.Red, e.Graphics);
                            break;
                    }
                }
            DrawMan(lab.currentCell.X, lab.currentCell.Y, e.Graphics);
            DrawDog(lab.endCell.X, lab.endCell.Y, e.Graphics);
        }

        private void DrawBox(int x, int y, Brush br, Graphics gr)
        {
            gr.FillRectangle(br, x * lab.side, y * lab.side, lab.side, lab.side);
        }

        private void DrawTree(int x, int y, Graphics gr)
        {
            gr.DrawImage(Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\image\\Treeup.png"), x * lab.side, y * lab.side, lab.side, lab.side);
        }

        private void DrawMan(int x, int y, Graphics gr)
        {
            gr.DrawImage(Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\image\\man.png"), x * lab.side, y * lab.side, lab.side, lab.side);
        }

        private void DrawDog(int x, int y, Graphics gr)
        {
            gr.DrawImage(Image.FromFile("C:\\Users\\UserHome\\Desktop\\омгврс\\image\\hask.png"), x * lab.side, y * lab.side, lab.side, lab.side);
        }

        private void Click(object sender, EventArgs e)
        {
            if (lab.builded)
            {
                lab.CreateMap();
                lab.currentCell = new Point(1, 1);
            }
            lab.BuildMap();
            lab.CreateLab();
            lab.builded = true;
            LabPanel.Invalidate();
        }

        private void MainLoad(object sender, EventArgs e)
        {
            Click(LabPanel, new EventArgs()); ;
            CenterToScreen();
        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            lab.X = lab.currentCell.X;
            lab.Y = lab.currentCell.Y;
            switch (e.KeyChar.ToString())
            {
                case "a":
                    if (lab.Map[lab.X - 1, lab.Y] != LabClass.State.Wall)
                    {
                        TextButt.Text = "Быстрее, пока он не убежал!";
                        TextButt.BackColor = Color.PaleGreen;
                        lab.currentCell = new Point(lab.X - 1, lab.Y);
                    }
                    else if (chopTree > 0)
                    {
                        TextButt.Text = "Как хорошо, что у нас есть пила!";
                        TextButt.BackColor = Color.SlateGray;
                        lab.currentCell = new Point(lab.X - 1, lab.Y);
                        chopTree--;
                        lab.Map[lab.X - 1, lab.Y] = LabClass.State.Cell;
                    }
                    else
                    {
                        TextButt.Text = "Увы, пила сломалась, найдём другую дорогу";
                        TextButt.BackColor = Color.LightCoral;
                    }
                    break;
                case "d":
                    if (lab.Map[lab.X + 1, lab.Y] != LabClass.State.Wall)
                    {
                        TextButt.Text = "Вперёд, мы успеем";
                        TextButt.BackColor = Color.PaleGreen;
                        lab.currentCell = new Point(lab.X + 1, lab.Y);
                    }
                    else if (chopTree > 0)
                    {
                        TextButt.Text = "Как хорошо, что у нас есть пила!";
                        TextButt.BackColor = Color.SlateGray;
                        lab.currentCell = new Point(lab.X + 1, lab.Y);
                        chopTree--;
                        lab.Map[lab.X + 1, lab.Y] = LabClass.State.Cell;
                    }
                    else
                    {
                        TextButt.Text = "Увы, пила сломалась, найдём другую дорогу";
                        TextButt.BackColor = Color.LightCoral;
                    }
                    break;
                case "w":
                    if (lab.Map[lab.X, lab.Y - 1] != LabClass.State.Wall)
                    {
                        TextButt.Text = "Он скоро убежит, ускоряемся!";
                        TextButt.BackColor = Color.SlateGray;
                        lab.currentCell = new Point(lab.X, lab.Y - 1);
                    }
                    else if (chopTree > 0)
                    {
                        TextButt.Text = "Как хорошо, что у нас есть пила!";
                        TextButt.BackColor = Color.PaleGreen;
                        lab.currentCell = new Point(lab.X, lab.Y - 1);
                        chopTree--;
                        lab.Map[lab.X, lab.Y - 1] = LabClass.State.Cell;
                    }
                    else
                    {
                        TextButt.Text = "Увы, пила сломалась, найдём другую дорогу";
                        TextButt.BackColor = Color.LightCoral;
                    }
                    break;
                case "s":
                    if (lab.Map[lab.X, lab.Y + 1] != LabClass.State.Wall)
                    {
                        TextButt.Text = "Времени осталось мало, но мы справимся!";
                        TextButt.BackColor = Color.PaleGreen;
                        lab.currentCell = new Point(lab.X, lab.Y + 1);
                    }
                    else if (chopTree > 0)
                    {
                        TextButt.Text = "Как хорошо, что у нас есть пила!";
                        TextButt.BackColor = Color.PaleGreen;
                        lab.currentCell = new Point(lab.X, lab.Y + 1);
                        chopTree--;
                        lab.Map[lab.X, lab.Y + 1] = LabClass.State.Cell;
                    }
                    else
                    {
                        TextButt.Text = "Увы, пила сломалась, найдём другую дорогу";
                        TextButt.BackColor = Color.LightCoral;
                    }
                    break;
            }
            if (lab.currentCell.X == lab.endCell.X && lab.currentCell.Y == lab.endCell.Y)
            {
                LabPanel.Visible = false;
                TextButt.Text = "Ура, догнали! Возвращаемся!";
                TextButt.Enabled = true;
            }
            LabPanel.Invalidate();
        }


        private void TextButt_Click(object sender, EventArgs e)
        {
            RaceGame race = new RaceGame(pred.speed, pred.timeRace + 10, pred.x, pred.y);
            this.Hide();
            race.Show();
        }

        internal class predStat
        {
            public float speed;
            public float x;
            public float y;
            public float timeRace;

            public predStat(float TimeRace, float predSpeed, float predx, float predy)
            {
                this.timeRace = TimeRace;
                this.speed = predSpeed;
                this.x = predx;
                this.y = predy;
            }
        }
    }
}