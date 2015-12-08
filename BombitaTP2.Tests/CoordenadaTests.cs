using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BombitaTP2.Tests
{
    [TestFixture]
    public class CoordenadaTests
    {

        Coordenada _coordenadaUno;
        Coordenada _coordenadaDos;
        Coordenada _coordenadaTres;
        Coordenada _coordenadaCuatro;
        Coordenada _coordenadaCinco;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _coordenadaUno = new Coordenada(2, 2);
            _coordenadaDos = new Coordenada(5, 2);
            _coordenadaTres = new Coordenada(2, 6);
            _coordenadaCuatro = new Coordenada(8, 5);
            _coordenadaCinco = new Coordenada(10, 2);
        }

        [Test]
        public void TestCalculoCorrectoDeDistanciaAOtraCoordenada()
        {
            double resultadoActual;
            double resultadoEsperado;

            resultadoActual = _coordenadaUno.CalcularDistanciaConCoordenada(_coordenadaDos);
            resultadoEsperado = 3;
            Assert.AreEqual(resultadoEsperado, resultadoActual);


            resultadoActual = _coordenadaUno.CalcularDistanciaConCoordenada(_coordenadaTres);
            resultadoEsperado = 4;
            Assert.AreEqual(resultadoEsperado, resultadoActual);

            resultadoActual = _coordenadaDos.CalcularDistanciaConCoordenada(_coordenadaCuatro);
            resultadoEsperado = 4.24;
            Assert.AreEqual(resultadoEsperado, resultadoActual,0.03);

            resultadoActual = _coordenadaCuatro.CalcularDistanciaConCoordenada(_coordenadaCinco);
            resultadoEsperado = 3.60;
            Assert.AreEqual(resultadoEsperado, resultadoActual, 0.03);
        }
    }
}
