using System;
using System.Drawing;
using System.Windows.Forms;

namespace Assignment2_Graphs
{
    public partial class PieChartControl : UserControl
    {
        // Data property to hold the pie slices
        public float[] PieData { get; set; }

        public PieChartControl()
        {
            InitializeComponent();
            PieData = new float[] { };  // Initialize with empty data
            InitializeUserInput(); // Initialize input controls
        }

        private TextBox inputTextBox;
        private Button submitButton;
        private Label instructionLabel;

        private void InitializeUserInput()
        {
            // Label to tell the user what to input
            instructionLabel = new Label
            {
                Text = "Enter data for the pie chart (comma separated values):",
                Location = new Point(10, 420), // Positioning below the pie chart
                AutoSize = true
            };
            this.Controls.Add(instructionLabel);

            // Textbox to input pie data
            inputTextBox = new TextBox
            {
                Location = new Point(10, 440), // Positioning below the instruction label
                Width = 300
            };
            this.Controls.Add(inputTextBox);

            // Button to submit the data
            submitButton = new Button
            {
                Text = "Generate Pie Chart",
                Location = new Point(320, 440), // Positioning to the right of the text box
                Width = 150
            };
            submitButton.Click += SubmitButton_Click;
            this.Controls.Add(submitButton);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Parse the user input to create PieData
            string[] input = inputTextBox.Text.Split(',');
            try
            {
                PieData = Array.ConvertAll(input, s => float.Parse(s.Trim()));
                this.Invalidate();  // Redraw the pie chart with the new data
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input! Please enter numeric values separated by commas.");
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (PieData == null || PieData.Length == 0)
                return;

            Graphics g = e.Graphics;
            float total = 0;

            // Calculate total of pie data
            foreach (var value in PieData)
            {
                total += value;
            }

            // Set the drawing position and size
            Rectangle pieRectangle = new Rectangle(10, 10, Width - 200, Height - 20);  // Reduced width for space for the legend

            float startAngle = 0;
            Random rand = new Random();

            // Draw the pie chart and add percentage labels on the slices
            for (int i = 0; i < PieData.Length; i++)
            {
                float sweepAngle = (PieData[i] / total) * 360;
                Brush pieBrush = new SolidBrush(Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)));
                g.FillPie(pieBrush, pieRectangle, startAngle, sweepAngle);

                // Calculate the percentage of the slice
                float percentage = (PieData[i] / total) * 100;

                // Find the center point of the slice to place the text
                float textAngle = startAngle + sweepAngle / 2;
                PointF textPosition = GetSliceCenter(pieRectangle, textAngle);

                // Draw the percentage text on the slice, ensuring it stays within bounds
                string percentageText = $"{percentage:0.0}%";
                SizeF textSize = g.MeasureString(percentageText, Font);

                // Ensure the text stays within the slice's area by adjusting if necessary
                float maxWidth = pieRectangle.Width / 3;
                float maxHeight = pieRectangle.Height / 3;

                if (textSize.Width > maxWidth || textSize.Height > maxHeight)
                {
                    // Scale text if too large
                    textSize = new SizeF(maxWidth, maxHeight);
                }

                PointF adjustedPosition = new PointF(
                    textPosition.X - textSize.Width / 2,
                    textPosition.Y - textSize.Height / 2);

                g.DrawString(percentageText, Font, Brushes.White, adjustedPosition);

                startAngle += sweepAngle;
            }

            // Draw the border for the pie chart
            g.DrawEllipse(Pens.Black, pieRectangle);

            // Draw the legend
            float legendX = Width - 160;  // Positioned to the right of the pie chart
            float legendY = 20;
            float legendBoxSize = 20;  // Size of each legend box
            float verticalSpacing = 30;  // Spacing between legend items

            for (int i = 0; i < PieData.Length; i++)
            {
                Brush sliceBrush = new SolidBrush(Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)));  // Random color for each slice
                g.FillRectangle(sliceBrush, legendX, legendY, legendBoxSize, legendBoxSize);  // Color block

                // Calculate percentage for legend
                float percentage = (PieData[i] / total) * 100;
                g.DrawString($"Slice {i + 1}: {PieData[i]} ({percentage:0.0}%)", Font, Brushes.Black, legendX + legendBoxSize + 5, legendY);  // Label with percentage
                legendY += verticalSpacing;  // Move the next legend item down
            }
        }

        // Helper method to calculate the center of a slice for placing text
        private PointF GetSliceCenter(Rectangle rect, float angle)
        {
            float radiusX = rect.Width / 2;
            float radiusY = rect.Height / 2;
            float centerX = rect.X + radiusX;
            float centerY = rect.Y + radiusY;

            // Convert the angle to radians
            double radians = (Math.PI / 180) * angle;

            // Calculate the x and y position of the center of the slice
            float x = centerX + (float)(radiusX * Math.Cos(radians));
            float y = centerY + (float)(radiusY * Math.Sin(radians));

            return new PointF(x, y);
        }

        // Method to initialize the components
        private void InitializeComponent()
        {
            this.Name = "PieChartControl";
            this.Size = new Size(500, 500); // Default size of the pie chart control
        }

        // Method to reset the chart and clear the data
        public void ResetChart()
        {
            PieData = new float[] { };  // Clear the data
            inputTextBox.Clear();  // Clear the input field
            this.Invalidate();  // Redraw the pie chart to show the empty state
        }
    }
}
