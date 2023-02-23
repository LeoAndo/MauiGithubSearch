using System;
namespace MauiGithubSearch.Domain.exception
{
    public class ValidationException : ApplicationException
    {
        public ValidationException()
        {
        }
        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception inner) : base(message, inner)
        {
        }

    }

    public class InputValidationException : ValidationException
    {
        public InputValidationException()
        {
        }
        public InputValidationException(string message) : base(message)
        {
        }

        public InputValidationException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

