using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombieDestroyer
{
    public partial class HighScoresForm : Form
    {
        private List<HighScore> scores;
        private Statistic statistic;

        public HighScoresForm()
        {
            InitializeComponent();

            // Load scores from static method on main class.
            scores = ZombieDestroyer.LoadHighScores();
            statistic = Statistic.OVERALL;

            // Display scores on text area.
            UpdateView();
        }

        public void UpdateView()
        {
            // Clear the previous values before re-filling the list view.
            scoresView.Clear();
            scoresView.View = View.Details;

            // Define the three columns which the scores will be put into.
            ColumnHeader placeColumn = new ColumnHeader();
            placeColumn.Text = "Place";
            placeColumn.Width = 60;
            ColumnHeader nameColumn = new ColumnHeader();
            nameColumn.Text = "Name";
            nameColumn.Width = 195;
            ColumnHeader valueColumn = new ColumnHeader();
            valueColumn.Text = "Value";
            valueColumn.Width = 197;

            // Add these columns to the list view.
            scoresView.Columns.AddRange(new ColumnHeader[] { placeColumn, nameColumn, valueColumn });

            // Sort the scores by the currently selected statistic.
            scores.Sort(delegate (HighScore s1, HighScore s2)
            {
               return s2.GetStatistic(statistic).CompareTo(s1.GetStatistic(statistic));
            });

            // For each score, add a row to the list view.
            for (int i = 0; i < scores.Count; i++)
            {
                HighScore score = scores[i];

                scoresView.Items.Add(new ListViewItem(new string[] {
                    (i + 1).ToString(), score.GetName(), score.GetStatistic(statistic).ToString(NumberFormat(statistic))
                }));
            }
        }

        /*
         * When a button is clicked, get the statistic from the name of the button, parse it to its enum value and update the listview. 
         */

        private void onStatisticsButton_Click(object sender, EventArgs e)
        {
            Button button = (sender as Button);
            statistic = (Statistic) Enum.Parse(typeof(Statistic), button.Name);
            UpdateView();
        }

        /*
         * Determine how the statistics value should be formatted. 
         */

        private string NumberFormat(Statistic statistic)
        {
            switch (statistic)
            {
                case Statistic.OVERALL:
                case Statistic.ZOMBIES_PER_SECOND:
                    return "0.00";
                default:
                    return "0";
            }
        }
    }
}
