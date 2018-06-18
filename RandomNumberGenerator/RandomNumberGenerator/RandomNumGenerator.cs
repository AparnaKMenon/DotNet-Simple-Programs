using System;
using System.Windows.Forms;

namespace RandomNumberGenerator
{
    public partial class RandomNumGeneratorUI : Form
    {
        public RandomNumGeneratorUI()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int low = 1;
            int high = 52;
            int randomNum = RandomNumber.generateRandomNum(low, high);

        }


    }
}
