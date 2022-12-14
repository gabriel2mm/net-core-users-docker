using System;
using System.Net;

namespace MsUsers.Domain.Contracts
{
	public interface IError
	{
        public HttpStatusCode StatusCode { get; }

        public string ErrorMessage { get; set; }

        public string ErrorDetail { get; set; }
    }
}

