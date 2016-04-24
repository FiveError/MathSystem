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
            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {
                BigInteger num1 = BigInteger.Parse(textBox1.Text);
                BigInteger num2 = BigInteger.Parse(textBox2.Text);
                if (radioButton1.Checked)
                {
                    int res = BigInteger.Compare(num1, num2);
                    switch (res)
                    {
                        case 1:
                            {
                                textBox3.Text = 0.ToString();
                                break;
                            }
                        case -1:
                            {
                                textBox3.Text = 1.ToString();
                                break;
                            }
                        default:
                            {
                                textBox3.Text = res.ToString();
                                break;
                            }
                    }
                }
                if (radioButton2.Checked)
                {
                    textBox3.Text = BigInteger.Add(num1, num2).ToString();
                }
                if (radioButton3.Checked)
                {
                    textBox3.Text = BigInteger.Subtract(num1, num2).ToString();
                }
                if (radioButton4.Checked)
                {
                    textBox3.Text = BigInteger.Multiply(num1, num2).ToString();
                }
                if(radioButton5.Checked)
                {
                    if (!num2.IsZero)
                    {
                        textBox3.Text = BigInteger.Divide(num1, num2).ToString();
                    }
                    else
                    {
                        textBox3.Text = "На ноль делить нельзя";
                    }
                }
                if(radioButton6.Checked)
                {
                    if (!num2.IsZero)
                    {
                        BigInteger num3;
                        BigInteger.DivRem(num1, num2, out num3);
                        textBox3.Text = num3.ToString();
                    }
                    else
                    {
                        textBox3.Text = "На ноль делить нельзя";
                    }
                }
                if(radioButton7.Checked)
                {
                  
                        textBox3.Text = BigInteger.GreatestCommonDivisor(num1, num2).ToString();
                  
                }
                if(radioButton8.Checked)
                {
                    textBox3.Text = BigInteger.Divide(BigInteger.Abs(BigInteger.Multiply(num1, num2)), BigInteger.GreatestCommonDivisor(num1, num2)).ToString();
                }
                
            }
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = (sender as TextBox).Text ?? "";
          

            if (!(Char.IsDigit(e.KeyChar)))
            {
                if ( (e.KeyChar != (char)Keys.Back) && (e.KeyChar != 45))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == 45 && text.Contains('-'))
                {
                    e.Handled = true;
                }
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                label4.Visible = true;
            }
            else
            {
                label4.Visible = false;
            }
        }

       
    }
}
