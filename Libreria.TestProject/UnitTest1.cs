using NUnit.Framework;
using Libreria;
using DataAccess;
using Models.Entities;
using System;

namespace Libreria.TestProject
{
    [TestFixture]
    public class Tests
    {
        private Libreria.Controllers.AutoresController _autores;
        [SetUp]
        public void Setup()
        {
            LibreriaContext context = new LibreriaContext();
            _autores = new Controllers.AutoresController(context);
        }

        [Test]
        public void Test1()
        {
            var result = _autores.Create(new Autore() { Nombre = null, Apellidos = "Shakespeare" });
            Assert.Pass("Error en argumentos enviados");
        }
    }
}