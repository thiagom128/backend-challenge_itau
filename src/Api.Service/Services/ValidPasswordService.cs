using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class ValidPasswordService : IValidPasswordService
    {
        private readonly IEngineValidPasswordService _serviceValidate;

        public ValidPasswordService(IEngineValidPasswordService engineValidPasswordService)
        {
            _serviceValidate = engineValidPasswordService;
        }

        public bool validPassWord(string passWord)
        {
            try
            {
                return _serviceValidate.ValidPassword(passWord);
            }
            catch
            {
                throw;
            }

        }
    }
}
