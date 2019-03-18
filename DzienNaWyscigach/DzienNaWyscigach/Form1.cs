using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DzienNaWyscigach
{
    public partial class Form1 : Form
    {

        Random Randomizer = new Random();
        Greyhound[] GreyhoundArray = new Greyhound[4];
        Guy[] GuyArray = new Guy[3];
        
        
        

        public Form1()
        {
            InitializeComponent();
            minimumBetLabel.Text = "Minimum bet: " + numericUpDown1.Value;

            GuyArray[0] = new Guy()
            {
                Name = "Joe",
                Cash = 50,
                MyBet = null,
                MyLabel = joeBetLabel,
                MyRadioButton = joeRadioButton,             

            };
            GuyArray[1] = new Guy()
            {
                Name = "Bob",
                Cash = 75,
                MyBet = null,
                MyLabel = bobBetLabel,
                MyRadioButton = bobRadioButton,

            };
            GuyArray[2] = new Guy()
            {
                Name = "Al",
                Cash = 45,
                MyBet = null,
                MyLabel = alBetLabel,
                MyRadioButton = alRadioButton,

            };
            for (int i = 0; i < 3; i++)
            {
                GuyArray[i].ClearBet();
                GuyArray[i].UpdateLabels();
            }
            
        }
        

        
        private void button1_Click(object sender, EventArgs e)
        {
                GreyhoundArray[0] = new Greyhound() {
                MyPictureBox = pictureBox1,
                StartingPosition = pictureBox1.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox1.Width - 60,
                MyRandom = Randomizer,
                
            };
            GreyhoundArray[1] = new Greyhound()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox2.Width - 60,
                MyRandom = Randomizer,
                
            };
            GreyhoundArray[2] = new Greyhound()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox3.Width - 60,
                MyRandom = Randomizer,
                
            };
            GreyhoundArray[3] = new Greyhound()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox4.Width - 60,
                MyRandom = Randomizer,
                
            };

            for (int i = 0; i < 4; i++)
            {
                GreyhoundArray[i].TakeStartingPosition();
            }
           timer1.Start();
           bettingParlor.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {                
                if (GreyhoundArray[i].Run())
                {                    
                    timer1.Stop();
                    bettingParlor.Enabled = true;
                    int winningDog = i + 1;

                    DialogResult result = MessageBox.Show("Dog #" + winningDog.ToString() + " won", "We've got a winner ", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {

                        for (int n = 0; n < 4; n++)
                        {
                            GreyhoundArray[n].TakeStartingPosition();                            
                        }
                        for (int m = 0; m < 3; m++)
                        {
                            GuyArray[m].Collect(winningDog);                            
                        }
                        
                    }

                }
            }          
            
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = GuyArray[0].Name;           
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = GuyArray[1].Name;
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = GuyArray[2].Name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked == true)
            {
                if (!GuyArray[0].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    MessageBox.Show("Not enough money");
                    GuyArray[0].ClearBet();
                }
                
            }
            if (bobRadioButton.Checked == true)
            {
                if (!GuyArray[1].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    MessageBox.Show("Not enough money");
                    GuyArray[1].ClearBet();
                }
                
            }
            if (alRadioButton.Checked == true)
            {
                if (!GuyArray[2].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    MessageBox.Show("Not enough money");
                    GuyArray[2].ClearBet();
                }
                
            }
            
            
        }
    }
}
