using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projWolfeofMaloneNew

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



            private void btnCalculate_Click(object sender, EventArgs e)  //This is the event handler which is started by the users input by clicking the button
            {

                decimal decResult = 0m;//Initialises variable
                try
                {
                    if (IsValidData())//Checks input data is valid
                    {
                        decimal decOperand1 = Convert.ToDecimal(txtOperand1.Text); //This allows the user to enter a number into the textbox and the program  to store as a decimal value
                        string strOperator = txtOperator.Text; //This allows the user to select the metho that they want to use "+"
                        decimal decOperand2 = Convert.ToDecimal(txtOperand2.Text); //This allows the user to enter there second number into the textbox and the program  to store as a decimal value


                    decResult = Calculate(decOperand1, strOperator, decOperand2); //This calls the calculate function based on the two numbers and the operator passed to the function 
                        txtResult.Text = Math.Round(decResult, 2).ToString(); //This is used to take the answear from a decimal,2 decimal places, to text
                    }
                }
                catch
                {
                    MessageBox.Show("Contact System Administrator", "User message", MessageBoxButtons.OK, MessageBoxIcon.Warning);//Rounds the result to 2 decimal places and converts it to a string
                //to display in the text box
                }
            }




            private decimal Calculate(decimal decOp1, string strOp, decimal decOp2)//This function is called upon and accepts 3 parameters for the operands and operations
            {
                decimal decRes = 0m;//Initialises value
                switch (strOp)
                {
                    case "+":
                        decRes = decOp1 + decOp2;//If the user enters the + sign then it will add the operands
                        break;
                    case "-":
                        decRes = decOp1 - decOp2;//If the user enters the - sign then it will subtract the operands
                        break;
                    case "*":
                        decRes = decOp1 * decOp2;//If the user enters the * symbol it wil multiply the operands
                        break;
                    case "/":
                        decRes = decOp1 / decOp2;//If the user enters the / Symbol it will divide the operands
                        break;
                }
                return decRes;//Returns result
            }

            private bool IsDecimal(TextBox txtBox, string text)//This function is called upon and accepts 2 parameters for the text box and the text
        {
                bool valid = true;//Initialises value 
            try
                {
                    Convert.ToDecimal(txtBox.Text);//This converts the decimal to text for validation
                }
                catch
                {
                    valid = false;//Sets valid to false
                    MessageBox.Show(text + " must be a decimal"); //This is to inform the user that they need to enter a decimal
                }
                return valid;//Returns true or false
            }


            private bool IsOperator(TextBox txtBox, string text)//This function is called upon and accepts 2 parameters for the text box and the text
        {
                string validOperators;
                bool valid = true;//Initialises value
            validOperators = Convert.ToString(txtBox.Text);
                if (validOperators != "+" && validOperators != "-" && validOperators != "*" && validOperators != "/")//Checks for correct symbol
                {
                    MessageBox.Show(text + " must be + - * or /");//This lets the user know that they need to enter an operator
                    valid = false;//Sets valid to false
            }

                return valid;//Returns true or false
        }

            private bool IsPresent(TextBox txtBox, string text)//This function is called upon and accepts 2 parameters for the text box and the text
        {
                bool valid = true;//Initialises value
            if (txtBox.Text == "")
                {
                    valid = false;//Sets valid to false
                MessageBox.Show(text + " is required"); //This is to let them know that they need to enter what ever the system is asking for
                }
                return valid;//Returns true or false
        }

            private bool IsValidData()//Function to call other functions to check if data is valid 
            {
                return
                    IsPresent(txtOperand1, "First operand") && //This is used to remind the user to enter the first number 
                    IsPresent(txtOperator, "Operator") && //This isused to get the user to select there operator
                    IsPresent(txtOperand2, "Second operand") && //This is used to get the user to eneter there second number

                    IsDecimal(txtOperand1, "First operand") && //This is used to remind the user that the system requires a decimal not a letter 
                    IsDecimal(txtOperand2, "Second operand") && //This is used to remind the user that the system requires a decimal not a letter 

                    IsOperator(txtOperator, "Operator");
            }



            private void btnExit_Click(object sender, EventArgs e)//This is the event handler which is started by the users input by clicking the button
        {
                DialogResult result = MessageBox.Show("Are you sure?", "User message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);//Message to confirm 
                if (result == DialogResult.Yes)//IF yes closes form
                {
                    this.Close();
                }
            }
        }
    }
