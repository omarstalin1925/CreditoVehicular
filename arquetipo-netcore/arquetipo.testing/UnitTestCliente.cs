using arquetipo.API.Controllers;
using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Models;
using arquetipo.Repository.Context;
using arquetipo.testing.Config;
using arquetipo.testing.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace arquetipo.testing
{
    [TestClass]
    public class UnitTestCliente 
    {
        public ICliente servicio;

        //public UnitTestCliente(ICliente _servicio)
        //{
        //    servicio = _servicio;
        //}

        [TestMethod]
        public async Task CrearCliente()
        {

            var context = ApplicationDbContextInMemory.Get();
            var servic = new ClienteServiceMock(context);
            var controller = new ClienteController(servic);

            Cliente nuevoCliente = new Cliente
            {
                PatioId = 1,
                Identificacion = "0603888547",
                Nombres = "Katherine",
                Apellidos = "Pullupaxi",
                Edad = 30,
                FechaNacimiento = System.DateTime.Now,
                Direccion = "Riobamba",
                Telefono = "098536254",
                EstadoCivil = "c",
                IdentificacionConyuge = "0603985478",
                NombreConyuge = "Omar Centeno",
                SujetoCredito = "s"
            };

            var respuesta = await controller.CrearCliente(nuevoCliente);
            //var respuesta = await controller.ConsultarClientes();
            var cantidad = await context.Clientes.CountAsync();
            Assert.AreEqual(1,cantidad);
            
        }
    }
}