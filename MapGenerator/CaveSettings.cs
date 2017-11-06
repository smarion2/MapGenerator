using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapGenerator
{
    public static class CaveSettings
    {
        public static void GenerateUISettings(Form form)
        {
            // int birthChance, int birthLimit, int deathLimit, int amountOfSteps = 2
            Label BirthChanceLabel = new Label()
            {
                AutoSize = true,
                Location = new System.Drawing.Point(5, 15),
                Name = "birthChanceLabel",
                Size = new System.Drawing.Size(51, 13),
                Text = "Birth Chance"
            };

            Label BirthLimitLabel = new Label()
            {
                AutoSize = true,
                Location = new System.Drawing.Point(5, 40),
                Name = "birthLimit",
                Size = new System.Drawing.Size(51, 13),
                Text = "Birth Limit"
            };

            Label DeathLimitLabel = new Label()
            {
                AutoSize = true,
                Location = new System.Drawing.Point(5, 65),
                Name = "deathLimit",
                Size = new System.Drawing.Size(51, 13),
                Text = "Death Limit"
            };

            Label AmountOfStepsLabel = new Label()
            {
                AutoSize = true,
                Location = new System.Drawing.Point(5, 90),
                Name = "amountOfSteps",
                Size = new System.Drawing.Size(61, 10),
                Text = "Steps"
            };

            NumericUpDown BirthChanceUpDown = new NumericUpDown()
            {
                Location = new System.Drawing.Point(75, 15),
                Name = "birthChanceUpDown",
                Size = new System.Drawing.Size(61, 15),
                Value = 40
            };

            NumericUpDown BirthLimitUpDown = new NumericUpDown()
            {
                Location = new System.Drawing.Point(75, 40),
                Name = "birthLimitUpDown",
                Size = new System.Drawing.Size(61, 20),
                Value = 4
            };

            NumericUpDown DeathLimitUpDown = new NumericUpDown()
            {
                Location = new System.Drawing.Point(75, 65),
                Name = "deathLimitUpDown",
                Size = new System.Drawing.Size(61, 20),
                Value = 3
            };

            NumericUpDown AmountOfStepsUpDown = new NumericUpDown()
            {
                Location = new System.Drawing.Point(75, 90),
                Name = "amountOfStepsUpDown0",
                Size = new System.Drawing.Size(61, 20),
                Value = 2
            };

            GroupBox CaveSettingsBox = new GroupBox();
            CaveSettingsBox.Size = new System.Drawing.Size(150, 135);
            CaveSettingsBox.Location = new System.Drawing.Point(150, 30);
            CaveSettingsBox.Controls.Add(BirthChanceLabel);
            CaveSettingsBox.Controls.Add(BirthLimitLabel);
            CaveSettingsBox.Controls.Add(DeathLimitLabel);
            CaveSettingsBox.Controls.Add(AmountOfStepsLabel);

            CaveSettingsBox.Controls.Add(BirthChanceUpDown);
            CaveSettingsBox.Controls.Add(BirthLimitUpDown);
            CaveSettingsBox.Controls.Add(DeathLimitUpDown);
            CaveSettingsBox.Controls.Add(AmountOfStepsUpDown);

            form.Controls.Add(CaveSettingsBox);
        }
    }
}
