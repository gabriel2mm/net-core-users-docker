using System;
using MsUsers.Domain.Contracts;
using System.Net;

namespace MsUsers.Domain.Exceptions
{
    public class UpdateException : Exception, IError
    {
        private string? _errorMessage;

        private string? _errorDetail;

        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public string ErrorMessage
        {
            get { return _errorMessage == null ? "Update failure." : _errorMessage; }
            set { _errorMessage = value; }
        }

        public string ErrorDetail
        {
            get { return _errorDetail == null ? this.ErrorMessage : _errorDetail; }
            set { _errorDetail = value; }
        }

        public UpdateException(string message) : base(message)
        {
            this.ErrorMessage = message;
        }

        public UpdateException(string message, string detail) : base(message)
        {
            this.ErrorMessage = message;
            this.ErrorDetail = detail;
        }
    }
}

