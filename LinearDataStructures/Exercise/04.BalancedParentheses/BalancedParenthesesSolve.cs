namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (parentheses.Length % 2 != 0)
            {
                return false;
            }

            Stack<char> stack = new Stack<char>();

            foreach (var bracket in parentheses)
            {
                if (bracket == '(' || bracket == '{' || bracket == '[')
                {
                    stack.Push(bracket);
                }
                else
                {
                    if (bracket == ')' && stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                    else if (bracket == '}' && stack.Peek() == '{')
                    {
                        stack.Pop();
                    }
                    else if (bracket == ']' && stack.Peek() == '[')
                    {
                        stack.Pop();
                    }
                }
            }

            if (stack.Any())
            {
                return false;
            }


            return true;
        }
    }
}
