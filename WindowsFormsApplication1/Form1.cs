using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        int obj = 0;
        int angle = 1;
        string name = "";
        ushort[,] dot = new ushort[17, 6];
        List<PictureBox> area = new List<PictureBox>(50); // КОЛЛЕКЦИЯ

        public Form1()
        {
            InitializeComponent();
           
            this.MouseWheel += new MouseEventHandler(MouseWheelHandler);
           //// К О С Т И Н А      Х У Й Н Я///////////////////// 
            //PictureBox[] area = new PictureBox[25];
           // for (int i = 0; i < 25; i++) area[i] = new PictureBox();
            /////////////////////////////////////////////

            for (int i = 0; i < 50; i++) // КОЛЛЕКЦИЯ
            {
                PictureBox area = new PictureBox();
                area.Name = i.ToString();
                area.Size = new Size(233, 20);
            }
        }

       // private PictureBox[] area; // К О С Т И Н А     Х У Й Н Я 


        // ЗДЕСЬ ВСЕ НОРМ РАБОТАЕТ /////////////////
        private void Form1_Shown(Object sender, EventArgs e)
        {
            // строим точки
            Graphics lin;
            lin = CreateGraphics();
            Pen blackPen = new Pen(Color.FromArgb(150, 0, 0, 0), 2);
            for (int i = 130; i < 600; i += 120)
            {
                for (int j = 330; j < 700; j += 120) lin.DrawEllipse(blackPen, j, i, 2, 2);
            }
            // строим линии
            lin.DrawLine(blackPen, 270, 70, 270, 560);
            lin.DrawLine(blackPen, 270, 560, 760, 560);
            lin.DrawLine(blackPen, 760, 560, 760, 70);
            lin.DrawLine(blackPen, 760, 70, 270, 70);
            for (int i = 1; i < 17; i++) richTextBox1.Text += String.Format("{0} {1} {2}", i, Convert.ToString(dot[i, 1]), Convert.ToString(dot[i, 2]) + "\n");

        }

        // ЗДЕСЬ ВСЕ НОРМ РАБОТАЕТ /////////////////
        private void Form1_Load(object sender, EventArgs e)
        {
            // Заполняем координаты x, y для каждой точки 
            ushort x = 330;
            ushort y = 130;
            int l = 0;
            for (int i = 1; i < 17; i++)
            {
                l++;
                if (l > 4)
                {
                    l = 1;
                    x = 330;
                    y += 120;
                }
                dot[i, 1] = x;
                dot[i, 2] = y;
                x += 120;
            }
        }

        // ЗДЕСЬ ВСЕ НОРМ РАБОТАЕТ /////////////////
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            angle = 1;
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    name = "Амперметр";
                    pictureBox1.Load("Амперметр1.jpg");
                    obj = 1;
                    break;
                case 1:
                    name = "Вольтметр";
                    pictureBox1.Load("Вольтметр1.jpg");
                    obj = 2;
                    break;
                case 2:
                    name = "Резистор";
                    pictureBox1.Load("Резистор1.jpg");
                    obj = 3;
                    break;
                case 3:
                    name = "Реостат";
                    pictureBox1.Load("Реостат1.jpg");
                    obj = 4;
                    break;
                case 4:
                    name = "Реостат";
                    pictureBox1.Load("Реостат1.jpg");
                    obj = 4;
                    break;
                case 5:
                    name = "Реостат";
                    pictureBox1.Load("Реостат1.jpg");
                    obj = 4;
                    break;
                case 6:
                    name = "Амперметр";
                    pictureBox1.Load("Амперметр1.jpg");
                    obj = 1;
                    break;
                case 7:
                    name = "Амперметр";
                    pictureBox1.Load("Амперметр1.jpg");
                    obj = 1;
                    break;
                case 8:
                    name = "Амперметр";
                    pictureBox1.Load("Амперметр1.jpg");
                    obj = 1;
                    break;
                case 9:
                    name = "Амперметр";
                    pictureBox1.Load("Амперметр1.jpg");
                    obj = 1;
                    break;
                case 10:
                    name = "Амперметр";
                    pictureBox1.Load("Амперметр1.jpg");
                    obj = 1;
                    break;
                case 11:
                    name = "Амперметр";
                    pictureBox1.Load("Амперметр1.jpg");
                    obj = 1;
                    break;
                case 12:
                    name = "Амперметр";
                    pictureBox1.Load("Амперметр1.jpg");
                    obj = 1;
                    break;
            }
        }

        // ЗДЕСЬ ВСЕ НОРМ РАБОТАЕТ /////////////////
        private void MouseWheelHandler(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (obj != 0)
            {
                if (e.Delta > 0)
                {
                    switch (angle)
                    {
                        case 1:
                            angle = 2;
                            pictureBox1.Load(name + angle + ".jpg");
                            break;
                        case 2:
                            angle = 3;
                            pictureBox1.Load(name + angle + ".jpg");
                            break;
                        case 3:
                            angle = 4;
                            pictureBox1.Load(name + angle + ".jpg");
                            break;
                        case 4:
                            angle = 1;
                            pictureBox1.Load(name + angle + ".jpg");
                            break;
                    }
                }
                else
                {
                    switch (angle)
                    {
                        case 1:
                            angle = 4;
                            pictureBox1.Load(name + angle + ".jpg");
                            break;
                        case 2:
                            angle = 1;
                            pictureBox1.Load(name + angle + ".jpg");
                            break;
                        case 3:
                            angle = 2;
                            pictureBox1.Load(name + angle + ".jpg");
                            break;
                        case 4:
                            angle = 3;
                            pictureBox1.Load(name + angle + ".jpg");
                            break;
                    }
                }
            }
        }

        // ЗДЕСЬ ВСЕ НОРМ РАБОТАЕТ /////////////////
        private void listBox1_MouseLeave(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void listBox1_MouseEnter(object sender, EventArgs e)
        {
            this.ActiveControl = listBox1;
        }
        
        // СОЗДАНИЕ ДИНАМИЧЕСКИХ КАРТИНОК
        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            var pos = this.PointToClient(Cursor.Position);
            int idx = 0;
            int k = 0;
            if (e.Button == MouseButtons.Left)
            {
                textBox1.Text = String.Format("({0}, {1})", pos.X, pos.Y);
                // попадание в область
                if (obj != 0)
                {
                    if (angle == 1 || angle == 3)
                    {
                        label9.Text = "HORIZON";
                        for (int i = 1; i < 13; i++)
                        {
                            idx++;
                            if (idx > 3)
                            {
                                k++;
                                idx = 1;
                            }
                            if (Math.Abs(((dot[i + k + 1, 1] - dot[i + k, 1]) / 2) + dot[i + k, 1] - pos.X) <= 60 && Math.Abs(dot[i + k, 2] - pos.Y) <= 40)
                            {
                                label5.Text = Convert.ToString(dot[i + k, 1]);
                                label6.Text = Convert.ToString(dot[i + k + 1, 1]);
                                label4.Text = String.Format("Область {0}", i);
                                label7.Text = Convert.ToString(k);
                                label8.Text = Convert.ToString(idx);

                                PictureBox picture  = new PictureBox(); // ВМЕСТО ЭТОГО picture ДОЛЖНО БЫТЬ ЧТО-ТО ТИПО picture[i]
                                picture.Location = new Point(dot[i + k, 1] + 33, dot[i + k, 2] - 24);
                                Size size = new Size(51, 49);
                                picture.Size = size;
                                this.Controls.Add(picture);

                                for (int h = 0; h < angle + 1; h++) if (h == angle) picture.Load("Область_" + name + angle + ".jpg");

                                PictureBox line2 = new PictureBox();
                                line2.Location = new Point(dot[i + k, 1], dot[i + k, 2] - 2);
                                Size size2 = new Size(122, 6);
                                line2.Size = size2;
                                this.Controls.Add(line2);
                                line2.Load("Область_Линия1.jpg");

                                //PictureBox snd = (PictureBox)sender;
                                //int id = picture1.IndexOf(snd);
                                //this.Controls.Remove(snd);
                                //this.Controls.Add(area[i]);
                            }
                        }
                    }
                    else
                    {
                        label9.Text = "VERTICAL";
                        for (int i = 1; i < 13; i++)
                        {

                            if (Math.Abs(((dot[i + 4, 2] - dot[i, 2]) / 2) + dot[i, 2] - pos.Y) <= 50 && Math.Abs(dot[i + k, 1] - pos.X) <= 40)
                            {
                                label5.Text = Convert.ToString(dot[i + k, 2]);
                                label6.Text = Convert.ToString(dot[i + k + 4, 2]);
                                label4.Text = String.Format("Область {0}", i);
                                label7.Text = Convert.ToString(k);
                                label8.Text = Convert.ToString(idx);

                                PictureBox picture = new PictureBox();
                                picture.Location = new Point(dot[i, 1] - 24, dot[i, 2] + 35);
                                Size size = new Size(49, 51);
                                picture.Size = size;
                                this.Controls.Add(picture);

                                for (int h = 0; h < angle + 1; h++) if (h == angle) picture.Load("Область_" + name + angle + ".jpg");

                                PictureBox line1 = new PictureBox();
                                line1.Location = new Point(dot[i + k, 1] - 1, dot[i + k, 2]);
                                Size size1 = new Size(6, 122);
                                line1.Size = size1;
                                this.Controls.Add(line1);
                                line1.Load("Область_Линия2.jpg");

                            }
                        }
                    }
                }
            }
            // ЗДЕСЬ ДОЛЖНО БЫТЬ УДАЛЕНИЕ КАРТИНОК 
            if (e.Button == MouseButtons.Right)
            {
                if (angle == 1 || angle == 3)
                {
                    for (int i = 1; i < 13; i++)
                    {
                        idx++;
                        if (idx > 3)
                        {
                            k++;
                            idx = 1;
                        }
                        if (Math.Abs(((dot[i + k + 1, 1] - dot[i + k, 1]) / 2) + dot[i + k, 1] - pos.X) <= 60 && Math.Abs(dot[i + k, 2] - pos.Y) <= 40)
                        {
                            //this.Controls.Remove(area[0]);
                        }
                    }
                }
                else
                {

                }

            }
        }
    }
    }
