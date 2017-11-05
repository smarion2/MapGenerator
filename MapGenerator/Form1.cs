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
        public MapGenerator()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e); 
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
            var amountOfSteps = (Controls.Find("amountOfStepsUpDown0", true).FirstOrDefault() as NumericUpDown).Value;
            var birthChance = (Controls.Find("birthChanceUpDown", true).FirstOrDefault() as NumericUpDown).Value;
            var birthLimit = (Controls.Find("birthLimitUpDown", true).FirstOrDefault() as NumericUpDown).Value;
            var deathLimit = (Controls.Find("deathLimitUpDown", true).FirstOrDefault() as NumericUpDown).Value;

            Cave cave = new Cave((int)widthNumericUpDown.Value, (int)heightNumericUpDown.Value, (int)birthChance, (int)birthLimit, (int)deathLimit, (int)amountOfSteps);
            var squares = cave.GenerateMap();

            Graphics formGraphics;
            formGraphics = CreateGraphics();
            var blackBrush = new SolidBrush(Color.Black);
            var blueBrush = new SolidBrush(Color.Blue);
            for (int x = 0; x < squares.GetLength(0); x++)
            {
                for (int y = 0; y < squares.GetLength(1); y++)
                {
                    if (squares[x, y])
                    {
                        formGraphics.FillRectangle(blueBrush, new Rectangle(x * 5, y * 5, 5, 5));
                    }
                    else
                    {
                        formGraphics.FillRectangle(blackBrush, new Rectangle(x * 5, y * 5, 5, 5));
                    }
                }

            }
            formGraphics.Dispose();
        }
    }
}
