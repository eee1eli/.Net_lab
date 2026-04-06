using System;
using System.Drawing;
using System.Xml.Serialization;

namespace HexagonApp
{
    [Serializable] // Потрібно для бінарної серіалізації
    public class HexWasher
    {
        public static int Count = 0;

        // Властивості (XML серіалізація любить public get/set)
        public float SideLength { get; set; }
        public PointF Center { get; set; }
        public int Index { get; set; }

        [XmlIgnore] // XML не вміє працювати з Color напряму
        public Color Color { get; set; }

        // Допоміжна властивість для збереження кольору в XML
        [XmlElement("HexColor")]
        public int ColorAsArgb
        {
            get => Color.ToArgb();
            set => Color = Color.FromArgb(value);
        }

        public HexWasher()
        {
            Count++;
            Index = Count;
        }

        public HexWasher(float a, PointF center, Color color)
        {
            SideLength = a;
            Center = center;
            Color = color;
            Count++;
            Index = Count;
        }

        public PointF[] GetPoints()
        {
            PointF[] points = new PointF[6];
            double angle = Math.PI / 3;
            for (int i = 0; i < 6; i++)
            {
                points[i] = new PointF(
                    Center.X + SideLength * (float)Math.Cos(angle * i),
                    Center.Y + SideLength * (float)Math.Sin(angle * i)
                );
            }
            return points;
        }

        public void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color, 2))
            {
                g.DrawPolygon(pen, GetPoints());
            }
        }
    }
}