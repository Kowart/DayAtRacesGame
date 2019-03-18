using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DzienNaWyscigach
{
    public class Greyhound
    {
        public int StartingPosition; //miejsce gdzie rozpoczyna się picturebox
        public int RacetrackLength; //długość trasy
        public PictureBox MyPictureBox = null; //mój obiekt picturebox
        public int Location = 0; //moje położenie na torze wyścigowym
        public Random MyRandom;

        

        public bool Run()
        {
            //Location = MyPictureBox.Left += MyRandom.Next(1, 5);
            Location += MyRandom.Next(1, 5);
            MyPictureBox.Left = StartingPosition + Location;
            MyPictureBox.Update();
            //StartingPosition = 0;            
            
            if (MyPictureBox.Left >= RacetrackLength)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }
        public void TakeStartingPosition()
        {            
            Location = 0;
            StartingPosition = 12;
            MyPictureBox.Left = StartingPosition + Location;
            MyPictureBox.Update();
        }
    }
}
