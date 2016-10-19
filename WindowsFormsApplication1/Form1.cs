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
        int[,] area = new int[13, 3];

        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(MouseWheelHandler);
        }

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
        }

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
                    name = "Провод";
                    pictureBox1.Load("Провод1.jpg");
                    obj = 3;
                    break;
                case 3:
                    name = "Амперметр";
                    pictureBox1.Load("Амперметр1.jpg");
                    obj = 4;
                    break;
                case 4:
                    name = "Амперметр";
                    pictureBox1.Load("Амперметр1.jpg");
                    obj = 4;
                    break;
                case 5:
                    name = "Амперметр";
                    pictureBox1.Load("Амперметр1.jpg");
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
            }
        }

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

        private void listBox1_MouseLeave(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void listBox1_MouseEnter(object sender, EventArgs e)
        {
            this.ActiveControl = listBox1;
        }

        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            var pos = this.PointToClient(Cursor.Position);
            if (e.Button == MouseButtons.Left)
            {
                int idx = 0;
                int k = 0;
                if (obj != 0)
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
                            if (area[i, 1] != 2 && area[i, 1] != 1)
                            {
                                if (Math.Abs(((dot[i + k + 1, 1] - dot[i + k, 1]) / 2) + dot[i + k, 1] - pos.X) <= 60 && Math.Abs(dot[i + k, 2] - pos.Y) <= 40)
                                {
                                        if (obj != 3)
                                        {
                                            if (dot[i + k, 3] != 2 && dot[i + k + 1, 3] != 2)
                                            {
                                                PictureBox picture = new PictureBox();
                                                picture.Location = new Point(dot[i + k, 1] + 33, dot[i + k, 2] - 24);
                                                Size size = new Size(51, 49);
                                                picture.Size = size;
                                                picture.Name = Convert.ToString("Horizon" + i);
                                                this.Controls.Add(picture);
                                                picture.MouseDown += Picture_MouseDown;

                                                for (int h = 0; h < angle + 1; h++) if (h == angle) picture.Load("Область_" + name + angle + ".jpg");

                                                Graphics lin;
                                                lin = CreateGraphics();
                                                Pen Bpen = new Pen(Color.Black, 2);
                                                lin.DrawLine(Bpen, dot[i + k, 1] + 2, dot[i + k, 2] + 1, dot[i + k + 1, 1] - 1, dot[i + k + 1, 2]);

                                                area[i, 1] = 2;

                                                dot[i + k, 3] = 2;
                                                dot[i + k + 1, 3] = 2;
                                            }
                                        }
                                        else
                                        {
                                            Graphics lin;
                                            lin = CreateGraphics();
                                            Pen Bpen = new Pen(Color.Black, 2);
                                            lin.DrawLine(Bpen, dot[i + k, 1] + 2, dot[i + k, 2] + 1, dot[i + k + 1, 1] - 1, dot[i + k + 1, 2]);

                                            area[i, 1] = 1;

                                            if (dot[i + k, 3] == 2) dot[i + k, 3] = 2;
                                            else dot[i + k, 3] = 1;
                                            if (dot[i + k + 1, 3] == 2) dot[i + k + 1, 3] = 2;
                                            else dot[i + k + 1, 3] = 1;
                                        }
                                    
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 1; i < 13; i++)
                        {
                            if (area[i, 2] != 1 && area[i, 2] != 2)
                            {
                                if (Math.Abs(((dot[i + 4, 2] - dot[i, 2]) / 2) + dot[i, 2] - pos.Y) <= 50 && Math.Abs(dot[i + k, 1] - pos.X) <= 40)
                                {
                                    if (obj != 3)
                                    {
                                        if (dot[i , 3] != 2 && dot[i + 4, 3] != 2)
                                        {
                                            PictureBox picture = new PictureBox();
                                            picture.Location = new Point(dot[i, 1] - 24, dot[i, 2] + 35);
                                            Size size = new Size(49, 51);
                                            picture.Size = size;
                                            picture.Name = Convert.ToString("Vertical" + i);
                                            this.Controls.Add(picture);
                                            picture.MouseDown += Picture_MouseDown;

                                            for (int h = 0; h < angle + 1; h++) if (h == angle) picture.Load("Область_" + name + angle + ".jpg");

                                            Graphics lin;
                                            lin = CreateGraphics();
                                            Pen Bpen = new Pen(Color.Black, 2);
                                            lin.DrawLine(Bpen, dot[i, 1] + 1, dot[i, 2] + 1, dot[i + 4, 1] + 1, dot[i + 4, 2]);

                                            area[i, 2] = 2;

                                            dot[i, 3] = 2;
                                            dot[i + 4, 3] = 2;
                                        }
                                    }
                                    else
                                    {
                                        Graphics lin;
                                        lin = CreateGraphics();
                                        Pen Bpen = new Pen(Color.Black, 2);
                                        lin.DrawLine(Bpen, dot[i, 1] + 1, dot[i, 2] + 1, dot[i + 4, 1] + 1, dot[i + 4, 2]);

                                        area[i, 2] = 1;

                                        if (dot[i, 3] == 2) dot[i, 3] = 2;
                                        else dot[i, 3] = 1;
                                        if (dot[i + 4, 3] == 2) dot[i + 4, 3] = 2;
                                        else dot[i + 4, 3] = 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                int idx = 0;
                int k = 0;
                for (int i = 1; i < 13; i++)
                {
                    if (Math.Abs(((dot[i + 4, 2] - dot[i, 2]) / 2) + dot[i, 2] - pos.Y) <= 60 && Math.Abs(dot[i + k, 1] - pos.X) <= 15)
                    {
                        if (area[i,2] == 1)
                        {
                            Graphics lin;
                            lin = CreateGraphics();
                            Pen Bpen = new Pen(Color.White, 2);
                            lin.DrawLine(Bpen, dot[i, 1] + 1, dot[i, 2] + 3, dot[i + 4, 1] + 1, dot[i + 4, 2]);

                            area[i, 2] = 0;

                            if (dot[i, 3] == 2) dot[i, 3] = 2;
                            else dot[i, 3] = 0;
                            if (dot[i + 4, 3] == 2) dot[i + 4, 3] = 2;
                            else dot[i + 4, 3] = 0;
                        }
                    }
                }

                for (int i = 1; i < 13; i++)
                {
                    idx++;
                    if (idx > 3)
                    {
                        k++;
                        idx = 1;
                    }
                    if (Math.Abs(((dot[i + k + 1, 1] - dot[i + k, 1]) / 2) + dot[i + k, 1] - pos.X) <= 60 && Math.Abs(dot[i + k, 2] - pos.Y) <= 15)
                    {
                        if (area[i, 1] == 1)
                        {
                                Graphics lin;
                                lin = CreateGraphics();
                                Pen Bpen = new Pen(Color.White, 2);
                                lin.DrawLine(Bpen, dot[i + k, 1] + 2, dot[i + k, 2] + 1, dot[i + k + 1, 1] - 1, dot[i + k + 1, 2]);

                                area[i, 1] = 0;

                                if (dot[i + k, 3] == 2) dot[i + k, 3] = 2;
                                else dot[i + k, 3] = 0;
                                if (dot[i + k + 1, 3] == 2) dot[i + k + 1, 3] = 2;
                                else dot[i + k + 1, 3] = 0;
                        }
                    }
                }
            }
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var pos = this.PointToClient(Cursor.Position);
                PictureBox picture = sender as PictureBox;
                int idx = 0;
                int k = 0;
                for (int i = 1; i < 13; i++)
                {
                    if (picture.Name == "Horizon" + Convert.ToString(i))
                    {
                        this.Controls.Remove(picture);
                        picture.Dispose();
                        area[i, 1] = 0;
                    }
                    if (picture.Name == "Vertical" + Convert.ToString(i))
                    {
                        this.Controls.Remove(picture);
                        picture.Dispose();
                        area[i, 2] = 0;
                    }
                    // vertical
                    if (Math.Abs(((dot[i + 4, 2] - dot[i, 2]) / 2) + dot[i, 2] - pos.Y) <= 50 && Math.Abs(dot[i + k, 1] - pos.X) <= 40)
                    {
                        Graphics lin;
                        lin = CreateGraphics();
                        Pen Bpen = new Pen(Color.White, 2);
                        lin.DrawLine(Bpen, dot[i, 1] + 1, dot[i, 2] + 3, dot[i + 4, 1] + 1, dot[i + 4, 2]);

                        if (dot[i, 3] == 1) dot[i, 3] = 1;
                        else dot[i, 3] = 0;
                        if (dot[i + 4, 3] == 1) dot[i + 4, 3] = 1;
                        else dot[i + 4, 3] = 0;

                    }
                }
                // horizontal
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
                        Graphics lin;
                        lin = CreateGraphics();
                        Pen Bpen = new Pen(Color.White, 2);
                        lin.DrawLine(Bpen, dot[i + k, 1] + 2, dot[i + k, 2] + 1, dot[i + k + 1, 1] - 1, dot[i + k + 1, 2]);

                        if (dot[i + k, 3] == 1) dot[i + k, 3] = 1;
                        else dot[i + k, 3] = 0;
                        if (dot[i + k + 1, 3] == 1) dot[i + k + 1, 3] = 1;
                        else dot[i + k + 1, 3] = 0;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            for (int i = 1; i < 17; i++) richTextBox1.Text += String.Format("{0} {1} {2} {3}", i, Convert.ToString(dot[i, 1]), Convert.ToString(dot[i, 2]), Convert.ToString(dot[i, 3]) + "\n");
        }
    }
}
    
