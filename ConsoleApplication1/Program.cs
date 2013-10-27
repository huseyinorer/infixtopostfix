using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayBasedStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stack<int> aa = new Stack<int>(10);
            //aa.Push(5);
            //aa.Push(11);
            //aa.printStack();
            //Console.WriteLine(aa.Pop());
            //Console.WriteLine(aa.Peek());
            //Console.WriteLine(aa.isEmpty());
            //Console.WriteLine(aa.isFull());
            //aa.printStack();


            string infix = "5*(3+7)+(2+3)*2";// u can change the function from here ... 
           
           
            Console.WriteLine("INFIX \t\t\t\t POSTFİX \t\t\t  Result");

            Console.Write(infix+"\t\t\t");
            Console.Write(InfixToPostfix(infix)+"\t\t\t     ");
            Console.WriteLine(PostfixEvaluate(InfixToPostfix(infix)));
            Console.ReadKey();
        }

        /*
         * Algorithm: Infix to postfix conversion
         * 1. Create an empty stack
         * 2. Convert the input string to a list by using string method split
         * 3. Scan the token from left to right
         *      If the token is operand append to output list(print)
         *      If the token is left parenthesis push it on the stack
         *      If the token is right parenthesis pop the stack until left parenthesis is removed,append each operator to the output list(print)
         *      If the token is an operator(/*-+) push it on the stack. However first remove any operators already on the stack that have higher or equal precedence and append them to the output list(print)
         * 4. When the input expression has been completely processed check the stack. Any operators still on the stack can be removed and appended to the output list(print)
         */
        static string InfixToPostfix(string s)
        {

            string postfix=null;
            Stack<string> Postfix = new Stack<string>(s.Length); 
           Stack<string> operand=new Stack<string>(s.Length);


            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '+' || s[i] == '-' || s[i] == '*' || s[i] == '/' || s[i] == '[')
                {
                    if (operand.isFull())
                    {
                        if (operand.Peek() == "/" || operand.Peek() == "*" && s[i] == '+' || s[i] == '-')
                        {


                            while (operand.isFull()) // we pop() all character until left paranthesis from stack....
                            {
                                if (operand.Peek() == "(")
                                {
                                    operand.Pop();

                                    break;
                                }
                                else
                                    postfix += operand.Pop();
                            }

                        }
                    }
                    operand.Push("" + s[i] + "");
                
                
                }
                else if (s[i] == ')' || s[i] == ']') //if next character is right paranthesis , POP() the stack until left paranthesis
                    while (operand.isFull())
                    {
                        if (operand.Peek() == "(")
                        {
                            operand.Pop();

                            break;
                        }
                        else
                            postfix += operand.Pop();//other characters adds to Result string...
                    }
                else
                    postfix = postfix + s[i];
            }

            while (operand.isFull())
            {
                
                postfix += operand.Pop();// when for loop finished , POP() all operand until stack is empty...
            }

			return postfix;
        }

        /*
         * Algorithm: Postfix Evaluation
         * 1. Create an operand stack
         * 2. Convert the input string to a list by using string method split
         * 3. Scan the token from left to right
         *      If the token is an operand push it to the stack
         *      If the token is an operator pop 2 operands from stack and do the operation(*+-/), then push the result to the stack
         * 4. Pop the stack and return the result
         */
        static double PostfixEvaluate(string exp)
        {

            Stack<string> expression = new Stack<string>(exp.Length);

            for (int i = 0; i < exp.Length; i++)
            {

                if (exp[i] != '+' && exp[i] != '-' && exp[i] != '/' && exp[i] != '*')
                {
                    expression.Push("" + exp[i] + "");// if character isnt a operand , we pust it to stack....
                }
                //then if a operand comes after the Numbers , we Pop() two time for calculate it...
                    if (exp[i] == '+')
                    {
                      

                        expression.Push((Convert.ToInt32(expression.Pop())+Convert.ToInt32(expression.Pop())).ToString());

                    }
                     if (exp[i] == '*')
                    {
                        
                        
                        expression.Push((Convert.ToInt32(expression.Pop()) * Convert.ToInt32(expression.Pop())).ToString());

                    }
                    if (exp[i] == '/')
                    {
                        int secondValue = Convert.ToInt32(expression.Pop());
                        int firstValue = Convert.ToInt32(expression.Pop());
                        expression.Push((firstValue / secondValue).ToString());

                    }
                     if (exp[i] == '-')
                    {
                        int secondValue = Convert.ToInt32(expression.Pop());
                        int firstValue = Convert.ToInt32(expression.Pop());
                        expression.Push((firstValue - secondValue).ToString());

                    }
                }
            //conver to Double and return it ..
			return Convert.ToDouble(expression.Pop());
        }
    }
}
