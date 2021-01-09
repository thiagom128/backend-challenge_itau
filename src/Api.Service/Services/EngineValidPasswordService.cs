using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Service.Services
{
    public class EngineValidPasswordService : IEngineValidPasswordService
    {
        /*A SENHA ESTA VAZIA*/
        private bool IsEmptyPassword(string password) 
        {
            return password.Length == 0;
        }

        /*deve ter 9 caracteres ou mais*/
        private bool IsMinimoCaracteres(string password)
        {
            return password.Length >= 9;
        }

        /*A SENHA TEM CARACTER MINUSCULO*/
        private bool LowerCaseCharacter(string password)
        {
            int countCaracter = password.Length - Regex.Replace(password, "[a-z]", "").Length;
            return !(countCaracter == 0);
        }

        /*A SENHA TEM CARACTER MAIUSCULO*/
        private bool UpperCaseCharacter(string password)
        {
            int countCaracter = password.Length - Regex.Replace(password, "[A-Z]", "").Length;
            return (countCaracter > 0);
        }

        /* A SENHA TEM CARACTER ESPECIAL*/
        private bool SpecialCharacter(string password)
        {
            string semSpaco = Regex.Replace(password, "[a-zA-Z0-9]", "").Trim();
            int countCaracter = Regex.Replace(semSpaco, "[a-zA-Z0-9]", "").Length;

            return countCaracter > 0;
        }

        /*A SENHA TEM CARACTER REPETIDO*/
        private bool RepeatCharacter(string password)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(\w)*.*\1");
            bool repete = regex.IsMatch(password);
            return repete;            
        }

        public bool ValidPassword(string password)
        { 
            if (password==null)
              password = string.Empty;

            bool valid = false;
           
            valid = this.IsEmptyPassword(password);
            if (valid)
            {
                return false;
            }
            

            valid = this.IsMinimoCaracteres(password);
            if (!valid)
            {
                return false;
            }
          
            valid = this.LowerCaseCharacter(password);
            if (!valid)
            {
                return false;
            }
            valid = this.UpperCaseCharacter(password);
            if (!valid)
            {
                return false;
            }
            valid = this.SpecialCharacter(password);
            if (!valid)
            {
                return false;
            }
            valid = this.RepeatCharacter(password);
            if (valid)
            {
                return false;
            }
            return true;
        }
    }
}
