using System;

namespace [solutionName].Application.Exceptions
{
    public class PasswordIncorrectException : Exception
    {
        public PasswordIncorrectException() : base(String.Format("Password is incorrect"))
        {

        }
    }
}