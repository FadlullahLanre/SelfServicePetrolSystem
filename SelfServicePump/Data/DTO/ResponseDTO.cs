using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfServicePump.Data.DTO
{
    public class ResponseDTO
    {

        public string ErrorMessage { get; set; }
        public bool Status { get; set; }
        public ResponseDTO(string errorMessage, bool status)
        {
            this.ErrorMessage = errorMessage;
            this.Status = status;

        }
    }
}