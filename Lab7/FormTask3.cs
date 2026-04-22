using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lab7
{
    public abstract class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }
        public Color DrawColor { get; set; }

        public Figure(int x, int y, int radius, Color color) { X = x; Y = y; Radius = radius; DrawColor = color; }
        public virtual void Move(int dx, int dy) { X += dx; Y += dy; }
        public abstract void Draw(Graphics g);
        protected void DrawCircle(Graphics g, Pen pen) { g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2); }
    }

    public class TriangleInCircle : Figure
    {
        public TriangleInCircle(int x, int y, int r, Color c) : base(x, y, r, c) { }
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(DrawColor, 2))
            {
                DrawCircle(g, pen);
                PointF[] pts = new PointF[3];
                for (int i = 0; i < 3; i++)
                {
                    double angle = -Math.PI / 2 + (2 * Math.PI * i / 3);
                    pts[i] = new PointF((float)(X + Radius * Math.Cos(angle)), (float)(Y + Radius * Math.Sin(angle)));
                }
                g.DrawPolygon(pen, pts);
            }
        }
    }

    public class RectangleInCircle : Figure
    {
        public RectangleInCircle(int x, int y, int r, Color c) : base(x, y, r, c) { }
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(DrawColor, 2))
            {
                DrawCircle(g, pen);
                PointF[] pts = new PointF[4];
                for (int i = 0; i < 4; i++)
                {
                    double angle = Math.PI / 4 + (Math.PI / 2 * i);
                    pts[i] = new PointF((float)(X + Radius * Math.Cos(angle)), (float)(Y + Radius * Math.Sin(angle)));
                }
                g.DrawPolygon(pen, pts);
            }
        }
    }

    public class PentagonInCircle : Figure
    {
        public PentagonInCircle(int x, int y, int r, Color c) : base(x, y, r, c) { }
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(DrawColor, 2))
            {
                DrawCircle(g, pen);
                PointF[] pts = new PointF[5];
                for (int i = 0; i < 5; i++)
                {
                    double angle = -Math.PI / 2 + (2 * Math.PI * i / 5);
                    pts[i] = new PointF((float)(X + Radius * Math.Cos(angle)), (float)(Y + Radius * Math.Sin(angle)));
                }
                g.DrawPolygon(pen, pts);
            }
        }
    }


    public class FormTask3 : Form
    {
        private PictureBox canvas;
        private ComboBox cmbType;
        private NumericUpDown numRadius;
        private Button btnColor;
        private List<Figure> figuresList = new List<Figure>();
        private Color selectedColor = Color.Blue;
        private Random rnd = new Random();

        public FormTask3()
        {
            this.Text = "Завдання 3.17 - Фігури в колі";
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterParent;

            // Панель керування
            FlowLayoutPanel panel = new FlowLayoutPanel() { Dock = DockStyle.Top, Height = 50, Padding = new Padding(10) };

            cmbType = new ComboBox() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 150 };
            cmbType.Items.AddRange(new string[] { "Трикутник", "Прямокутник", "П'ятикутник" });
            cmbType.SelectedIndex = 0;

            numRadius = new NumericUpDown() { Minimum = 10, Maximum = 200, Value = 50, Width = 70 };

            btnColor = new Button() { Text = "Колір", BackColor = selectedColor, ForeColor = Color.White };
            btnColor.Click += (s, e) => {
                using (ColorDialog cd = new ColorDialog())
                {
                    if (cd.ShowDialog() == DialogResult.OK) { selectedColor = cd.Color; btnColor.BackColor = selectedColor; }
                }
            };

            Button btnAdd = new Button() { Text = "Намалювати випадково", Width = 150 };
            btnAdd.Click += BtnAdd_Click;

            Button btnClear = new Button() { Text = "Очистити", Width = 100 };
            btnClear.Click += (s, e) => { figuresList.Clear(); canvas.Invalidate(); };

            panel.Controls.AddRange(new Control[] { new Label() { Text = "Фігура:", Width = 50, TextAlign = ContentAlignment.MiddleRight }, cmbType,
                                                    new Label() { Text = "Радіус:", Width = 50, TextAlign = ContentAlignment.MiddleRight }, numRadius,
                                                    btnColor, btnAdd, btnClear });
            this.Controls.Add(panel);

            // Полотно
            canvas = new PictureBox() { Dock = DockStyle.Fill, BackColor = Color.White };
            canvas.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                foreach (Figure fig in figuresList) fig.Draw(e.Graphics); 
            };
            this.Controls.Add(canvas);
            canvas.BringToFront();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            int r = (int)numRadius.Value;
            int maxX = canvas.Width - r;
            int maxY = canvas.Height - r;

            if (maxX <= r || maxY <= r) { MessageBox.Show("Радіус занадто великий!"); return; }

            int rx = rnd.Next(r, maxX);
            int ry = rnd.Next(r, maxY);

            Figure fig = null;
            if (cmbType.SelectedIndex == 0) fig = new TriangleInCircle(rx, ry, r, selectedColor);
            else if (cmbType.SelectedIndex == 1) fig = new RectangleInCircle(rx, ry, r, selectedColor);
            else if (cmbType.SelectedIndex == 2) fig = new PentagonInCircle(rx, ry, r, selectedColor);

            figuresList.Add(fig);
            canvas.Invalidate(); 
        }
    }
}