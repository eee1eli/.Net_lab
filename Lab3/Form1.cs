using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HexagonApp
{
    public partial class Form1 : Form
    {
        private List<HexWasher> hexagons = new List<HexWasher>();

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = HexWasher.Count + 1;

            float side = 20 + n * 5;
            PointF center = new PointF(80 + n * 40, 150);
            int r = (50 + n * 20) % 256;
            int g = (100 + n * 30) % 256;
            int b = (150 + n * 40) % 256;

            Color color = Color.FromArgb(r, g, b);

            HexWasher hex = new HexWasher(side, center, color);
            hexagons.Add(hex);

            this.Invalidate(); // перемалювати форму
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (var hex in hexagons)
            {
                hex.Draw(e.Graphics);
            }
        }
    }
}