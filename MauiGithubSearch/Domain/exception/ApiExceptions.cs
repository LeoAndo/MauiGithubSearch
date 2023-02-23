using System;
namespace MauiGithubSearch.Domain.exception
{
    public class ApiException : ApplicationException
    {
        public ApiException()
        {
        }
        public ApiException(string message) : base(message)
        {
        }

        public ApiException(string message, Exception inner) : base(message, inner)
        {
        }

    }

    public class UnAuthorizedException : ApiException
    {
        public UnAuthorizedException()
        {
        }
        public UnAuthorizedException(string message) : base(message)
        {
        }

        public UnAuthorizedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
    public class ForbiddenExeption : ApiException
    {
        public ForbiddenExeption()
        {
        }
        public ForbiddenExeption(string message) : base(message)
        {
        }

        public ForbiddenExeption(string message, Exception inner) : base(message, inner)
        {
        }
    }
    public class NetworkException : ApiException
    {
        public NetworkException()
        {
        }
        public NetworkException(string message) : base(message)
        {
        }

        public NetworkException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    public class UnprocessableEntityException : ApiException
    {
        public UnprocessableEntityException()
        {
        }
        public UnprocessableEntityException(string message) : base(message)
        {
        }

        public UnprocessableEntityException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    public class UnknownException : ApiException
    {
        public UnknownException()
        {
        }
        public UnknownException(string message) : base(message)
        {
        }

        public UnknownException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    public class NotFoundException : ApiException
    {
        public NotFoundException()
        {
        }
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }


    public class RedirectException : ApiException
    {
        public RedirectException()
        {
        }
        public RedirectException(string message) : base(message)
        {
        }

        public RedirectException(string message, Exception inner) : base(message, inner)
        {
        }
    }


    public class ServerException : ApiException
    {
        public ServerException()
        {
        }
        public ServerException(string message) : base(message)
        {
        }

        public ServerException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

