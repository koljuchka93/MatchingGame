using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            AssignIconsToSquares();
        }

        // Use this Random object to choose random icons for the squares
        Random random = new Random();

        // Each of these letters is an interesting icon in the Webdings font, and each icon appears twice in this list
        List<string> icons = new List<string>()
        {
        "!", "!", "N", "N", ",", ",", "k", "k",
        "b", "b", "v", "v", "w", "w", "z", "z"
        };

        /// Assign each icon from the list of icons to a random square
        private void AssignIconsToSquares()
        {
            // The TableLayoutPanel has 16 labels, and the icon list has 16 icons,
            // so an icon is pulled at random from the list and added to each label
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label ?? new Label();
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (sender is Label firstClicked)
            {
                // If the clicked label is black, the player clicked
                // an icon that's already been revealed -- ignore the click
                if (firstClicked.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                    firstClicked = (Label)sender;
                firstClicked.ForeColor = Color.Black;

                return;
            }
        }


    }

}
