using System;
using System.Windows.Forms;
namespace calculatoor
{
    public partial class design : Form
    {
        double firstNumber = 0;
        string operation = "";
        bool startNewNumber = true;
        public design()
        {
            InitializeComponent();

           btnClear.Click += Clear_Click;

            btn0.Click += Number_Click;
            btn1.Click += Number_Click;
            btn2.Click += Number_Click;
            btn3.Click += Number_Click;
            btn4.Click += Number_Click;
            btn5.Click += Number_Click;
            btn6.Click += Number_Click;
            btn7.Click += Number_Click;
            btn8.Click += Number_Click;
            btn9.Click += Number_Click;

            btnDot.Click += Number_Click;
            btnPlus.Click += Operation_Click;
            btnMinus.Click += Operation_Click;
            btnMultiply.Click += Operation_Click;
            btnDivide.Click += Operation_Click;

            btnEqual.Click += Equal_Click;
            btnBackspace.Click += Backspace_Click;
        }

            private void button4_Click(object? sender, EventArgs e)
        {
            // Одоохондоо үйлдэл хийхгүй
        }

        private void btnBackspace_Click(object? sender, EventArgs e)
        {
            Backspace_Click(sender, e);
        }
        



        private void Number_Click(object? sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string value = btn.Text;

            if (startNewNumber)
            {
                txtTotal.Text = value == "." ? "0." : value;
                startNewNumber = false;
            }
            else if (value == ".")
            {
                if (!txtTotal.Text.Contains("."))
                {
                    txtTotal.Text += ".";
                }
            }
            else
            {
                if (txtTotal.Text == "0")
                    txtTotal.Text = value;
                else
                    txtTotal.Text += value;
            }
        }

        private void Operation_Click(object? sender, EventArgs e)
        {
            if (!double.TryParse(txtTotal.Text, out firstNumber))
                return;

            Button btn = (Button)sender;
            operation = btn.Text;

            if (operation == "×") operation = "*";
            if (operation == "÷") operation = "/";

            startNewNumber = true;
        }

        private void Equal_Click(object? sender, EventArgs e)
        {
            double secondNumber;

            if (!double.TryParse(txtTotal.Text, out secondNumber))
                return;

            double result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;

                case "-":
                case "−":
                    result = firstNumber - secondNumber;
                    break;

                case "*":
                case "×":
                    result = firstNumber * secondNumber;
                    break;

                case "/":
                case "÷":
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("0-д хувааж болохгүй!");
                        return;
                    }

                    result = firstNumber / secondNumber;
                    break;

                default:
                    return;
            }

            txtTotal.Text = result.ToString();
            startNewNumber = true;
            operation = "";
        }

        private void Backspace_Click(object? sender, EventArgs e)
        {
            if (startNewNumber)
                return;

            if (txtTotal.Text.Length > 1)
            
                txtTotal.Text = txtTotal.Text.Substring(
                    0, txtTotal.Text.Length - 1);
            
            else
           
                txtTotal.Text = "0";
        }
            private void Clear_Click(object? sender, EventArgs e)
        {
            txtTotal.Text = "0";
            firstNumber = 0;
            operation = "";
            startNewNumber = true;
        }
    }

}

