using System;
using System.Windows.Forms;

namespace IntegralApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double RightRectangles(Func<double, double> f, double a, double b, int n)
        {
            double h = (b - a) / n;
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                double x = a + i * h;
                sum += f(x);
            }
            return sum * h;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(txtA.Text);
                double b = double.Parse(txtB.Text);
                int n = int.Parse(txtN.Text);

                if (n <= 0)
                {
                    MessageBox.Show("n має бути > 0");
                    return;
                }

                if (a == 0)
                {
                    MessageBox.Show("a не може бути 0");
                    return;
                }

                Func<double, double> f1 = x => Math.Cos(x) / x;
                Func<double, double> f2 = x => Math.Sin(x) / Math.Abs(x);
                Func<double, double> f3 = x => Math.Pow(x, 1.0 / 3.0);

                double r1 = RightRectangles(f1, a, b, n);
                double r2 = RightRectangles(f2, a, b, n);
                double r3 = RightRectangles(f3, a, b, n);

                Func<double, double> f = x => x * x;
                double numeric = RightRectangles(f, a, b, n);
                double exact = (Math.Pow(b, 3) - Math.Pow(a, 3)) / 3;

                lblResult.Text =
                    $"cos(x)/x = {r1}\n" +
                    $"sin(x)/|x| = {r2}\n" +
                    $"∛x = {r3}\n\n" +
                    $"x²:\nNumeric = {numeric}\nExact = {exact}\nError = {Math.Abs(numeric - exact)}";
            }
            catch
            {
                MessageBox.Show("Невірний ввід");
            }
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            lblResult.Text = "Ігор Бурмака";
        }
    }
}
