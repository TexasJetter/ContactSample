using System;
using System.Collections.Generic;
using System.Text;

namespace Contact.Contracts
{
    public class BaseRequest
    {

    }
    public class BaseResponse
    {
        public bool Success { get; set; } = false;
        public string FailureInformation { get; set; } = string.Empty;
    }
}
