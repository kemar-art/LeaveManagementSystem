using LeaveManagementSystem.Application.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Contracts.EmailService
{
    public interface IEmailService
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}