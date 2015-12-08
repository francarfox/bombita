using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BombitaTP2.Personajes;
using BombitaTP2.Escenario;
using BombitaTP2.Obstaculos;

namespace BombitaTP2.Tests.PersonajesFixture
{
    //Se testean los métodos comunes a todos los Personajes,los implementados en la clase PersonajeAbstracto
    [TestFixture]
    public class PersonajeTests
    {
        private Mapa _mapa;


        [TestFixtureSetUp]
        public void SetUp()
        {
            _mapa = new Mapa(50, 50);

        }

        [Test]
        public void TestCorrectoFuncionamientoMovimientoDerecha()
        {
            Coordenada coordenada = new Coordenada(20,10);
            Bombita bombita = new Bombita(coordenada, _mapa);

            bombita.ActivarMovimiento(Direccion.Derecha);
            RealizarCicloVivirPersonaje(bombita, 20);
            

            Coordenada nuevaCoordenada = bombita.Coordenada;
            Assert.AreEqual(21, nuevaCoordenada.CoordenadaX);
            Assert.AreEqual(10, nuevaCoordenada.CoordenadaY);

            bombita.ActivarMovimiento(Direccion.Derecha);
            RealizarCicloVivirPersonaje(bombita, 20);
            bombita.ActivarMovimiento(Direccion.Derecha);
            RealizarCicloVivirPersonaje(bombita, 20);
            bombita.ActivarMovimiento(Direccion.Derecha);
            RealizarCicloVivirPersonaje(bombita, 20);

            nuevaCoordenada = bombita.Coordenada;
            Assert.AreEqual(24, nuevaCoordenada.CoordenadaX);
            Assert.AreEqual(10, nuevaCoordenada.CoordenadaY);            
        }

        [Test]
        public void TestCorrectoFuncionamientoMovimientoIzquierda()
        {
            Coordenada coordenada = new Coordenada(10, 5);
            Bombita bombita = new Bombita(coordenada, _mapa);

            bombita.ActivarMovimiento(Direccion.Izquierda);
            RealizarCicloVivirPersonaje(bombita, 20);


            Coordenada nuevaCoordenada = bombita.Coordenada;
            Assert.AreEqual(9, nuevaCoordenada.CoordenadaX);
            Assert.AreEqual(5, nuevaCoordenada.CoordenadaY);

            bombita.ActivarMovimiento(Direccion.Izquierda);
            RealizarCicloVivirPersonaje(bombita, 20);
            bombita.ActivarMovimiento(Direccion.Izquierda);
            RealizarCicloVivirPersonaje(bombita, 20);
            bombita.ActivarMovimiento(Direccion.Izquierda);
            RealizarCicloVivirPersonaje(bombita, 20);

            nuevaCoordenada = bombita.Coordenada;
            Assert.AreEqual(6, nuevaCoordenada.CoordenadaX);
            Assert.AreEqual(5, nuevaCoordenada.CoordenadaY);
        }

        [Test]
        public void TestCorrectoFuncionamientoMovimientoArriba()
        {
            Coordenada coordenada = new Coordenada(10, 5);
            Bombita bombita = new Bombita(coordenada, _mapa);

            bombita.ActivarMovimiento(Direccion.Arriba);
            RealizarCicloVivirPersonaje(bombita, 20);


            Coordenada nuevaCoordenada = bombita.Coordenada;
            Assert.AreEqual(10, nuevaCoordenada.CoordenadaX);
            Assert.AreEqual(4, nuevaCoordenada.CoordenadaY);

            bombita.ActivarMovimiento(Direccion.Arriba);
            RealizarCicloVivirPersonaje(bombita, 20);
            bombita.ActivarMovimiento(Direccion.Arriba);
            RealizarCicloVivirPersonaje(bombita, 20);
            bombita.ActivarMovimiento(Direccion.Arriba);
            RealizarCicloVivirPersonaje(bombita, 20);

            nuevaCoordenada = bombita.Coordenada;
            Assert.AreEqual(10, nuevaCoordenada.CoordenadaX);
            Assert.AreEqual(1, nuevaCoordenada.CoordenadaY);
        }

        [Test]
        public void TestCorrectoFuncionamientoMovimientoAbajo()
        {
            Coordenada coordenada = new Coordenada(10, 20);
            Bombita bombita = new Bombita(coordenada, _mapa);

            bombita.ActivarMovimiento(Direccion.Abajo);
            RealizarCicloVivirPersonaje(bombita, 20);


            Coordenada nuevaCoordenada = bombita.Coordenada;
            Assert.AreEqual(10, nuevaCoordenada.CoordenadaX);
            Assert.AreEqual(21, nuevaCoordenada.CoordenadaY);

            bombita.ActivarMovimiento(Direccion.Abajo);
            RealizarCicloVivirPersonaje(bombita, 20);
            bombita.ActivarMovimiento(Direccion.Abajo);
            RealizarCicloVivirPersonaje(bombita, 20);
            bombita.ActivarMovimiento(Direccion.Abajo);
            RealizarCicloVivirPersonaje(bombita, 20);

            nuevaCoordenada = bombita.Coordenada;
            Assert.AreEqual(10, nuevaCoordenada.CoordenadaX);
            Assert.AreEqual(24, nuevaCoordenada.CoordenadaY);
        }

