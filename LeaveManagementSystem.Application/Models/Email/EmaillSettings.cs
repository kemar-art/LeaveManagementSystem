using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Models.Email
{
    public class EmaillSettings
    {
        public string ApiKey { get; set; } = string.Empty;
        public string FromAddress { get; set; } = string.Empty;
        public string FromName { get; set; } = string.Empty;
    }
}
