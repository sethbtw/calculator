using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СalculatorExtended
{
    public partial class Калькулятор : Form
    {
        public Калькулятор()
        {
            InitializeComponent();
        }
        bool activate_enter = true; 
        private void button15_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender; // возвращаем кнопку
            if (b.Text == ",")
            {
                activate_enter = false;
            }
            if ((textBox1.Text == "0") && (b.Text != ","))
            {
                textBox1.Text = "";
            }
            if (textBox1.Text.IndexOf(",") > 0 && b.Text == "," || textBox1.Text == "" && b.Text == "," || textBox1.Text == "∞" && b.Text == ",")
            {
                return;
            }
            if ((activate_enter == true) && (b.Text != ","))
            {
                textBox1.Text = "";
                textBox1.Text = textBox1.Text + b.Text;
                activate_enter = false;
            }
            else if ((activate_enter == false) || (b.Text == ","))
            {
                textBox1.Text = textBox1.Text + b.Text;
            }
        }

        private void C_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Clear(); //удаляем строчку из лейбла
            cash = "";
            activate_enter = false;
        }

        private void CE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0"; //сохраняем строчку в лейбле
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 1)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
            else
            {
                textBox1.Text = "0";
            }
        }

        string cash;
        string number1;
        string move;
        string memory;

        private void EqualBtn_Click(object sender, EventArgs e)
            {
            if (move == "+")
                textBox1.Text = (Convert.ToDouble(textBox1.Text) + Convert.ToDouble(number1)).ToString();
            if (move == "-")
                textBox1.Text = (Convert.ToDouble(number1) - Convert.ToDouble(textBox1.Text)).ToString();
            if (move == "*")
                textBox1.Text = (Convert.ToDouble(textBox1.Text) * Convert.ToDouble(number1)).ToString();
            if ((move == "/" && textBox1.Text == "0") || (move == "/" && textBox1.Text == ","))
                textBox1.Text = "Деление на ноль невозможно!";
            else if (move == "/" && textBox1.Text != "0")
                textBox1.Text = (Convert.ToDouble(number1) / Convert.ToDouble(textBox1.Text)).ToString();
            if (move == "%")
                textBox1.Text = (Convert.ToDouble(number1) / 100 * Convert.ToDouble(textBox1.Text)).ToString();
            move = "";
            textBox2.Clear();
            cash = "";
            activate_enter = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            cash += Convert.ToDouble(textBox1.Text).ToString() + " + ";
            textBox2.Text = cash;
            activate_enter = true;
            textBox1.Text = (Convert.ToDouble(textBox1.Text) + Convert.ToDouble(number1)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button M = (Button)sender;
            cash += Convert.ToDouble(textBox1.Text).ToString() + " " + M.Text + " ";
            textBox2.Text = cash;
            if (textBox1.Text == "0" || textBox1.Text == "")
            {
                activate_enter = true;
            }
            else
            {
                Button B = (Button)sender;
                move = B.Text;
                number1 = textBox1.Text;
                activate_enter = true;
            }
        }

        private void Percents_Click(object sender, EventArgs e)
        {
            move = "%";
            number1 = textBox1.Text;
            activate_enter = true;
        }

        private void Fraction_Click(object sender, EventArgs e)
        {
            textBox1.Text = (1 / Convert.ToDouble(textBox1.Text)).ToString();
            activate_enter = true;
        }

        private void SqrtBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = (Math.Sqrt(Convert.ToDouble(textBox1.Text))).ToString();
        }

        private void PlsMns_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0")
            {
                textBox1.Text = (-Convert.ToDouble(textBox1.Text)).ToString();
            }
        }

        private void MS_Click(object sender, EventArgs e)
        {
            memory = textBox1.Text;
        }

        private void MR_Click(object sender, EventArgs e)
        {
            if (memory != "")
            {
                textBox1.Text = memory;
                memory = "";
            }
        }

        private void MC_Click(object sender, EventArgs e)
        {
            memory = "";
        }

        private void MPlus_Click(object sender, EventArgs e)
        {
            if (memory != "")
            {
                textBox1.Text = (Convert.ToDouble(textBox1.Text) + Convert.ToDouble(memory)).ToString();
                memory = "";
                textBox2.Clear();
                cash = "";
                activate_enter = true;
            }
        }

        private void MMinus_Click(object sender, EventArgs e)
        {
            if (memory != "")
            {
                textBox1.Text = (Convert.ToDouble(memory) - Convert.ToDouble(textBox1.Text)).ToString();
                memory = "";
                textBox2.Clear();
                cash = "";
                activate_enter = true;
            }
        }
    }
    }

