using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Sumput_Beta
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public static double firstNum = 0;
        public static double secondNum = 0;
        public double xnum = 0;
        public double ynum = 0;
        bool zeroClick = false;
        public static int operand = 0;
        public bool resetdisplay = false;
        public int display567 = 0;
        public static int equ = 0;
        public bool hodl = false;
        public bool cbrak = false;
        public bool pt = true;
        public bool overload = false;
        public bool numClickLast = false;
        public bool operationClickLast = false;
        public static double[][] brackey = new double[99][];
        public static int count = 0;
        public static double store1 = 0;
        public static int store2 = 0;
        public bool radian = false;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            theNum(1);
        }
        private void two_Click(object sender, RoutedEventArgs e)
        {
            theNum(2);
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            theNum(3);
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            theNum(4);
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            theNum(5);
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            theNum(6);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            theNum(7);
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            theNum(8);
        }


        private void nine_Click(object sender, RoutedEventArgs e)
        {
            theNum(9);
        }


        private void zero_Click(object sender, RoutedEventArgs e)
        {
            zeroClick = true;
            theNum(0);
        }

        public void theNum(int a)
        {
            if (!cbrak)
            {
                int thisNum = a;
                if (display.Text.Length < 13)
                {
                    if (display.Text == "0") 
                    {
                        display.Text = Convert.ToString(thisNum);
                    }
                    else if (resetdisplay)
                    {
                        display.Text = Convert.ToString(thisNum);
                        resetdisplay = false;
                    }
                    else
                    {
                        display.Text = display.Text + Convert.ToString(thisNum);
                    }
                }
                else if (resetdisplay)
                {
                    display.Text = Convert.ToString(thisNum);
                    resetdisplay = false;
                }
                overload = false;
                numClickLast = true;
                operationClickLast = false;
            }
        }


        private void point_Click(object sender, RoutedEventArgs e)
        {
            if (pt)
            {
                if (display.Text.Length < 13)
                {
                    if (display.Text == "0")
                    {
                        display.Text = "0.";
                    }
                    else if (resetdisplay)
                    {
                        display.Text = "0.";
                        resetdisplay = false;
                    }
                    else
                    {
                        display.Text = display.Text + ".";
                    }

                }
                else if (resetdisplay)
                {
                    display.Text = "0.";
                    resetdisplay = false;
                }
            }
            pt = false;
            overload = false;
            numClickLast = true;
            operationClickLast = false;
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            display.Text = "0";
            firstNum = 0;
            secondNum = 0;
            resetdisplay = false;
            pt = true;
            equ = 0;
            overload = false;
            double[][] brackey = new double[99][];
            store1 = 0;
            store2 = 0;
            count = 0;
            brak.Text = "0";
            display2.Text = "";
            hodl = false;
            numClickLast = false;
            operationClickLast = false;
            display567 = 0;
            xnum = 0;
            ynum = 0;
            cbrak = false;
            zeroClick = false;
            todo.Visibility = Visibility.Collapsed;
        }

        private void addition_Click(object sender, RoutedEventArgs e)
        {
            Operation(1);
        }

        private void subtraction_Click(object sender, RoutedEventArgs e)
        {
            Operation(2);
        }

        private void multiplication_Click(object sender, RoutedEventArgs e)
        {
            Operation(3);
        }

        private void division_Click(object sender, RoutedEventArgs e)
        {
            Operation(4);
        }

        public void Operation(int a)
        {
            xnum = firstNum;
            ynum = Convert.ToDouble(display.Text);
            bool hold = false;
            if (operand == 5 || operand == 6 || operand == 7)
                hold = true;

            if (!operationClickLast)
            {
                if (overload) { }
                else
                {
                    int sign = a;
                    if (sign == 5 || sign == 6 || sign == 7)
                        store2 = 0;


                    if (store1 == 1)
                    {
                        count--;
                        secondNum = Convert.ToDouble(display.Text);
                        if (equ == 0)
                        {
                            if (display567 != 0)
                            {
                                if (display567 == 5)
                                    display2.Text = display2.Text + "(" + xnum + ")^" + ynum;
                                if (display567 == 6)
                                    display2.Text = display2.Text + "rt" + ynum + "(" + xnum + ")";
                                if (display567 == 7)
                                    display2.Text = display2.Text + "log" + ynum + "(" + xnum + ")";
                                display567 = 0;
                            }
                            if (sign == 1)
                                display2.Text = display2.Text + " + ";
                            if (sign == 2)
                                display2.Text = display2.Text + " - ";
                            if (sign == 3)
                                display2.Text = display2.Text + " * ";
                            if (sign == 4)
                                display2.Text = display2.Text + " / ";
                            if (sign == 5)
                                display567 = 5;
                            if (sign == 6)
                                display567 = 6;
                            if (sign == 7)
                                display567 = 7;
                        }

                        calculation();
                        operand = sign;
                        if (overload) { }
                        else
                        {
                            secondNum = firstNum;
                            firstNum = brackey[count][0];
                            operand = Convert.ToInt32(brackey[count][1]);
                            calculation();
                            operand = sign;
                            store1 = 0;
                            store2 = 0;
                            resetdisplay = true;
                            pt = true;
                        }
                    }
                    else
                    {
                        if (store2 == 1)
                            store2 = 0;
                        if ((firstNum == 0 && !zeroClick) || equ == 1)
                        {
                            firstNum = Convert.ToDouble(display.Text);
                            if (equ == 1 && display567 == 0)
                                display2.Text = display.Text;
                            operand = sign;

                            if ((firstNum == 0 && !zeroClick) || equ != 1)
                                if (hodl)
                                    hodl = false;
                                else if (hold)
                                    hold = false;
                                else
                                    display2.Text = display2.Text + display.Text;
                            equ = 0;
                            if (display567 != 0)
                            {
                                if (display567 == 5)
                                    display2.Text = display2.Text + "(" + xnum + ")^" + ynum;
                                if (display567 == 6)
                                    display2.Text = display2.Text + "rt" + ynum + "(" + xnum + ")";
                                if (display567 == 7)
                                    display2.Text = display2.Text + "log" + ynum + "(" + xnum + ")";
                                display567 = 0;
                            }
                            if (sign == 1)
                                display2.Text = display2.Text + " + ";
                            if (sign == 2)
                                display2.Text = display2.Text + " - ";
                            if (sign == 3)
                                display2.Text = display2.Text + " * ";
                            if (sign == 4)
                                display2.Text = display2.Text + " / ";
                            if (sign == 5)
                                display567 = 5;
                            if (sign == 6)
                                display567 = 6;
                            if (sign == 7)
                                display567 = 7;
                        }
                        else
                        {
                            secondNum = Convert.ToDouble(display.Text);
                            if (hodl)
                                hodl = false;
                            else if (hold)
                                hold = false;
                            else
                                display2.Text = display2.Text + display.Text;
                            if (display567 != 0)
                            {
                                if (display567 == 5)
                                    display2.Text = display2.Text + "(" + xnum + ")^" + ynum;
                                if (display567 == 6)
                                    display2.Text = display2.Text + "rt" + ynum + "(" + xnum + ")";
                                if (display567 == 7)
                                    display2.Text = display2.Text + "log" + ynum + "(" + xnum + ")";
                                display567 = 0;
                            }
                            if (sign == 1)
                                display2.Text = display2.Text + " + ";
                            if (sign == 2)
                                display2.Text = display2.Text + " - ";
                            if (sign == 3)
                                display2.Text = display2.Text + " * ";
                            if (sign == 4)
                                display2.Text = display2.Text + " / ";
                            if (sign == 5)
                                display567 = 5;
                            if (sign == 6)
                                display567 = 6;
                            if (sign == 7)
                                display567 = 7;
                            calculation();
                            operand = sign;

                        }
                        resetdisplay = true;
                        pt = true;
                    }
                    cbrak = false;
                    numClickLast = false;
                    operationClickLast = true;
                    return;
                }
            }
            zeroClick = false;
        }
        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if (display.Text == "111" && firstNum == 0)
            {
                todo.Visibility = Visibility.Visible;
            }
            xnum = firstNum;
            ynum = Convert.ToDouble(display.Text);
            if (!operationClickLast)
            {
                if (!overload)
                {
                    store2 = 0;
                    if (store1 == 1)
                    {
                        count--;
                        secondNum = Convert.ToDouble(display.Text);
                        calculation();
                        if (overload) { }
                        else
                        {
                            secondNum = firstNum;
                            firstNum = brackey[count][0];
                            operand = Convert.ToInt32(brackey[count][1]);
                            calculation();
                            store1 = 0;
                            store2 = 0;
                            operand = 0;
                            resetdisplay = true;
                            equ = 1;
                            pt = true;
                        }
                    }
                    else
                    {
                        if ((firstNum == 0 && !zeroClick) || operand == 0)
                        {
                            firstNum = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(firstNum);
                        }
                        else
                        {
                            secondNum = Convert.ToDouble(display.Text);
                            if (hodl)
                                hodl = false;
                            else if (display567 == 0)
                                display2.Text = display2.Text + display.Text;
                            calculation();
                            if (display567 != 0)
                            {
                                if (display567 == 5)
                                    display2.Text = display2.Text + "(" + xnum + ")^" + ynum;
                                if (display567 == 6)
                                    display2.Text = display2.Text + "rt" + ynum + "(" + xnum + ")";
                                if (display567 == 7)
                                    display2.Text = display2.Text + "log" + ynum + "(" + xnum + ")";
                                display567 = 0;
                            }
                            display2.Text = display2.Text + " = " + firstNum;
                        }
                        operand = 0;
                        resetdisplay = true;
                        equ = 1;
                        pt = true;
                    }
                    cbrak = false;
                    numClickLast = true;
                    operationClickLast = false;
                }
            }

        }
        public void calculation()
        {
            if (operand == 1)
                firstNum = Convert.ToDouble(firstNum + secondNum);
            if (operand == 2)
                firstNum = Convert.ToDouble(firstNum - secondNum);
            if (operand == 3)
                firstNum = firstNum * secondNum;
            if (operand == 4)
                firstNum = firstNum / secondNum;
            if (operand == 5)
                firstNum = Math.Pow(firstNum, secondNum);
            if (operand == 6)
                firstNum = Math.Pow(firstNum, 1 / secondNum);
            if (operand == 7)
                firstNum = Math.Log(firstNum, secondNum);
            secondNum = 0;
            if (Convert.ToDouble(firstNum) > 9999999999999)
            {
                display.Text = "E: # is too long";
                firstNum = 0;
                secondNum = 0;
                resetdisplay = false;
                pt = true;
                equ = 0;
                overload = true;
            }
            else
            {
                display.Text = Convert.ToString(firstNum);
            }

            return;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)// -/+ button
        {
            if (!overload)
            {
                display.Text = Convert.ToString(0 - Convert.ToDouble(display.Text));
            }


        }

        private void openbrack_Click(object sender, RoutedEventArgs e)
        {
            if (operationClickLast)
            {
                brackey[count] = new double[] { Convert.ToDouble(firstNum), operand };
                firstNum = 0;
                operand = 0;
                resetdisplay = true;
                count++;
                brak.Text = Convert.ToString(count);
                display2.Text = display2.Text + "( ";
            }
        }

        private void closebrack_Click(object sender, RoutedEventArgs e)
        {
            xnum = firstNum;
            ynum = Convert.ToDouble(display.Text);
            if (!operationClickLast)
            {
                if (firstNum == 0)
                {
                    count--;
                    brak.Text = Convert.ToString(count);
                    secondNum = Convert.ToDouble(display.Text);
                    firstNum = brackey[count][0];
                    operand = Convert.ToInt32(brackey[count][1]);
                    if (hodl)
                        display2.Text = display2.Text + " )";
                    else
                        display2.Text = display2.Text + display.Text + " )";
                }
                else
                {
                    if (count != 0)
                    {
                        count--;
                        brak.Text = Convert.ToString(count);
                        secondNum = Convert.ToDouble(display.Text);
                        if (display567 != 0)
                        {
                            if (display567 == 5)
                                display2.Text = display2.Text + "(" + xnum + ")^" + ynum + " )";
                            if (display567 == 6)
                                display2.Text = display2.Text + "rt" + ynum + "(" + xnum + ")" + " )";
                            if (display567 == 7)
                                display2.Text = display2.Text + "log" + ynum + "(" + xnum + ")" + " )";
                            display567 = 0;
                        }
                        else if (cbrak)
                            display2.Text = display2.Text + " )";
                        else if (equ != 1)
                        {
                            if (hodl)
                                display2.Text = display2.Text + " )";
                            else
                                display2.Text = display2.Text + display.Text + " )";
                        }
                        else
                        {
                            display2.Text = display2.Text + " )";
                            equ = 0;
                        }
                        calculation();
                        secondNum = firstNum;
                        firstNum = brackey[count][0];
                        operand = Convert.ToInt32(brackey[count][1]);

                    }
                }
                hodl = true;
                cbrak = true;
            }
        }

        private void square_Click(object sender, RoutedEventArgs e)
        {
            if (!overload)
                if (numClickLast)
                {
                    double asdf = Convert.ToDouble(display.Text);
                    double fdsa = asdf * asdf;
                    display.Text = Convert.ToString(fdsa);
                    if (display567 == 0)
                        display2.Text = display2.Text + "(" + asdf + ")^2";
                    hodl = true;
                    numClickLast = false;
                }

        }

        private void root_Click(object sender, RoutedEventArgs e) //square root
        {
            if (!overload)
            {
                if (numClickLast)
                {
                    double asdf = Convert.ToDouble(display.Text);
                    display.Text = Convert.ToString(Math.Sqrt(asdf));
                    if (display567 == 0)
                        display2.Text = display2.Text + "sqrt(" + asdf + ")";
                    hodl = true;
                    numClickLast = false;
                }
            }
        }

        private void exponent_Click(object sender, RoutedEventArgs e)
        {
            if (store2 != 1)
            {

                if (firstNum == 0)
                {
                    hodl = true;
                    Operation(5);
                    store2 = 1;
                    resetdisplay = true;
                }
                else
                {
                    brackey[count] = new double[] { Convert.ToDouble(firstNum), operand };
                    firstNum = Convert.ToDouble(display.Text);
                    secondNum = 0;
                    operand = 0;
                    resetdisplay = true;
                    count++;
                    hodl = true;
                    Operation(5);
                    store1 = 1;
                    store2 = 1;
                }
                cbrak = false;
            }

        }

        private void rt_Click(object sender, RoutedEventArgs e)
        {
            if (store2 == 1) { }
            else if (firstNum == 0)
            {
                hodl = true;
                Operation(6);
                store2 = 1;
                resetdisplay = true;
            }
            else
            {
                brackey[count] = new double[] { Convert.ToDouble(firstNum), operand };
                firstNum = Convert.ToDouble(display.Text);
                secondNum = 0;
                operand = 0;
                resetdisplay = true;
                count++;
                hodl = true;
                Operation(6);
                store1 = 1;
                store2 = 1;
            }
        }


        private void sin_Click(object sender, RoutedEventArgs e)
        {
            double fdsa = Convert.ToDouble(display.Text);
            if (!overload)
            {
                if (numClickLast)
                {
                    if (Math.Sin(30) != 0.5)
                    {
                        if (radian)
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Sin(asdf));
                        }
                        else
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Sin(asdf * Math.PI / 180));
                        }
                    }
                    else
                    {
                        if (!radian)
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Sin(asdf));
                        }
                        else
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Sin(asdf * 180 / Math.PI));
                        }
                    }
                    display2.Text = display2.Text + "sin(" + fdsa + ")";
                    hodl = true;
                }
            }
        }

        private void asin_Click(object sender, RoutedEventArgs e)
        {
            double fdsa = Convert.ToDouble(display.Text);
            if (!overload)
            {
                if (numClickLast)
                {
                    if (Math.Sin(30) != 0.5)
                    {
                        if (radian)
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Asin(asdf));
                        }
                        else
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Asin(asdf) * 180 / Math.PI);
                        }
                    }
                    else
                    {
                        if (!radian)
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Asin(asdf));
                        }
                        else
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Asin(asdf * 180 / Math.PI));
                        }
                    }
                    display2.Text = display2.Text + "Asin(" + fdsa + ")";
                    hodl = true;
                }
            }
        }

        private void cos_Click(object sender, RoutedEventArgs e)
        {
            double fdsa = Convert.ToDouble(display.Text);
            if (!overload)
            {
                if (numClickLast)
                {
                    if (Math.Sin(30) != 0.5)
                    {
                        if (radian)
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Cos(asdf));
                        }
                        else
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Cos(asdf * Math.PI / 180));
                        }
                    }
                    else
                    {
                        if (!radian)
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Cos(asdf));
                        }
                        else
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Cos(asdf * 180 / Math.PI));
                        }
                    }
                    display2.Text = display2.Text + "cos(" + fdsa + ")";
                    hodl = true;
                }
            }
        }

        private void acos_Click(object sender, RoutedEventArgs e)
        {
            double fdsa = Convert.ToDouble(display.Text);
            if (!overload)
            {
                if (numClickLast)
                {
                    if (Math.Sin(30) != 0.5)
                    {
                        if (radian)
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Acos(asdf));
                        }
                        else
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Acos(asdf) * 180 / Math.PI);
                        }
                    }
                    else
                    {
                        if (!radian)
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Acos(asdf));
                        }
                        else
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Acos(asdf * 180 / Math.PI));
                        }
                    }
                    display2.Text = display2.Text + "Acos(" + fdsa + ")";
                    hodl = true;
                }
            }
        }

        private void tan_Click(object sender, RoutedEventArgs e)
        {
            double fdsa = Convert.ToDouble(display.Text);
            if (!overload)
            {
                if (numClickLast)
                {
                    if (Math.Sin(30) != 0.5)
                    {
                        if (radian)
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Tan(asdf));
                        }
                        else
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Tan(asdf * Math.PI / 180));
                        }
                    }
                    else
                    {
                        if (!radian)
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Tan(asdf));
                        }
                        else
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Tan(asdf * 180 / Math.PI));
                        }
                    }
                    display2.Text = display2.Text + "tan(" + fdsa + ")";
                    hodl = true;
                }
            }

        }


        private void atan_Click(object sender, RoutedEventArgs e)
        {
            double fdsa = Convert.ToDouble(display.Text);
            if (!overload)
            {
                if (numClickLast)
                {
                    if (Math.Sin(30) != 0.5)
                    {
                        if (radian)
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Atan(asdf));
                        }
                        else
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Atan(asdf) * 180 / Math.PI);
                        }
                    }
                    else
                    {
                        if (!radian)
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Atan(asdf));
                        }
                        else
                        {
                            double asdf = Convert.ToDouble(display.Text);
                            display.Text = Convert.ToString(Math.Atan(asdf * 180 / Math.PI));
                        }
                    }
                    display2.Text = display2.Text + "Atan(" + fdsa + ")";
                    hodl = true;
                }
            }
        }

        private void log_Click(object sender, RoutedEventArgs e)
        {
            if (!overload)
            {
                if (numClickLast)
                {
                    double asdf = Convert.ToDouble(display.Text);
                    display.Text = Convert.ToString(Math.Log10(asdf));
                    if (display567 == 0)
                        display2.Text = display2.Text + "log(" + asdf + ")";
                    hodl = true;
                }
            }
        }

        private void rad_Click(object sender, RoutedEventArgs e)
        {

            radian = (!radian);
            string r = "Rad";
            string d = "Deg";
            if (radian)
                rde.Text = r;
            else
                rde.Text = d;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (numClickLast && equ == 0)
            {
                display.Text = display.Text.Remove(display.Text.Length - 1);
                if (display.Text == "")
                    numClickLast = false;
            }
        }

        private void pi_Click(object sender, RoutedEventArgs e)
        {
            if (!overload)
            {
                if (!numClickLast)
                {
                    display.Text = Convert.ToString(Math.PI);
                    display2.Text = display2.Text + "π";
                    hodl = true;
                }
                numClickLast = true;
                operationClickLast = false;
            }
        }

        private void logx_Click(object sender, RoutedEventArgs e)
        {
            if (store2 == 1) { }
            else if (firstNum == 0)
            {
                hodl = true;
                Operation(7);
                store2 = 1;
                resetdisplay = true;
            }
            else
            {
                brackey[count] = new double[] { Convert.ToDouble(firstNum), operand };
                firstNum = Convert.ToDouble(display.Text);
                secondNum = 0;
                resetdisplay = true;
                count++;
                hodl = true;
                Operation(7);
                store1 = 1;
                store2 = 1;
            }
        }
    }
}