        [Test]
        public void TestSiEstaPorSalirFueraDelMapaNoSeMueve()
        {
            Coordenada coordenada = new Coordenada(10, 50);
            Bombita bombita = new Bombita(coordenada, _mapa);

            bombita.ActivarMovimiento(Direccion.Abajo);
            RealizarCicloVivirPersonaje(bombita, 20);


            Coordenada nuevaCoordenada = bombita.Coordenada;
            Assert.AreEqual(10, nuevaCoordenada.CoordenadaX);
            Assert.AreEqual(50, nuevaCoordenada.CoordenadaY);

            bombita.ActivarMovimiento(Direccion.Abajo);
            RealizarCicloVivirPersonaje(bombita, 20);
            bombita.ActivarMovimiento(Direccion.Abajo);
            RealizarCicloVivirPersonaje(bombita, 20);
            bombita.ActivarMovimiento(Direccion.Abajo);
            RealizarCicloVivirPersonaje(bombita, 20);

            nuevaCoordenada = bombita.Coordenada;
            Assert.AreEqual(10, nuevaCoordenada.CoordenadaX);
            Assert.AreEqual(50, nuevaCoordenada.CoordenadaY);

        }

        [Test]
        public void TestSiEstaEnContactoConOtroObjetoDevuelveTrue()
        {            
            Coordenada coordenadaCecilio = new Coordenada(20,20);
            Cecilio cecilio = new Cecilio(coordenadaCecilio, _mapa);
            Coordenada coordenadaBombita = new Coordenada(20, 20);
            Bombita bombita = new Bombita(coordenadaBombita,_mapa);
            Coordenada coordenadaObstaculo = new Coordenada(20, 20);
            BloqueAcero bloque = new BloqueAcero(coordenadaObstaculo, _mapa);
            bool resultadoActual;

            resultadoActual = bombita.EstaEnContactoCon(cecilio.Coordenada);
            Assert.AreEqual(true, resultadoActual);

            resultadoActual = bombita.EstaEnContactoCon(bloque.Coordenada);
            Assert.AreEqual(true, resultadoActual);            
        }

        [Test]
        public void TestSiNoEstaEnContactoConOtroObjetoDevuelveFalse()
        {
            Coordenada coordenadaCecilio = new Coordenada(20, 20);
            Cecilio cecilio = new Cecilio(coordenadaCecilio, _mapa);
            Coordenada coordenadaBombita = new Coordenada(10, 20);
            Bombita bombita = new Bombita(coordenadaBombita, _mapa);
            Coordenada coordenadaObstaculo = new Coordenada(30, 14);
            BloqueAcero bloque = new BloqueAcero(coordenadaObstaculo, _mapa);
            bool resultadoActual;

            resultadoActual = bombita.EstaEnContactoCon(cecilio.Coordenada);
            Assert.AreEqual(false, resultadoActual);

            resultadoActual = bombita.EstaEnContactoCon(bloque.Coordenada);
            Assert.AreEqual(false, resultadoActual);
        }

        [Test]
        public void TestSiIntentaSalirDelEscenarioNoQuedarseTrabadoEnElLimiteYSeguirMoviendose()
        {
            Coordenada coordenadaBombita = new Coordenada(1,50);
            Bombita bombita = new Bombita(coordenadaBombita, _mapa);

            bombita.ActivarMovimiento(Direccion.Abajo);
            RealizarCicloVivirPersonaje(bombita, 20);

            Coordenada coordenadaActual = bombita.Coordenada;
            Assert.AreEqual(1, coordenadaActual.CoordenadaX);
            Assert.AreEqual(50, coordenadaActual.CoordenadaY);

            bombita.ActivarMovimiento(Direccion.Arriba);
            RealizarCicloVivirPersonaje(bombita, 20);

            coordenadaActual = bombita.Coordenada;
            Assert.AreEqual(1, coordenadaActual.CoordenadaX);
            Assert.AreEqual(49, coordenadaActual.CoordenadaY);
        }
                
        #region [Metodos adicionales para Testeo]

        private void RealizarCicloVivirPersonaje(PersonajeAbstracto personaje,int retardoMovimiento)
        {
            for (int i = 0; i < (retardoMovimiento + 1); i++)
            {
                personaje.Vivir();
            }
        }

        #endregion

    }
}
