using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IEngineValidPasswordService
    {
        bool ValidPassword(string password="");
    }
}
