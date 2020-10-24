using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrimeiraCalculadora
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;

        public MainPage()
        {
            InitializeComponent();
            onClear(new object(), new EventArgs()); 
        }
        void onClear(object sender, EventArgs e)
        {

            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.resultText.Text = "0";
        }

        void OnSelectNumber(object sender, EventArgs e)
        {
            //converter o sender para botão novamente:
            Button button = (Button)sender; // sender é o botão clicado
            string pressed = button.Text;

            if (this.resultText.Text == "0" || currentState < 0)
            {
                this.resultText.Text = "";
                if (currentState < 0)
                    currentState *= -1;

            }
                this.resultText.Text += pressed;

                double number;

                if (double.TryParse(this.resultText.Text, out number))
                {
                    this.resultText.Text = number.ToString("N0"); //fazer os números terem vírgulas e pontos
                    if (currentState == 1)
                    {
                        firstNumber = number;
                    }
                    else
                    {
                        secondNumber = number;
                    }
                }

            }

        void OnSelectOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
        }

        void OnCalculate(object sender, EventArgs e)
        {
            if(currentState == 2)
            {

                Double result = 0;

               if(mathOperator == "+")
                {
                    result = firstNumber + secondNumber;
                }
               if (mathOperator == "-")
                {
                    result = firstNumber - secondNumber;
                }
               if(mathOperator == "x")
                {
                    result = firstNumber * secondNumber;
                }
               if(mathOperator == "/")
                {
                    result = firstNumber / secondNumber;
                }

                this.resultText.Text = result.ToString("N0"); //fazer os números terem vírgulas e pontos
                firstNumber = result;
                currentState = -1;
            }
        }
        }

    }
      
    

