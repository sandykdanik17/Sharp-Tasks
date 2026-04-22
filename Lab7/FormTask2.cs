using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lab7
{
    public class FormTask2 : Form
    {
        private PictureBox pictureBox1;
        private Image originalImage;
        private int currentAngle = 0;

        public FormTask2()
        {
            this.Text = "Завдання 2.7 - Поворот на 45°";
            this.Size = new Size(800, 650);
            this.StartPosition = FormStartPosition.CenterParent;

            // Панель з кнопками
            FlowLayoutPanel panel = new FlowLayoutPanel() { Dock = DockStyle.Top, Height = 50, Padding = new Padding(10) };
            Button btnLoad = new Button() { Text = "Завантажити", Width = 120, Height = 30 };
            Button btnRotate = new Button() { Text = "Повернути на 45°", Width = 150, Height = 30 };
            Button btnSave = new Button() { Text = "Зберегти", Width = 120, Height = 30 };

            panel.Controls.AddRange(new Control[] { btnLoad, btnRotate, btnSave });
            this.Controls.Add(panel);

            // PictureBox для картинки
            pictureBox1 = new PictureBox() { Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom, BackColor = Color.DarkGray };
            this.Controls.Add(pictureBox1);
            pictureBox1.BringToFront();

            // Логіка кнопок
            btnLoad.Click += BtnLoad_Click;
            btnRotate.Click += BtnRotate_Click;
            btnSave.Click += BtnSave_Click;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Images|*.jpg;*.png;*.bmp" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    originalImage = Image.FromFile(ofd.FileName);
                    currentAngle = 0;
                    pictureBox1.Image = (Image)originalImage.Clone();
                }
            }
        }

        private void BtnRotate_Click(object sender, EventArgs e)
        {
            if (originalImage == null) { MessageBox.Show("Завантажте зображення!"); return; }

            currentAngle = (currentAngle + 45) % 360;

            // Математика повороту без обрізання кутів
            double angleRadians = currentAngle * Math.PI / 180d;
            double cos = Math.Abs(Math.Cos(angleRadians));
            double sin = Math.Abs(Math.Sin(angleRadians));

            int newWidth = (int)(originalImage.Width * cos + originalImage.Height * sin);
            int newHeight = (int)(originalImage.Width * sin + originalImage.Height * cos);

            Bitmap rotatedBitmap = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(rotatedBitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.TranslateTransform((float)newWidth / 2, (float)newHeight / 2);
                g.RotateTransform(currentAngle);
                g.TranslateTransform(-(float)originalImage.Width / 2, -(float)originalImage.Height / 2);
                g.DrawImage(originalImage, new Point(0, 0));
            }
            pictureBox1.Image = rotatedBitmap;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PNG Image|*.png" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(sfd.FileName);
                    MessageBox.Show("Збережено!");
                }
            }
        }
    }
}