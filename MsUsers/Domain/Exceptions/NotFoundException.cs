using System;
using System.Net;
using MsUsers.Domain.Contracts;

namespace MsUsers.Domain.Exceptions
{
    public class NotFoundException : Exception, IError
    {
        private string? _errorMessage;

        private string? _errorDetail;

        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public string ErrorMessage
        {
            get { return _errorMessage == null ? "Entity not found." : _errorMessage; }
            set { _errorMessage = value; }
        }

        public string ErrorDetail
        {
            get { return _errorDetail == null ? this.ErrorMessage : _errorDetail; }
            set { _errorDetail = value; }
        }

        public NotFoundException(string message) : base(message)
        {
            this.ErrorMessage = message;
        }

        public NotFoundException(string message, string detail) : base(message)
        {
            this.ErrorMessage = message;
            this.ErrorDetail = detail;
        }
    }
}

