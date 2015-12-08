using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BombitaTP2.Escenario;
using BombitaTP2.Personajes;
using BombitaTP2.Armamento;
using BombitaTP2.Obstaculos;
using BombitaTP2.ObjetosAlmacenables;
using BombitaTP2.Desarrollo_de_Juego;

namespace BombitaTP2.Tests.PersonajesFixture
{
    [TestFixture]
    public class BombitaTests
    {
        private Mapa _mapa;
        private Bombita _bombita;
        private Coordenada _coordenadaBombita;

        [TestFixtureSetUp]
        public void SetUp()
        {
            
            _coordenadaBombita = new Coordenada(50, 50);
            
        }

        [Test]
        public void TestCorrectaActivacionArmamento()
        {
            _mapa = new Mapa(100, 100);
            _bombita = new Bombita(_coordenadaBombita, _mapa);            
            _bombita.AgregarObservadorDeBombita(new Nivel(1)); 
            List<IObjetoDeMapa> objetosColisionados;
            _mapa.AgregarObjeto(_bombita);

            _bombita.Atacar();
            RealizarCicloVivirPersonaje(_bombita, 20);
            
            objetosColisionados =  _mapa.BuscarColisiones(_bombita);

            string resultadoEsperado = "Molotov";
            string resultadoActual = objetosColisionados.ElementAt(0).GetType().Name;

            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }

        [Test]
        public void TestAlEntrarEnContactoConEnemigoSeDestruye()
        {
            _mapa = new Mapa(100, 100);
            _bombita = new Bombita(_coordenadaBombita, _mapa);
            Coordenada coordenadaCecilio = new Coordenada(51,50);
            Cecilio cecilio = new Cecilio(coordenadaCecilio, _mapa);
            _mapa.AgregarObjeto(_bombita);
            _mapa.AgregarObjeto(cecilio);

            _bombita.ActivarMovimiento(Direccion.Derecha);
            RealizarCicloVivirPersonaje(_bombita, 20);
                        
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bombita));
        }

        [Test]
        public void TestAlImpactarConMolotovSeDestruye()
        {
            _mapa = new Mapa(100, 100);
            _bombita = new Bombita(_coordenadaBombita, _mapa);
            CreadorMolotov creadorMolotov = new CreadorMolotov();
            Molotov molotov = (Molotov)creadorMolotov.FabricarBomba(_mapa, new Coordenada(54, 50));
            _mapa.AgregarObjeto(_bombita);

            _bombita.ImpactarCon(molotov);

            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bombita));
        }

        [Test]
        public void TestAlImpactarConToleToleSeDestruye()
        {
            _mapa = new Mapa(100, 100);
            _bombita = new Bombita(_coordenadaBombita, _mapa);            
            CreadorToleTole creadorToleTole = new CreadorToleTole();
            ToleTole toleTole = (ToleTole)creadorToleTole.FabricarBomba(_mapa, new Coordenada(54, 50));
            _mapa.AgregarObjeto(_bombita);

            _bombita.ImpactarCon(toleTole);

            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bombita));
        }

        [Test]
        public void TestAlImpactarConProyectilSeDestruye()
        {
            _mapa = new Mapa(100, 100);
            _bombita = new Bombita(_coordenadaBombita, _mapa);
            _mapa.AgregarObjeto(_bombita);
            CreadorProyectil creadorProyectil = new CreadorProyectil();
            Proyectil proyectil = creadorProyectil.FabricarProyectil(_mapa, new Coordenada(57, 50), Direccion.Arriba);
            
            _bombita.ImpactarCon(proyectil);

            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bombita));
        }

        

        [Test]
        public void TestSiAlQuererAvansarHayObstaculoNoAvanza()
        {
            Coordenada coordenadaActual;            
            _mapa = new Mapa(100, 100);
            _bombita = new Bombita(new Coordenada(50,50), _mapa);
            _mapa.AgregarObjeto(_bombita);
            BloqueLadrillos bloqueLadrillo = new BloqueLadrillos(new Coordenada(51, 50), _mapa);
            _mapa.AgregarObjeto(bloqueLadrillo);

            _bombita.ActivarMovimiento(Direccion.Derecha);
            RealizarCicloVivirPersonaje(_bombita, 20);
            coordenadaActual = _bombita.Coordenada;

            Assert.AreEqual(50, coordenadaActual.CoordenadaX);
            Assert.AreEqual(50, coordenadaActual.CoordenadaY);
        }

        [Test]
        public void TestAlAPlicarleEfectoHabanoAvanzaMasRapido()
        {
            _mapa = new Mapa(100, 100);
            _bombita = new Bombita(new Coordenada(10, 10), _mapa);
            HabanoChala habanoChala = new HabanoChala(new Coordenada(5, 5), _mapa);
            int nuevoRetardoMovimiento = 15;
            int retardoMovimiento = 20;                        
            Coordenada coordenadaActual;

            _bombita.ActivarMovimiento(Direccion.Derecha);
            RealizarCicloVivirPersonaje(_bombita, retardoMovimiento);
            _bombita.AplicarEfecto(habanoChala);
            _bombita.ActivarMovimiento(Direccion.Derecha);
            RealizarCicloVivirPersonaje(_bombita, nuevoRetardoMovimiento);
            coordenadaActual = _bombita.Coordenada;

            Assert.AreEqual(12, coordenadaActual.CoordenadaX);
            Assert.AreEqual(10, coordenadaActual.CoordenadaY);
        }

        [Test]
        public void TestAlAPlicarleEfectoBombaToleTolePlantaDichasBombas()
        {
            _mapa = new Mapa(100, 100);
            _bombita = new Bombita(_coordenadaBombita, _mapa);            
            _bombita.AgregarObservadorDeBombita(new Nivel(1));
            List<IObjetoDeMapa> objetosColisionados;
            _mapa.AgregarObjeto(_bombita);
            BombaToleTole bombaToleTole = new BombaToleTole(new Coordenada(60, 60), _mapa);
            _bombita.AplicarEfecto(bombaToleTole);

            _bombita.Atacar();
            RealizarCicloVivirPersonaje(_bombita, 20);
            //Busco colisiones,ya que Bombita quedaria al lado de la bomba, y la estaria tocando..
            objetosColisionados = _mapa.BuscarColisiones(_bombita);

            string resultadoEsperado = "ToleTole";
            string resultadoActual = objetosColisionados.ElementAt(0).GetType().Name;

            Assert.AreEqual(resultadoEsperado, resultadoActual);
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
