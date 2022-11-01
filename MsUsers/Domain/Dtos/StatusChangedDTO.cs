using System;

namespace MsUsers.Domain.Dtos
{
    public class StatusChangedDTO
    {
        public String Status { get; set; }
        public String Message { get; set; }

        public StatusChangedDTO(string status, string message)
        {
            this.Status = status;
            this.Message = message;
        }
    }
}

