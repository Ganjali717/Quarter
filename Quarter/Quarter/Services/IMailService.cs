using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit;
using Quarter.Models;

namespace Quarter.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(SendEmail mailRequest);
    }
}
