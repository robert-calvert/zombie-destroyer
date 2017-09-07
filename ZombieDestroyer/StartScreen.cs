using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombieDestroyer
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                ZombieDestroyer game = new ZombieDestroyer(nameInput.Text);
                Hide();
                game.ShowDialog();
            }
        }

        private void highScoresButton_Click(object sender, EventArgs e)
        {
            HighScoresForm form = new HighScoresForm();
            Hide();
            form.ShowDialog();
        }

        private bool ValidateInput()
        {
            if (nameInput.Text == null || nameInput.Text == "")
            {
                MessageBox.Show("You must enter a name to continue!", "Invalid Input!");
                return false;
            }

            if (Regex.IsMatch(nameInput.Text, @"^\d+$"))
            {
                MessageBox.Show("Your name cannot be a number!", "Invalid Input!");
                return false;
            }

            return true;
        }
    }
}
