using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapGenerator
{
    public partial class MapGenerator : Form
    {
        Graphics formGraphics;

        public MapGenerator()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            formGraphics = CreateGraphics();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            formGraphics.Dispose();
        }

        public void DrawMap()
        {

        }

        private void mapTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch((String)mapTypeComboBox.SelectedItem)
            {
                case "Cave":
                    CaveSettings.GenerateUISettings(this);
                    break;
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            //formGraphics.Clear(Color.Black);
            //formGraphics.Clear(Color.Blue);


            var amountOfSteps = (Controls.Find("amountOfStepsUpDown0", true).FirstOrDefault() as NumericUpDown).Value;
            var birthChance = (Controls.Find("birthChanceUpDown", true).FirstOrDefault() as NumericUpDown).Value;
            var birthLimit = (Controls.Find("birthLimitUpDown", true).FirstOrDefault() as NumericUpDown).Value;
            var deathLimit = (Controls.Find("deathLimitUpDown", true).FirstOrDefault() as NumericUpDown).Value;
            var squareSize = (int)squareSizeNumericUpDown.Value;
            Cave cave = new Cave((int)widthNumericUpDown.Value, (int)heightNumericUpDown.Value, (int)birthChance, (int)birthLimit, (int)deathLimit, (int)amountOfSteps);
            var squares = cave.GenerateMap();

            using (Form form = new Form())
            {
                form.Text = "Cave";
                form.Width = (int)widthNumericUpDown.Value * squareSize + 30;
                form.Height = (int)heightNumericUpDown.Value * squareSize + 30;
                form.Paint += (sender1, e1) =>
                {
                    for (int x = 0; x < squares.GetLength(0); x++)
                    {
                        for (int y = 0; y < squares.GetLength(1); y++)
                        {
                            if (squares[x, y])
                            {
                                e1.Graphics.FillRectangle(new SolidBrush(Color.Black),  new Rectangle(x * squareSize, y * squareSize, squareSize, squareSize));
                            }
                            else
                            {
                                e1.Graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), new Rectangle(x * squareSize, y * squareSize, squareSize, squareSize));
                            }
                        }

                    }
                };
                form.ShowDialog();
            }

            //var blackBrush = new SolidBrush(Color.Black);
            //var blueBrush = new SolidBrush(Color.Blue);
        }
    }
}
