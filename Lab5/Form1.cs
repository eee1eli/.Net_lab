using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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
            Color color = Color.FromArgb((50 + n * 20) % 256, (100 + n * 30) % 256, (150 + n * 40) % 256);

            hexagons.Add(new HexWasher(side, center, color));
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var hex in hexagons) hex.Draw(e.Graphics);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<HexWasher>));
            using (FileStream fs = new FileStream("data.xml", FileMode.Create))
            {
                xmlSer.Serialize(fs, hexagons);
            }
            MessageBox.Show("Збережено в XML!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists("data.xml"))
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(List<HexWasher>));
                using (FileStream fs = new FileStream("data.xml", FileMode.Open))
                {
                    hexagons = (List<HexWasher>)xmlSer.Deserialize(fs);
                    // Оновлюємо статичний лічильник, щоб нові фігури йшли далі за списком
                    HexWasher.Count = hexagons.Count;
                }
                this.Invalidate();
                MessageBox.Show("Дані відновлено!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Type type = typeof(HexWasher);

            // Використовуємо StringBuilder для накопичення тексту
            System.Text.StringBuilder info = new System.Text.StringBuilder();

            info.AppendLine($"--- Аналіз класу: {type.Name} ---");
            info.AppendLine($"Повна назва: {type.FullName}");
            info.AppendLine();

            info.AppendLine("ВЛАСТИВОСТІ (Properties):");
            PropertyInfo[] props = type.GetProperties();
            foreach (var prop in props)
            {
                info.AppendLine($" • {prop.PropertyType.Name} {prop.Name}");
            }
            info.AppendLine();

            info.AppendLine("МЕТОДИ (що ви оголосили):");
            // Беремо лише методи, які написані вами (DeclaredOnly)
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var method in methods)
            {
                info.AppendLine($" • {method.ReturnType.Name} {method.Name}()");
            }

            // Виводимо все у велике вікно
            MessageBox.Show(info.ToString(), "Результат рефлексії");
        }
    }
}