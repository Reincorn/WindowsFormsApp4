using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Sweat> sweatList = new List<Sweat>();
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            this.sweatList.Clear();
            var rand = new Random();
            for (var i = 0; i < 10; i++)
            {
                switch (rand.Next() % 3)
                {
                    case 0:
                        this.sweatList.Add(Chocolate.Generate());
                        break;
                    case 1:
                        this.sweatList.Add(Vipechka.Generate());
                        break;
                    case 2:
                        this.sweatList.Add(Fruit.Generate());
                        break;
                }
            }
            ShowInfo();
            Ochered();
        }
        private void ShowInfo()
        {
            int chocolateCount = 0;
            int vipechkaCount = 0;
            int fruitCount = 0;

            foreach (var sweat in this.sweatList)
            {
                if (sweat is Chocolate)
                {
                    chocolateCount += 1;
                }
                else if (sweat is Vipechka)
                {
                    vipechkaCount += 1;
                }
                else if (sweat is Fruit)
                {
                    fruitCount += 1;
                }
            }

            txtInfo.Text = "Шоколад\t\tВыпечка\t\tФрукты";
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t\t{1}\t\t{2}", chocolateCount, vipechkaCount, fruitCount);

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (this.sweatList.Count == 0)
            {
                txtOut.Text = "Пусто";
                pictureBox1.Image = Properties.Resources.пусто;
                return;
            }

            var sweat = this.sweatList[0];
            this.sweatList.RemoveAt(0);

            txtOut.Text = sweat.GetInfo();
            pictureBox1.Image = sweat.img;

            ShowInfo();
            Ochered();
        }
        private void Ochered()
        {
            int count = 1;
            string s = " ";
            if (this.sweatList.Count == 0)
            {
                s = "Продуктов нет";
            }
            foreach (var sweat in this.sweatList)
            {
                if (sweat is Chocolate)
                {
                    s = s + count + " шоколад\n";
                    count++;
                }
                else if (sweat is Vipechka)
                {
                    s = s + count + " выпечка\n";
                    count++;
                }
                else if (sweat is Fruit)
                {
                    s = s + count + " фрукты\n";
                    count++;
                }
            }
            richTextBox1.Text = s;
        }
    }
}
