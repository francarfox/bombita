using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BombitaTP2.Escenario;
using BombitaTP2.Personajes;
using BombitaTP2.Obstaculos;
using BombitaTP2.Armamento;

namespace BombitaTP2.Tests.PersonajesFixture
{
    [TestFixture]
    public class CecilioTests
    {
        private Mapa _mapa;
        private Cecilio _cecilio;


        [Test]
        public void TestCorrectaActivacionArmamento()
        {
            _mapa = new Mapa(100, 100);
            _cecilio = new Cecilio(new Coordenada(50,50), _mapa);
            List<IObjetoDeMapa> objetosColisionados;
            _mapa.AgregarObjeto(_cecilio);

            _cecilio.Atacar();
            RealizarCicloVivirPersonaje(_cecilio, 20);

            objetosColisionados = _mapa.BuscarColisiones(_cecilio);

            string resultadoEsperado = "Molotov";
            string resultadoActual = objetosColisionados.ElementAt(0).GetType().Name;

            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }

        [Test]
        public void TestSiAlQuererAvansarHayObstaculoNoAvanza()
        {
            Coordenada coordenadaActual;
            _mapa = new Mapa(100, 100);
            _cecilio = new Cecilio(new Coordenada(50, 50), _mapa);
            _mapa.AgregarObjeto(_cecilio);
            BloqueLadrillos bloqueLadrillo = new BloqueLadrillos(new Coordenada(51, 50), _mapa);
            _mapa.AgregarObjeto(bloqueLadrillo);

            _cecilio.ActivarMovimiento(Direccion.Derecha);
            RealizarCicloVivirPersonaje(_cecilio, 20);
            coordenadaActual = _cecilio.Coordenada;

            Assert.AreEqual(50, coordenadaActual.CoordenadaX);
            Assert.AreEqual(50, coordenadaActual.CoordenadaY);
        }

        [Test]
        public void TestAlImpactarConMolotovSeDestruye()
        {
            _mapa = new Mapa(100, 100);
            _cecilio = new Cecilio(new Coordenada(50,50), _mapa);
            CreadorMolotov creadorMolotov = new CreadorMolotov();
            Molotov molotov = (Molotov)creadorMolotov.FabricarBomba(_mapa, new Coordenada(54, 50));
            _mapa.AgregarObjeto(_cecilio);

            _cecilio.ImpactarCon(molotov);

            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_cecilio));
        }

        [Test]
        public void TestAlImpactarConProyectilSeDestruye()
        {
            _mapa = new Mapa(100, 100);
            _cecilio = new Cecilio(new Coordenada(50, 50), _mapa);
            _mapa.AgregarObjeto(_cecilio);
            CreadorProyectil creadorProyectil = new CreadorProyectil();
            Proyectil proyectil = creadorProyectil.FabricarProyectil(_mapa, new Coordenada(57, 50), Direccion.Arriba);

            _cecilio.ImpactarCon(proyectil);

            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_cecilio));
        }

        #region [Metodos adicionales para Testeo]
        private void RealizarCicloVivirPersonaje(IObjetoVivo personaje, int retardoMovimiento)
        {
            for (int i = 0; i < (retardoMovimiento + 1); i++)
            {
                personaje.Vivir();
            }
        }

        #endregion

    }
}
