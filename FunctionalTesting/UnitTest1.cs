using System;
using Xunit;
using WebAppPipeline.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Lib;

namespace FunctionalTesting
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Individuos_Index_Controller()
        {
            var controller = new IndividuoController();
            var resultado = controller.Index();

            var resultadoView = Assert.IsType<ViewResult>(resultado);

            List<Individuo> lst = new List<Individuo>();

            lst.Add(new Individuo { Nome = "Sergio", Apelido = "Fontes", DataNasc = new DateTime(1998, 12, 23) });
            lst.Add(new Individuo { Nome = "Maria", Apelido = "Antunes", DataNasc = new DateTime(1998, 12, 23) });

            lst.Add(new Individuo { Nome = "José", Apelido = "Januário", DataNasc = new DateTime(1998, 12, 23) });

            List<Individuo> modelo = Assert.IsAssignableFrom<List<Individuo>>(resultadoView.ViewData.Model);

            //Assert.Equal(modelo.Count,lst.Count);

            Assert.All(modelo, x => Assert.Equal(lst[modelo.IndexOf(x)].Apelido, x.Apelido));

    

        }
    }
}
