using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IValidPasswordService
    {
        bool validPassWord(string passWord);
    }
}
