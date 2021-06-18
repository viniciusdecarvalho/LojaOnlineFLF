using System;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.Services;
using LojaOnlineFLF.WebAPI.Controllers;
using LojaOnlineFLF.WebAPI.Services;
using LojaOnlineFLF.WebAPI.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LojaOnlineFLF.LojaWebAPI.Tests.Controllers
{
    public class AcessoControllerLoginTests
    {
        [Fact]
        public async Task DeveRetornarSucessoETokenParaLoginValido()
        {
            var login = new Login() { Usuario = "usuario", Senha = "senha" };
            var funcionario = new Services.Funcionario();
            var token = new Autenticacao();

            var mockAcessosRepository = new Mock<IAcessosService>();
            mockAcessosRepository
                .Setup(a => a.ValidarAcessoAsync(login))
                    .ReturnsAsync(funcionario);

            var mockAuthService = new Mock<IAuthService>();
            mockAuthService
                .Setup(a => a.Autenticar(It.IsAny<Afirmacao>()))
                    .Returns(token);

            var controller = new AcessosController(mockAcessosRepository.Object, mockAuthService.Object);

            var result = await controller.ValidarAcesso(login);

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, (result.Result as StatusCodeResult).StatusCode);
            Assert.Equal(token, result?.Value);
        }

        [Fact]
        public async Task DeveRetornarFalhaParaLoginInvalido()
        {
            Services.Funcionario funcionario = null;
            var login = It.IsAny<Login>();

            var mockAcessosService = new Mock<IAcessosService>();
            mockAcessosService
                .Setup(a => a.ValidarAcessoAsync(login))
                    .ReturnsAsync(funcionario);

            var mockAuthService = new Mock<IAuthService>();
            
            var controller = new AcessosController(mockAcessosService.Object, mockAuthService.Object);

            var result = await controller.ValidarAcesso(login);

            Assert.NotNull(result.Result);
            Assert.Equal(StatusCodes.Status400BadRequest, (result.Result as StatusCodeResult).StatusCode);            
        }
    }
}
