using Mail.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail.Service.Services
{
    public interface IEmailService
    {
        void SendEmail(Message message);

    }
}
