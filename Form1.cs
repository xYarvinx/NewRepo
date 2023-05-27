using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        Calc C;

        
        public Form1()
        {
            InitializeComponent();

            C = new Calc();

            Export.Text = "0";
        }

        //кнопка Очистка (CE)
        private void buttonClear_Click(object sender, EventArgs e)
        {
            Export.Text = "0";

            C.Clear_A();
            FreeButtons();

        }

        //кнопка изменения знака у числа
        private void buttonChangeSign_Click(object sender, EventArgs e)
        {
            if (Export.Text[0] == '-')
                Export.Text = Export.Text.Remove(0, 1);
            else
                Export.Text = "-" + Export.Text;
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            if ((Export.Text.IndexOf(",") == -1) && (Export.Text.IndexOf("∞") == -1))
                Export.Text += ",";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            Export.Text += "0";

            CorrectNumber();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Export.Text += "1";

            CorrectNumber();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Export.Text += "2";

            CorrectNumber();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Export.Text += "3";

            CorrectNumber();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Export.Text += "4";

            CorrectNumber();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Export.Text += "5";

            CorrectNumber();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Export.Text += "6";

            CorrectNumber();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Export.Text += "7";

            CorrectNumber();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Export.Text += "8";

            CorrectNumber();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Export.Text += "9";

            CorrectNumber();
        }

       
        private void CorrectNumber()
        {
            
            if (Export.Text.IndexOf("∞") != -1)
                Export.Text = Export.Text.Substring(0, Export.Text.Length - 1);

           
            if (Export.Text[0] == '0' && (Export.Text.IndexOf(",") != 1))
                Export.Text = Export.Text.Remove(0, 1);

           
            if (Export.Text[0] == '-')
                if (Export.Text[1] == '0' && (Export.Text.IndexOf(",") != 2))
                    Export.Text = Export.Text.Remove(1, 1);
        }



        //кнопка Равно
        private void buttonCalc_Click(object sender, EventArgs e)
        {
            if (!buttonMult.Enabled)
                Export.Text = C.Multiplication(Convert.ToDouble(Export.Text)).ToString();

            if (!buttonDiv.Enabled)
                Export.Text = C.Division(Convert.ToDouble(Export.Text)).ToString();

            if (!buttonPlus.Enabled)
                Export.Text = C.Sum(Convert.ToDouble(Export.Text)).ToString();

            if (!buttonMinus.Enabled)
                Export.Text = C.Subtraction(Convert.ToDouble(Export.Text)).ToString();

            if (!buttonSqrtX.Enabled)
                Export.Text = C.SqrtX(Convert.ToDouble(Export.Text)).ToString();

            if (!buttonDegreeY.Enabled)
                Export.Text = C.DegreeY(Convert.ToDouble(Export.Text)).ToString();

            C.Clear_A();
            FreeButtons();

        }

        //кнопка Умножение
        private void buttonMult_Click(object sender, EventArgs e)
        {
            if(CanPress())
            {
                C.Put_A(Convert.ToDouble(Export.Text));

                buttonMult.Enabled = false;

                Export.Text = "0";
            }
        }

        //кнопка Деление
        private void buttonDiv_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(Export.Text));

                buttonDiv.Enabled = false;

                Export.Text = "0";
            }
        }

        //кнопка Сложение
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(Export.Text));

                buttonPlus.Enabled = false;

                Export.Text = "0";
            }
        }

        //кнопка Вычитание
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(Export.Text));

                buttonMinus.Enabled = false;

                Export.Text = "0";
            }
        }

        //кнопка Корень произвольной степени
        private void buttonSqrtX_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(Export.Text));

                buttonSqrtX.Enabled = false;

                Export.Text = "0";
            }
        }

        //кнопка Возведение в произвольную степень
        private void buttonDegreeY_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(Export.Text));

                buttonDegreeY.Enabled = false;

                Export.Text = "0";
            }
        }

        //кнопка Корень квадратный
        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(Export.Text));

                Export.Text = C.Sqrt().ToString();

                C.Clear_A();
                FreeButtons();
            }
        }

        //кнопка Квадрат числа
        private void buttonSquare_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(Export.Text));

                Export.Text = C.Square().ToString();

                C.Clear_A();
                FreeButtons();
            }
        }

        //кнопка Факториал
        private void buttonFactorial_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                if ((Convert.ToDouble(Export.Text) == (int)(Convert.ToDouble(Export.Text))) && 
                    ((Convert.ToDouble(Export.Text) >= 0.0)))
                {
                    C.Put_A(Convert.ToDouble(Export.Text));

                    Export.Text = C.Factorial().ToString();

                    C.Clear_A();
                    FreeButtons();
                }
                else
                    MessageBox.Show("Число должно быть >= 0 и целым!");
            }
        }
        //проверяет не нажата ли еще какая-либо из кнопок мат.операций
        private bool CanPress()
        {
            if (!buttonMult.Enabled)
                return false;

            if (!buttonDiv.Enabled)
                return false;

            if (!buttonPlus.Enabled)
                return false;

            if (!buttonMinus.Enabled)
                return false;

            if (!buttonSqrtX.Enabled)
                return false;

            if (!buttonDegreeY.Enabled)
                return false;

            return true;
        }

        //снятие нажатия всех кнопок мат.операций
        private void FreeButtons()
        {
            buttonMult.Enabled = true;
            buttonDiv.Enabled = true;
            buttonPlus.Enabled = true;
            buttonMinus.Enabled = true;
            buttonSqrtX.Enabled = true;
            buttonDegreeY.Enabled = true;
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Export_TextChanged(object sender, EventArgs e)
        {

        }
    }
}