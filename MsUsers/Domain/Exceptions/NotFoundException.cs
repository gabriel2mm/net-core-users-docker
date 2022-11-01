using System;
using System.Net;
using MsUsers.Domain.Contracts;

namespace MsUsers.Domain.Exceptions
{
    public class NotFoundException : Exception, IError
    {
        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public string ErrorMessage => "Entity not found";

        private string? _errorDetail;

        public string ErrorDetail {
            get { return _errorDetail == null ? this.ErrorMessage : _errorDetail; }
            set { _errorDetail = value; }
        }

        public NotFoundException(string message) : base(message)
        {
            this.ErrorDetail = ErrorMessage;
        }

        public NotFoundException(string message, string detail) : base(message)
        {
            this.ErrorDetail = detail;
        }
    }
}

