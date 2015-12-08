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
    public class LopezReggaeTests
    {
        private Mapa _mapa;
        private LopezReggae _lopez;

        
        [Test]
        public void TestSiAlQuererAvansarHayObstaculoNoAvanza()
        {
            Coordenada coordenadaActual;
            _mapa = new Mapa(100, 100);
            _lopez = new LopezReggae(new Coordenada(50, 50), _mapa);
            _mapa.AgregarObjeto(_lopez);
            BloqueLadrillos bloqueLadrillo = new BloqueLadrillos(new Coordenada(51, 50), _mapa);
            _mapa.AgregarObjeto(bloqueLadrillo);

            _lopez.ActivarMovimiento(Direccion.Derecha);
            RealizarCicloVivirPersonaje(_lopez, 20);
            coordenadaActual = _lopez.Coordenada;

            Assert.AreEqual(50, coordenadaActual.CoordenadaX);
            Assert.AreEqual(50, coordenadaActual.CoordenadaY);
        }

        [Test]
        public void TestAlImpactarConMolotovUnaSolaVezNoSeDestruye()
        {
            _mapa = new Mapa(100, 100);
            _lopez = new LopezReggae(new Coordenada(50, 50), _mapa);
            CreadorMolotov creadorMolotov = new CreadorMolotov();
            Molotov molotov = (Molotov)creadorMolotov.FabricarBomba(_mapa, new Coordenada(54, 50));
            _mapa.AgregarObjeto(_lopez);

            _lopez.ImpactarCon(molotov);

            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_lopez));
        }

        [Test]
        public void TestAlImpactarConMolotovDosVecesSeDestruye()
        {
            _mapa = new Mapa(100, 100);
            _lopez = new LopezReggae(new Coordenada(50, 50), _mapa);
            CreadorMolotov creadorMolotov = new CreadorMolotov();
            Molotov molotov = (Molotov)creadorMolotov.FabricarBomba(_mapa, new Coordenada(54, 50));
            _mapa.AgregarObjeto(_lopez);

            _lopez.ImpactarCon(molotov);
            _lopez.ImpactarCon(molotov);

            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_lopez));
        }

        [Test]
        public void TestAlImpactarConProyectilUnaSolaVezNoSeDestruye()
        {
            _mapa = new Mapa(100, 100);
            _lopez = new LopezReggae(new Coordenada(50, 50), _mapa);
            _mapa.AgregarObjeto(_lopez);
            CreadorProyectil creadorProyectil = new CreadorProyectil();
            Proyectil proyectil = creadorProyectil.FabricarProyectil(_mapa, new Coordenada(57, 50), Direccion.Arriba);

            _lopez.ImpactarCon(proyectil);

            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_lopez));
        }

        [Test]
        public void TestAlImpactarConProyectilDosVecesSeDestruye()
        {
            _mapa = new Mapa(100, 100);
            _lopez = new LopezReggae(new Coordenada(50, 50), _mapa);
            _mapa.AgregarObjeto(_lopez);
            CreadorProyectil creadorProyectil = new CreadorProyectil();
            Proyectil proyectil = creadorProyectil.FabricarProyectil(_mapa, new Coordenada(57, 50), Direccion.Arriba);

            _lopez.ImpactarCon(proyectil);
            _lopez.ImpactarCon(proyectil);

            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_lopez));
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
