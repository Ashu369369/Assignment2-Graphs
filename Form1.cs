using System;
using System.Windows.Forms;

namespace Assignment2_Graphs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Event for the "Draw Graph" button
        private void drawButton_Click(object sender, EventArgs e)
        {
            try
            {
                string input = inputData.Text;
                string[] dataStrings = input.Split(',');
                float[] pieData = new float[dataStrings.Length];

                for (int i = 0; i < dataStrings.Length; i++)
                {
                    pieData[i] = float.Parse(dataStrings[i].Trim());
                }

                // Set the pie data for the custom control
                pieChartControl.PieData = pieData;
                pieChartControl.Invalidate();  // Refresh the control to redraw the pie chart
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input: " + ex.Message);
            }
        }
    }
}
