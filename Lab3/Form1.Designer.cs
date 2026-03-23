namespace HexagonApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Поле для кнопки
        private System.Windows.Forms.Button button1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12); // Позиція кнопки
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 40); // Розмір кнопки
            this.button1.TabIndex = 0;
            this.button1.Text = "Створити Шайбу";
            this.button1.UseVisualStyleBackColor = true;
            // Зв'язуємо подію натискання з твоїм методом у Form1.cs
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1); // Додаємо кнопку на форму
            this.Name = "Form1";
            this.Text = "Лабораторна: Фігура Шайба";
            this.ResumeLayout(false);
        }

        #endregion
    }
}