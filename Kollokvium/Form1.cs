using System;
using System.Windows.Forms;
using System.Numerics;
using System.Linq;

namespace Kollokvium
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((PervoeChislo.Text != "") && (Vtoroechislo.Text != ""))
            {
                BigInteger num1 = BigInteger.Parse(PervoeChislo.Text);
                BigInteger num2 = BigInteger.Parse(Vtoroechislo.Text);
                if (compare_chislo.Checked)  //сравнение
                {
                    int res = BigInteger.Compare(num1, num2);
                    switch (res)
                    {
                        case 1:
                            {
                                Resultatchislo.Text = 0.ToString();
                                break;
                            }
                        case -1:
                            {
                                Resultatchislo.Text = 1.ToString();
                                break;
                            }
                        default:
                            {
                                Resultatchislo.Text = res.ToString();
                                break;
                            }
                    }
                }
                if (add_chislo.Checked) //сложенгие
                {
                    Resultatchislo.Text = BigInteger.Add(num1, num2).ToString();
                }
                if (substruct_chislo.Checked) //вычитание
                {
                    Resultatchislo.Text = BigInteger.Subtract(num1, num2).ToString();
                }
                if (multty_chislo.Checked) //умножение
                {
                    Resultatchislo.Text = BigInteger.Multiply(num1, num2).ToString();
                }
                if (div_chislo.Checked) //деление
                {
                    if (!num2.IsZero)
                    {
                        Resultatchislo.Text = BigInteger.Divide(num1, num2).ToString();
                    }
                    else
                    {
                        Resultatchislo.Text = "На ноль делить нельзя";
                    }
                }
                if (mod_chislo.Checked) //остаток от деления
                {
                    if (!num2.IsZero)
                    {
                        BigInteger num3;
                        BigInteger.DivRem(num1, num2, out num3);
                        Resultatchislo.Text = num3.ToString();
                    }
                    else
                    {
                        Resultatchislo.Text = "На ноль делить нельзя";
                    }
                }
                if (NOD_chislo.Checked) //НОД
                {

                    Resultatchislo.Text = BigInteger.GreatestCommonDivisor(num1, num2).ToString();

                }
                if (NOK_chislo.Checked)//НОК
                {
                    if ((num1 == 0) && (num2 == 0))
                        Resultatchislo.Text = "Не определен";
                    else
                        Resultatchislo.Text = BigInteger.Divide(BigInteger.Abs(BigInteger.Multiply(num1, num2)), BigInteger.GreatestCommonDivisor(num1, num2)).ToString();
                }

            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = (sender as TextBox).Text ?? "";


            if (!(Char.IsDigit(e.KeyChar))) //ввод только цифр в поле
            {
                if ((e.KeyChar != (char)Keys.Back) && (e.KeyChar != 45))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == 45 && text.Contains('-')) //два минуса подряд не могут идти
                {
                    e.Handled = true;
                }
                if (e.KeyChar == 45 && (text.Contains('1') || text.Contains('2') || text.Contains('3') || text.Contains('4') || text.Contains('5')
                || text.Contains('6') || text.Contains('7') || text.Contains('8') || text.Contains('9'))) //минус после цифр не может идти
                {
                    e.Handled = true;
                }

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (compare_chislo.Checked) //включения помощи при сравнения чисел
            {
                label4.Visible = true;
            }
            else
            {
                label4.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            res_znam_drobi.Text = "";
            res_chisl_drobi.Text = "";
            res_drobi.Visible = false;
            label8.Visible = false;
            if ((chisl1_drobi.Text != "") && (znam1_drobi.Text != "") && (chisl2_drobi.Text != "") && (znam2_drobi.Text != ""))
            {
                BigInteger chislitel1 = BigInteger.Parse(chisl1_drobi.Text);
                BigInteger dilitel1 = BigInteger.Parse(znam1_drobi.Text);
                BigInteger chislitel2 = BigInteger.Parse(chisl2_drobi.Text);
                BigInteger dilitel2 = BigInteger.Parse(znam2_drobi.Text);
                if(dilitel2 != 0 && dilitel1 != 0)
                { 
                    if (add_drobi.Checked) // сложение дробей
                    {
                        BigInteger num1 = BigInteger.Multiply(dilitel1, dilitel2);
                        BigInteger num2 = BigInteger.Add(BigInteger.Multiply(chislitel1, dilitel2), BigInteger.Multiply(chislitel2, dilitel1));
                        BigInteger NOD = BigInteger.GreatestCommonDivisor(num2, num1);
                        while (!NOD.IsOne) //сокращение дроби
                        {
                            num1 = BigInteger.Divide(num1, NOD);
                            num2 = BigInteger.Divide(num2, NOD);
                            NOD = BigInteger.GreatestCommonDivisor(num2, num1);
                        }
                        res_znam_drobi.Text = num1.ToString();
                        res_chisl_drobi.Text = num2.ToString();
                        if (num1.IsOne)
                        {
                            res_drobi.Visible = true;
                            label8.Visible = true;
                            res_drobi.Text = num2.ToString();
                        }
                        else
                        {
                            res_drobi.Visible = false;
                            label8.Visible = false;
                        }
                    }
                    if (substruct_drobi.Checked) //вычитание дробей
                    {
                        BigInteger num1 = BigInteger.Multiply(dilitel1, dilitel2);
                        BigInteger num2 = BigInteger.Subtract(BigInteger.Multiply(chislitel1, dilitel2), BigInteger.Multiply(chislitel2, dilitel1));
                        BigInteger NOD = BigInteger.GreatestCommonDivisor(num2, num1);
                        while (!NOD.IsOne) //сокращение дроби
                        {
                            num1 = BigInteger.Divide(num1, NOD);
                            num2 = BigInteger.Divide(num2, NOD);
                            NOD = BigInteger.GreatestCommonDivisor(num2, num1);
                        }
                        res_znam_drobi.Text = num1.ToString();
                        res_chisl_drobi.Text = num2.ToString();
                        if (num1.IsOne)
                        {
                            res_drobi.Visible = true;
                            label8.Visible = true;
                            res_drobi.Text = num2.ToString();
                        }
                        else
                        {
                            res_drobi.Visible = false;
                            label8.Visible = false;
                        }
                    }
                    if (multy_drobi.Checked) // умножение дробей
                    {
                        BigInteger num1 = BigInteger.Multiply(dilitel1, dilitel2);
                        BigInteger num2 = BigInteger.Multiply(chislitel1, chislitel2);
                        BigInteger NOD = BigInteger.GreatestCommonDivisor(num2, num1);
                        while (!NOD.IsOne) // сокращение дробей
                        {
                            num1 = BigInteger.Divide(num1, NOD);
                            num2 = BigInteger.Divide(num2, NOD);
                            NOD = BigInteger.GreatestCommonDivisor(num2, num1);
                        }
                        res_znam_drobi.Text = num1.ToString();
                        res_chisl_drobi.Text = num2.ToString();
                        if (num1.IsOne)
                        {
                            res_drobi.Visible = true;
                            label8.Visible = true;
                            res_drobi.Text = num2.ToString();
                        }
                        else
                        {
                            res_drobi.Visible = false;
                            label8.Visible = false;
                        }
                    }
                    if (div_drobi.Checked) //деление дробей
                    {
                        if (chislitel2 != 0)
                        {
                            BigInteger num1 = BigInteger.Multiply(dilitel1, chislitel2);
                            BigInteger num2 = BigInteger.Multiply(chislitel1, dilitel2);
                            BigInteger NOD = BigInteger.GreatestCommonDivisor(num2, num1);
                            while (!NOD.IsOne) //сокращение дробей
                            {
                                num1 = BigInteger.Divide(num1, NOD);
                                num2 = BigInteger.Divide(num2, NOD);
                                NOD = BigInteger.GreatestCommonDivisor(num2, num1);
                            }
                            res_znam_drobi.Text = num1.ToString();
                            res_chisl_drobi.Text = num2.ToString();
                            if (num1.IsOne)
                            {
                                res_drobi.Visible = true;
                                label8.Visible = true;
                                res_drobi.Text = num2.ToString();
                            }
                            else
                            {
                                res_drobi.Visible = false;
                                label8.Visible = false;
                            }
                        }
                        else
                        {
                            res_znam_drobi.Text = "Ошибка!";
                            res_chisl_drobi.Text = "Ошибка!";
                        }
                    }
                }
                else
                {
                    res_znam_drobi.Text = "Ошибка!";
                    res_chisl_drobi.Text = "Ошибка!";
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //выбор степени первого многочлена
        {
            x0.Text = "0"; x1.Text = "0"; x2.Text = "0"; x3.Text = "0"; x4.Text = "0";
            x5.Text = "0"; x6.Text = "0"; x7.Text = "0"; x8.Text = "0"; x9.Text = "0";
            x10.Text = "0"; x11.Text = "0";
            int m = comboBox1.SelectedIndex;
            switch (m)
            {
                case 10:
                    {
                        x8.Visible = true;
                        x4.Visible = true;
                        x0.Visible = true;
                        x1.Visible = true;
                        x2.Visible = true;
                        x3.Visible = true;
                        x5.Visible = true;
                        x6.Visible = true;
                        x7.Visible = true;
                        x9.Visible = true;
                        x10.Visible = true;
                        x11.Visible = true;
                        lx11.Visible = true;
                        lx10.Visible = true;
                        lx9.Visible = true;
                        lx7.Visible = true;
                        lx6.Visible = true;
                        lx5.Visible = true;
                        lx3.Visible = true;
                        lx2.Visible = true;
                        lx1.Visible = true;
                        lx0.Visible = true;
                        lx4.Visible = true;
                        lx8.Visible = true;
                        break;
                    }
                case 9:
                    {
                        x8.Visible = true;
                        x4.Visible = true;
                        x0.Visible = true;
                        x1.Visible = true;
                        x2.Visible = true;
                        x3.Visible = true;
                        x5.Visible = true;
                        x6.Visible = true;
                        x7.Visible = true;
                        x9.Visible = true;
                        x10.Visible = true;
                        x11.Visible = false;
                        lx11.Visible = false;
                        lx10.Visible = true;
                        lx9.Visible = true;
                        lx7.Visible = true;
                        lx6.Visible = true;
                        lx5.Visible = true;
                        lx3.Visible = true;
                        lx2.Visible = true;
                        lx1.Visible = true;
                        lx0.Visible = true;
                        lx4.Visible = true;
                        lx8.Visible = true;
                        break;
                    }
                case 8:
                    {
                        x8.Visible = true;
                        x4.Visible = true;
                        x0.Visible = true;
                        x1.Visible = true;
                        x2.Visible = true;
                        x3.Visible = true;
                        x5.Visible = true;
                        x6.Visible = true;
                        x7.Visible = true;
                        x9.Visible = true;
                        x10.Visible = false;
                        x11.Visible = false;
                        lx11.Visible = false;
                        lx10.Visible = false;
                        lx9.Visible = true;
                        lx7.Visible = true;
                        lx6.Visible = true;
                        lx5.Visible = true;
                        lx3.Visible = true;
                        lx2.Visible = true;
                        lx1.Visible = true;
                        lx0.Visible = true;
                        lx4.Visible = true;
                        lx8.Visible = true;
                        break;
                    }
                case 7:
                    {
                        x8.Visible = true;
                        x4.Visible = true;
                        x0.Visible = true;
                        x1.Visible = true;
                        x2.Visible = true;
                        x3.Visible = true;
                        x5.Visible = true;
                        x6.Visible = true;
                        x7.Visible = true;
                        x9.Visible = false;
                        x10.Visible = false;
                        x11.Visible = false;
                        lx11.Visible = false;
                        lx10.Visible = false;
                        lx9.Visible = false;
                        lx7.Visible = true;
                        lx6.Visible = true;
                        lx5.Visible = true;
                        lx3.Visible = true;
                        lx2.Visible = true;
                        lx1.Visible = true;
                        lx0.Visible = true;
                        lx4.Visible = true;
                        lx8.Visible = true;
                        break;
                    }
                case 6:
                    {
                        x8.Visible = false;
                        x4.Visible = true;
                        x0.Visible = true;
                        x1.Visible = true;
                        x2.Visible = true;
                        x3.Visible = true;
                        x5.Visible = true;
                        x6.Visible = true;
                        x7.Visible = true;
                        x9.Visible = false;
                        x10.Visible = false;
                        x11.Visible = false;
                        lx11.Visible = false;
                        lx10.Visible = false;
                        lx9.Visible = false;
                        lx7.Visible = true;
                        lx6.Visible = true;
                        lx5.Visible = true;
                        lx3.Visible = true;
                        lx2.Visible = true;
                        lx1.Visible = true;
                        lx0.Visible = true;
                        lx4.Visible = true;
                        lx8.Visible = false;
                        break;
                    }
                case 5:
                    {
                        x8.Visible = false;
                        x4.Visible = true;
                        x0.Visible = true;
                        x1.Visible = true;
                        x2.Visible = true;
                        x3.Visible = true;
                        x5.Visible = true;
                        x6.Visible = true;
                        x7.Visible = false;
                        x9.Visible = false;
                        x10.Visible = false;
                        x11.Visible = false;
                        lx11.Visible = false;
                        lx10.Visible = false;
                        lx9.Visible = false;
                        lx7.Visible = false;
                        lx6.Visible = true;
                        lx5.Visible = true;
                        lx3.Visible = true;
                        lx2.Visible = true;
                        lx1.Visible = true;
                        lx0.Visible = true;
                        lx4.Visible = true;
                        lx8.Visible = false;
                        break;
                    }
                case 4:
                    {
                        x8.Visible = false;
                        x4.Visible = true;
                        x0.Visible = true;
                        x1.Visible = true;
                        x2.Visible = true;
                        x3.Visible = true;
                        x5.Visible = true;
                        x6.Visible = false;
                        x7.Visible = false;
                        x9.Visible = false;
                        x10.Visible = false;
                        x11.Visible = false;
                        lx11.Visible = false;
                        lx10.Visible = false;
                        lx9.Visible = false;
                        lx7.Visible = false;
                        lx6.Visible = false;
                        lx5.Visible = true;
                        lx3.Visible = true;
                        lx2.Visible = true;
                        lx1.Visible = true;
                        lx0.Visible = true;
                        lx4.Visible = true;
                        lx8.Visible = false;
                        break;
                    }
                case 3:
                    {
                        x8.Visible = false;
                        x4.Visible = true;
                        x0.Visible = true;
                        x1.Visible = true;
                        x2.Visible = true;
                        x3.Visible = true;
                        x5.Visible = false;
                        x6.Visible = false;
                        x7.Visible = false;
                        x9.Visible = false;
                        x10.Visible = false;
                        x11.Visible = false;
                        lx11.Visible = false;
                        lx10.Visible = false;
                        lx9.Visible = false;
                        lx7.Visible = false;
                        lx6.Visible = false;
                        lx5.Visible = false;
                        lx3.Visible = true;
                        lx2.Visible = true;
                        lx1.Visible = true;
                        lx0.Visible = true;
                        lx4.Visible = true;
                        lx8.Visible = false;
                        break;
                    }
                case 2:
                    {
                        x8.Visible = false;
                        x4.Visible = false;
                        x0.Visible = true;
                        x1.Visible = true;
                        x2.Visible = true;
                        x3.Visible = true;
                        x5.Visible = false;
                        x6.Visible = false;
                        x7.Visible = false;
                        x9.Visible = false;
                        x10.Visible = false;
                        x11.Visible = false;
                        lx11.Visible = false;
                        lx10.Visible = false;
                        lx9.Visible = false;
                        lx7.Visible = false;
                        lx6.Visible = false;
                        lx5.Visible = false;
                        lx3.Visible = true;
                        lx2.Visible = true;
                        lx1.Visible = true;
                        lx0.Visible = true;
                        lx4.Visible = false;
                        lx8.Visible = false;
                        break;
                    }
                case 1:
                    {
                        x8.Visible = false;
                        x4.Visible = false;
                        x0.Visible = true;
                        x1.Visible = true;
                        x2.Visible = true;
                        x3.Visible = false;
                        x5.Visible = false;
                        x6.Visible = false;
                        x7.Visible = false;
                        x9.Visible = false;
                        x10.Visible = false;
                        x11.Visible = false;
                        lx11.Visible = false;
                        lx10.Visible = false;
                        lx9.Visible = false;
                        lx7.Visible = false;
                        lx6.Visible = false;
                        lx5.Visible = false;
                        lx3.Visible = false;
                        lx2.Visible = true;
                        lx1.Visible = true;
                        lx0.Visible = true;
                        lx4.Visible = false;
                        lx8.Visible = false;
                        break;
                    }
                case 0:
                    {
                        x8.Visible = false;
                        x4.Visible = false;
                        x0.Visible = true;
                        x1.Visible = true;
                        x2.Visible = false;
                        x3.Visible = false;
                        x5.Visible = false;
                        x6.Visible = false;
                        x7.Visible = false;
                        x9.Visible = false;
                        x10.Visible = false;
                        x11.Visible = false;
                        lx11.Visible = false;
                        lx10.Visible = false;
                        lx9.Visible = false;
                        lx7.Visible = false;
                        lx6.Visible = false;
                        lx5.Visible = false;
                        lx3.Visible = false;
                        lx2.Visible = false;
                        lx1.Visible = true;
                        lx0.Visible = true;
                        lx4.Visible = false;
                        lx8.Visible = false;
                        break;
                    }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //выбор степени второго многочлена
        {
            y0.Text = "0"; y1.Text = "0"; y2.Text = "0"; y3.Text = "0"; y4.Text = "0";
            y5.Text = "0"; y6.Text = "0"; y7.Text = "0"; y8.Text = "0"; y9.Text = "0";
            y10.Text = "0"; y11.Text = "0";

            int m = comboBox2.SelectedIndex;
            switch (m)
            {
                case 10:
                    {
                        y8.Visible = true;
                        y4.Visible = true;
                        y0.Visible = true;
                        y1.Visible = true;
                        y2.Visible = true;
                        y3.Visible = true;
                        y5.Visible = true;
                        y6.Visible = true;
                        y7.Visible = true;
                        y9.Visible = true;
                        y10.Visible = true;
                        y11.Visible = true;
                        ly11.Visible = true;
                        ly10.Visible = true;
                        ly9.Visible = true;
                        ly7.Visible = true;
                        ly6.Visible = true;
                        ly5.Visible = true;
                        ly3.Visible = true;
                        ly2.Visible = true;
                        ly1.Visible = true;
                        ly0.Visible = true;
                        ly4.Visible = true;
                        ly8.Visible = true;
                        break;
                    }
                case 9:
                    {
                        y8.Visible = true;
                        y4.Visible = true;
                        y0.Visible = true;
                        y1.Visible = true;
                        y2.Visible = true;
                        y3.Visible = true;
                        y5.Visible = true;
                        y6.Visible = true;
                        y7.Visible = true;
                        y9.Visible = true;
                        y10.Visible = true;
                        y11.Visible = false;
                        ly11.Visible = false;
                        ly10.Visible = true;
                        ly9.Visible = true;
                        ly7.Visible = true;
                        ly6.Visible = true;
                        ly5.Visible = true;
                        ly3.Visible = true;
                        ly2.Visible = true;
                        ly1.Visible = true;
                        ly0.Visible = true;
                        ly4.Visible = true;
                        ly8.Visible = true;
                        break;
                    }
                case 8:
                    {
                        y8.Visible = true;
                        y4.Visible = true;
                        y0.Visible = true;
                        y1.Visible = true;
                        y2.Visible = true;
                        y3.Visible = true;
                        y5.Visible = true;
                        y6.Visible = true;
                        y7.Visible = true;
                        y9.Visible = true;
                        y10.Visible = false;
                        y11.Visible = false;
                        ly11.Visible = false;
                        ly10.Visible = false;
                        ly9.Visible = true;
                        ly7.Visible = true;
                        ly6.Visible = true;
                        ly5.Visible = true;
                        ly3.Visible = true;
                        ly2.Visible = true;
                        ly1.Visible = true;
                        ly0.Visible = true;
                        ly4.Visible = true;
                        ly8.Visible = true;
                        break;
                    }
                case 7:
                    {
                        y8.Visible = true;
                        y4.Visible = true;
                        y0.Visible = true;
                        y1.Visible = true;
                        y2.Visible = true;
                        y3.Visible = true;
                        y5.Visible = true;
                        y6.Visible = true;
                        y7.Visible = true;
                        y9.Visible = false;
                        y10.Visible = false;
                        y11.Visible = false;
                        ly11.Visible = false;
                        ly10.Visible = false;
                        ly9.Visible = false;
                        ly7.Visible = true;
                        ly6.Visible = true;
                        ly5.Visible = true;
                        ly3.Visible = true;
                        ly2.Visible = true;
                        ly1.Visible = true;
                        ly0.Visible = true;
                        ly4.Visible = true;
                        ly8.Visible = true;
                        break;
                    }
                case 6:
                    {
                        y8.Visible = false;
                        y4.Visible = true;
                        y0.Visible = true;
                        y1.Visible = true;
                        y2.Visible = true;
                        y3.Visible = true;
                        y5.Visible = true;
                        y6.Visible = true;
                        y7.Visible = true;
                        y9.Visible = false;
                        y10.Visible = false;
                        y11.Visible = false;
                        ly11.Visible = false;
                        ly10.Visible = false;
                        ly9.Visible = false;
                        ly7.Visible = true;
                        ly6.Visible = true;
                        ly5.Visible = true;
                        ly3.Visible = true;
                        ly2.Visible = true;
                        ly1.Visible = true;
                        ly0.Visible = true;
                        ly4.Visible = true;
                        ly8.Visible = false;
                        break;
                    }
                case 5:
                    {
                        y8.Visible = false;
                        y4.Visible = true;
                        y0.Visible = true;
                        y1.Visible = true;
                        y2.Visible = true;
                        y3.Visible = true;
                        y5.Visible = true;
                        y6.Visible = true;
                        y7.Visible = false;
                        y9.Visible = false;
                        x10.Visible = false;
                        y11.Visible = false;
                        ly11.Visible = false;
                        ly10.Visible = false;
                        ly9.Visible = false;
                        ly7.Visible = false;
                        ly6.Visible = true;
                        ly5.Visible = true;
                        ly3.Visible = true;
                        ly2.Visible = true;
                        ly1.Visible = true;
                        ly0.Visible = true;
                        ly4.Visible = true;
                        ly8.Visible = false;
                        break;
                    }
                case 4:
                    {
                        y8.Visible = false;
                        y4.Visible = true;
                        y0.Visible = true;
                        y1.Visible = true;
                        y2.Visible = true;
                        y3.Visible = true;
                        y5.Visible = true;
                        y6.Visible = false;
                        y7.Visible = false;
                        y9.Visible = false;
                        y10.Visible = false;
                        y11.Visible = false;
                        ly11.Visible = false;
                        ly10.Visible = false;
                        ly9.Visible = false;
                        ly7.Visible = false;
                        ly6.Visible = false;
                        ly5.Visible = true;
                        ly3.Visible = true;
                        ly2.Visible = true;
                        ly1.Visible = true;
                        ly0.Visible = true;
                        ly4.Visible = true;
                        ly8.Visible = false;
                        break;
                    }
                case 3:
                    {
                        y8.Visible = false;
                        y4.Visible = true;
                        y0.Visible = true;
                        y1.Visible = true;
                        y2.Visible = true;
                        y3.Visible = true;
                        y5.Visible = false;
                        y6.Visible = false;
                        y7.Visible = false;
                        y9.Visible = false;
                        y10.Visible = false;
                        y11.Visible = false;
                        ly11.Visible = false;
                        ly10.Visible = false;
                        ly9.Visible = false;
                        ly7.Visible = false;
                        ly6.Visible = false;
                        ly5.Visible = false;
                        ly3.Visible = true;
                        ly2.Visible = true;
                        ly1.Visible = true;
                        ly0.Visible = true;
                        ly4.Visible = true;
                        ly8.Visible = false;
                        break;
                    }
                case 2:
                    {
                        y8.Visible = false;
                        y4.Visible = false;
                        y0.Visible = true;
                        y1.Visible = true;
                        y2.Visible = true;
                        y3.Visible = true;
                        y5.Visible = false;
                        y6.Visible = false;
                        y7.Visible = false;
                        y9.Visible = false;
                        y10.Visible = false;
                        y11.Visible = false;
                        ly11.Visible = false;
                        ly10.Visible = false;
                        ly9.Visible = false;
                        ly7.Visible = false;
                        ly6.Visible = false;
                        ly5.Visible = false;
                        ly3.Visible = true;
                        ly2.Visible = true;
                        ly1.Visible = true;
                        ly0.Visible = true;
                        ly4.Visible = false;
                        ly8.Visible = false;
                        break;
                    }
                case 1:
                    {
                        y8.Visible = false;
                        y4.Visible = false;
                        y0.Visible = true;
                        y1.Visible = true;
                        y2.Visible = true;
                        y3.Visible = false;
                        y5.Visible = false;
                        y6.Visible = false;
                        y7.Visible = false;
                        y9.Visible = false;
                        y10.Visible = false;
                        y11.Visible = false;
                        ly11.Visible = false;
                        ly10.Visible = false;
                        ly9.Visible = false;
                        ly7.Visible = false;
                        ly6.Visible = false;
                        ly5.Visible = false;
                        ly3.Visible = false;
                        ly2.Visible = true;
                        ly1.Visible = true;
                        ly0.Visible = true;
                        ly4.Visible = false;
                        ly8.Visible = false;
                        break;
                    }
                case 0:
                    {
                        y8.Visible = false;
                        y4.Visible = false;
                        y0.Visible = true;
                        y1.Visible = true;
                        y2.Visible = false;
                        y3.Visible = false;
                        y5.Visible = false;
                        y6.Visible = false;
                        y7.Visible = false;
                        y9.Visible = false;
                        y10.Visible = false;
                        y11.Visible = false;
                        ly11.Visible = false;
                        ly10.Visible = false;
                        ly9.Visible = false;
                        ly7.Visible = false;
                        ly6.Visible = false;
                        ly5.Visible = false;
                        ly3.Visible = false;
                        ly2.Visible = false;
                        ly1.Visible = true;
                        ly0.Visible = true;
                        ly4.Visible = false;
                        ly8.Visible = false;
                        break;
                    }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            BigInteger nx0 = BigInteger.Parse(x0.Text);
            BigInteger nx1 = BigInteger.Parse(x1.Text);
            BigInteger nx2 = BigInteger.Parse(x2.Text);
            BigInteger nx3 = BigInteger.Parse(x3.Text);
            BigInteger nx4 = BigInteger.Parse(x4.Text);
            BigInteger nx5 = BigInteger.Parse(x5.Text);
            BigInteger nx6 = BigInteger.Parse(x6.Text);
            BigInteger nx7 = BigInteger.Parse(x7.Text);
            BigInteger nx8 = BigInteger.Parse(x8.Text);
            BigInteger nx9 = BigInteger.Parse(x9.Text);
            BigInteger nx10 = BigInteger.Parse(x10.Text);
            BigInteger nx11 = BigInteger.Parse(x11.Text);

            BigInteger ny0 = BigInteger.Parse(y0.Text);
            BigInteger ny1 = BigInteger.Parse(y1.Text);
            BigInteger ny2 = BigInteger.Parse(y2.Text);
            BigInteger ny3 = BigInteger.Parse(y3.Text);
            BigInteger ny4 = BigInteger.Parse(y4.Text);
            BigInteger ny5 = BigInteger.Parse(y5.Text);
            BigInteger ny6 = BigInteger.Parse(y6.Text);
            BigInteger ny7 = BigInteger.Parse(y7.Text);
            BigInteger ny8 = BigInteger.Parse(y8.Text);
            BigInteger ny9 = BigInteger.Parse(y9.Text);
            BigInteger ny10 = BigInteger.Parse(y10.Text);
            BigInteger ny11 = BigInteger.Parse(y11.Text);

            if (add_polin.Checked) //сложение многочленов
            {
                z11.Text = BigInteger.Add(nx11, ny11).ToString();
                z10.Text = BigInteger.Add(nx10, ny10).ToString();
                z9.Text = BigInteger.Add(nx9, ny9).ToString();
                z8.Text = BigInteger.Add(nx8, ny8).ToString();
                z7.Text = BigInteger.Add(nx7, ny7).ToString();
                z6.Text = BigInteger.Add(nx6, ny6).ToString();
                z5.Text = BigInteger.Add(nx5, ny5).ToString();
                z4.Text = BigInteger.Add(nx4, ny4).ToString();
                z3.Text = BigInteger.Add(nx3, ny3).ToString();
                z2.Text = BigInteger.Add(nx2, ny2).ToString();
                z1.Text = BigInteger.Add(nx1, ny1).ToString();
                z0.Text = BigInteger.Add(nx0, ny0).ToString();
            }
            if (substruct_polin.Checked) //вычитание многочленов
            {
                z11.Text = BigInteger.Subtract(nx11, ny11).ToString();
                z10.Text = BigInteger.Subtract(nx10, ny10).ToString();
                z9.Text = BigInteger.Subtract(nx9, ny9).ToString();
                z8.Text = BigInteger.Subtract(nx8, ny8).ToString();
                z7.Text = BigInteger.Subtract(nx7, ny7).ToString();
                z6.Text = BigInteger.Subtract(nx6, ny6).ToString();
                z5.Text = BigInteger.Subtract(nx5, ny5).ToString();
                z4.Text = BigInteger.Subtract(nx4, ny4).ToString();
                z3.Text = BigInteger.Subtract(nx3, ny3).ToString();
                z2.Text = BigInteger.Subtract(nx2, ny2).ToString();
                z1.Text = BigInteger.Subtract(nx1, ny1).ToString();
                z0.Text = BigInteger.Subtract(nx0, ny0).ToString();
            }
            if (multych_polin.Checked) //умножение на число
            {
                BigInteger num1 = BigInteger.Parse(chislo1.Text);
                z11.Text = BigInteger.Multiply(nx11, num1).ToString();
                z10.Text = BigInteger.Multiply(nx10, num1).ToString();
                z9.Text = BigInteger.Multiply(nx9, num1).ToString();
                z8.Text = BigInteger.Multiply(nx8, num1).ToString();
                z7.Text = BigInteger.Multiply(nx7, num1).ToString();
                z6.Text = BigInteger.Multiply(nx6, num1).ToString();
                z5.Text = BigInteger.Multiply(nx5, num1).ToString();
                z4.Text = BigInteger.Multiply(nx4, num1).ToString();
                z3.Text = BigInteger.Multiply(nx3, num1).ToString();
                z2.Text = BigInteger.Multiply(nx2, num1).ToString();
                z1.Text = BigInteger.Multiply(nx1, num1).ToString();
                z0.Text = BigInteger.Multiply(nx0, num1).ToString();
            }
            if (proizv_polin.Checked) //производная многочлена
            {
                z11.Text = "0";
                z10.Text = BigInteger.Multiply(nx11, 11).ToString();
                z9.Text = BigInteger.Multiply(nx10, 10).ToString();
                z8.Text = BigInteger.Multiply(nx9, 9).ToString();
                z7.Text = BigInteger.Multiply(nx8, 8).ToString();
                z6.Text = BigInteger.Multiply(nx7, 7).ToString();
                z5.Text = BigInteger.Multiply(nx6, 6).ToString();
                z4.Text = BigInteger.Multiply(nx5, 5).ToString();
                z3.Text = BigInteger.Multiply(nx4, 4).ToString();
                z2.Text = BigInteger.Multiply(nx3, 3).ToString();
                z1.Text = BigInteger.Multiply(nx2, 2).ToString();
                z0.Text = BigInteger.Multiply(nx1, 1).ToString();
            }
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e) //отображения второго многочлена или нет, в зависимости от выбранного действия
        {
            if (multych_polin.Checked) //отображаем поле для ввода числа
            {
                chislo1.Visible = true;
                label34.Text = "Число";
                comboBox2.Visible = false;
                y8.Visible = false;
                y4.Visible = false;
                y0.Visible = false;
                y1.Visible = false;
                y2.Visible = false;
                y3.Visible = false;
                y5.Visible = false;
                y6.Visible = false;
                y7.Visible = false;
                y9.Visible = false;
                y10.Visible = false;
                y11.Visible = false;
                ly11.Visible = false;
                ly10.Visible = false;
                ly9.Visible = false;
                ly7.Visible = false;
                ly6.Visible = false;
                ly5.Visible = false;
                ly3.Visible = false;
                ly2.Visible = false;
                ly1.Visible = false;
                ly0.Visible = false;
                ly4.Visible = false;
                ly8.Visible = false;
            }
            else
            {
                chislo1.Visible = false;
                comboBox2.SelectedItem = "11";
                label34.Text = "Второй многочлен";
                comboBox2.Visible = true;
                y8.Visible = true;
                y4.Visible = true;
                y0.Visible = true;
                y1.Visible = true;
                y2.Visible = true;
                y3.Visible = true;
                y5.Visible = true;
                y6.Visible = true;
                y7.Visible = true;
                y9.Visible = true;
                y10.Visible = true;
                y11.Visible = true;
                ly11.Visible = true;
                ly10.Visible = true;
                ly9.Visible = true;
                ly7.Visible = true;
                ly6.Visible = true;
                ly5.Visible = true;
                ly3.Visible = true;
                ly2.Visible = true;
                ly1.Visible = true;
                ly0.Visible = true;
                ly4.Visible = true;
                ly8.Visible = true;
            }
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e) //отображения второго многочлена или нет, в зависимости от выбранного действия
        {
            {
                if (proizv_polin.Checked) //если выбранное дейстие - производная
                {
                    label34.Visible = false;
                    comboBox2.Visible = false;
                    y8.Visible = false;
                    y4.Visible = false;
                    y0.Visible = false;
                    y1.Visible = false;
                    y2.Visible = false;
                    y3.Visible = false;
                    y5.Visible = false;
                    y6.Visible = false;
                    y7.Visible = false;
                    y9.Visible = false;
                    y10.Visible = false;
                    y11.Visible = false;
                    ly11.Visible = false;
                    ly10.Visible = false;
                    ly9.Visible = false;
                    ly7.Visible = false;
                    ly6.Visible = false;
                    ly5.Visible = false;
                    ly3.Visible = false;
                    ly2.Visible = false;
                    ly1.Visible = false;
                    ly0.Visible = false;
                    ly4.Visible = false;
                    ly8.Visible = false;
                }
                else
                {
                    comboBox2.SelectedItem = "11";
                    label34.Visible = true;
                    comboBox2.Visible = true;
                    y8.Visible = true;
                    y4.Visible = true;
                    y0.Visible = true;
                    y1.Visible = true;
                    y2.Visible = true;
                    y3.Visible = true;
                    y5.Visible = true;
                    y6.Visible = true;
                    y7.Visible = true;
                    y9.Visible = true;
                    y10.Visible = true;
                    y11.Visible = true;
                    ly11.Visible = true;
                    ly10.Visible = true;
                    ly9.Visible = true;
                    ly7.Visible = true;
                    ly6.Visible = true;
                    ly5.Visible = true;
                    ly3.Visible = true;
                    ly2.Visible = true;
                    ly1.Visible = true;
                    ly0.Visible = true;
                    ly4.Visible = true;
                    ly8.Visible = true;
                }
            }
        }
    }
}
