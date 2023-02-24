using System;
namespace MauiGithubSearch.Domain.exception
{
    // https://learn.microsoft.com/ja-jp/dotnet/standard/exceptions/how-to-create-user-defined-exceptions
    public class ApplicationException : Exception
    {
        public ApplicationException()
        {
        }
        public ApplicationException(string message) : base(message)
        {
        }

        public ApplicationException(string message, Exception inner) : base(message, inner)
        {
        }

    }
}

