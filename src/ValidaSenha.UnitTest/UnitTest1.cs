using FluentAssertions;
using NUnit.Framework;
using 
using ValidaSenha.Validators;

namespace ValidaSenha.UnitTest.Validators
{
    public class SenhaValidatorTests
    {
        [TestCase("", false)]
        [TestCase("aa", false)]
        [TestCase("ab", false)]
        [TestCase("AAAbbbCc", false)]
        [TestCase("AbTp9!foo", true)]
        [TestCase("AbTp91foo", false)]
        public void ÉValidaDeveValidarCorretamenteParaUmDigitoUmaMaiúsculaUmaMinúsculaUmCaracterEspecialENoveOuMaisCaracteres(string input, bool resultadoEsperado)
        {
            var senhaValidator = new SenhaValidator();
            var senha = new Senha { input = password };
            var éValida = senhaValidator.éValida(senha);

            éValida.Should().Be(resultadoEsperado);
        }
    }
}



