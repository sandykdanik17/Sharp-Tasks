using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab7
{
    public class FormTask1 : Form
    {
        private PictureBox canvas;
        private bool isDrawing = false;
        private Point startPoint;
        private Pen currentPen = new Pen(Color.Black, 2);

        public FormTask1()
        {
            this.Text = "Завдання 1.2 - Малювання";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;

            // Панель керування зверху
            FlowLayoutPanel panel = new FlowLayoutPanel() { Dock = DockStyle.Top, Height = 40, BackColor = Color.LightGray };
            Button btnBlack = new Button() { BackColor = Color.Black, Width = 40, Height = 30 };
            Button btnRed = new Button() { BackColor = Color.Red, Width = 40, Height = 30 };
            Button btnGreen = new Button() { BackColor = Color.Green, Width = 40, Height = 30 };
            Button btnBlue = new Button() { BackColor = Color.Blue, Width = 40, Height = 30 };
            Button btnClear = new Button() { Text = "Нова картинка", Width = 120, Height = 30 };

            // Зміна кольорів
            btnBlack.Click += (s, e) => currentPen.Color = Color.Black;
            btnRed.Click += (s, e) => currentPen.Color = Color.Red;
            btnGreen.Click += (s, e) => currentPen.Color = Color.Green;
            btnBlue.Click += (s, e) => currentPen.Color = Color.Blue;

            // Очищення картинки
            btnClear.Click += (s, e) => {
                canvas.Image = new Bitmap(canvas.Width, canvas.Height);
                canvas.Invalidate();
            };

            panel.Controls.AddRange(new Control[] { btnBlack, btnRed, btnGreen, btnBlue, btnClear });
            this.Controls.Add(panel);

            // Полотно для малювання
            canvas = new PictureBox() { Dock = DockStyle.Fill, BackColor = Color.White };
            canvas.Image = new Bitmap(1000, 800);

            // Логіка малювання
            canvas.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left) { isDrawing = true; startPoint = e.Location; }
            };
            canvas.MouseMove += (s, e) => {
                if (isDrawing)
                {
                    using (Graphics g = Graphics.FromImage(canvas.Image))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        g.DrawLine(currentPen, startPoint, e.Location);
                    }
                    startPoint = e.Location;
                    canvas.Invalidate();
                }
            };
            canvas.MouseUp += (s, e) => isDrawing = false;

            this.Controls.Add(canvas);
            canvas.BringToFront();
        }
    }
}