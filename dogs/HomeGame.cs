namespace dogs
{
    public partial class HomeGame : Form
    {
        public HomeGame()
        {
            InitializeComponent();
        }

        private void MakeTeam_Click(object sender, EventArgs e)
        {
            bool create = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "MakeTeam")
                {
                    this.Hide();
                    form.Visible = true;
                    create = true;
                    break;
                }
            }

            if (create == false)
            {
                MakeTeam makeTeam = new MakeTeam();
                this.Hide();
                makeTeam.Show();
            }
        }

        private void GoToRace_Click(object sender, EventArgs e)
        {
            bool create = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "RaceGame")
                {
                    this.Hide();
                    form.Visible = true;
                    create = true;
                    break;
                }
            }

            if (create == false)
            {
                RaceGame raceGame = new RaceGame(1);
                this.Hide();
                raceGame.Show();
            }
        }
    }
}