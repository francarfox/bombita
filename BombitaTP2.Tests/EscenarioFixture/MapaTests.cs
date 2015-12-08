using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BombitaTP2.Personajes;
using BombitaTP2.Obstaculos;
using BombitaTP2.Escenario;

namespace BombitaTP2.Tests.EscenarioFixture
{
    [TestFixture]
    public class MapaTests
    {
        private Mapa _mapa;
        private Cecilio _cecilio;
        private Bombita _bombita;
        private BloqueAcero _bloque;


      
        [Test]
        public void TestSiExisteColisionDevuelveListaColisionadosCorrecta()
        {
            bool fueColisionado = true;
            List<IObjetoDeMapa> objetosColisionados = new List<IObjetoDeMapa>();
            _mapa = new Mapa(50, 50);
            _cecilio = new Cecilio(new Coordenada(20, 20), _mapa);
            _bombita = new Bombita(new Coordenada(20, 20), _mapa);
            _bloque = new BloqueAcero(new Coordenada(20, 20), _mapa);
            _mapa.AgregarObjeto(_cecilio);
            _mapa.AgregarObjeto(_bombita);
            _mapa.AgregarObjeto(_bloque);

            objetosColisionados = _mapa.BuscarColisiones(_bombita);

            int numeroColisionados = 2;
            Assert.AreEqual(numeroColisionados, objetosColisionados.Count);

            Assert.AreEqual(fueColisionado , objetosColisionados.Contains(_cecilio));
            Assert.AreEqual(fueColisionado , objetosColisionados.Contains(_bloque));            
        }

        [Test]
        public void TestQueElObjetoQueColisionaNoEsDevueltoEnLaListaDeColisionados()
        {
            bool resultadoEsperado = false;
            bool resultadoActual;

            List<IObjetoDeMapa> objetosColisionados = new List<IObjetoDeMapa>();

            _mapa = new Mapa(50, 50);
            _cecilio = new Cecilio(new Coordenada(20, 20), _mapa);
            _bombita = new Bombita(new Coordenada(20, 20), _mapa);
            _bloque = new BloqueAcero(new Coordenada(20, 20), _mapa);
            _mapa.AgregarObjeto(_cecilio);
            _mapa.AgregarObjeto(_bombita);
            _mapa.AgregarObjeto(_bloque);

            objetosColisionados = _mapa.BuscarColisiones(_bombita);

            resultadoActual = objetosColisionados.Contains(_bombita);
            Assert.AreEqual(resultadoEsperado, resultadoActual);

        }

    }
}
