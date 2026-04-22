using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab7
{
    public class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            // Налаштування вікна меню
            this.Text = "Лабораторна робота №7";
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            // Створюємо кнопки програмно
            Button btnTask1 = new Button() { Text = "Завдання 1 (Графічний редактор)", Location = new Point(50, 30), Size = new Size(280, 60), Font = new Font("Arial", 10, FontStyle.Bold) };
            Button btnTask2 = new Button() { Text = "Завдання 2 (Поворот зображення 45°)", Location = new Point(50, 110), Size = new Size(280, 60), Font = new Font("Arial", 10, FontStyle.Bold) };
            Button btnTask3 = new Button() { Text = "Завдання 3 (Фігури вписані в коло)", Location = new Point(50, 190), Size = new Size(280, 60), Font = new Font("Arial", 10, FontStyle.Bold) };

            // Додаємо події кліку
            btnTask1.Click += (s, e) => new FormTask1().ShowDialog();
            btnTask2.Click += (s, e) => new FormTask2().ShowDialog();
            btnTask3.Click += (s, e) => new FormTask3().ShowDialog();

            // Додаємо кнопки на форму
            this.Controls.Add(btnTask1);
            this.Controls.Add(btnTask2);
            this.Controls.Add(btnTask3);
        }
    }
}