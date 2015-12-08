using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BombitaTP2.Personajes;
using BombitaTP2;
using BombitaTP2.ObjetosAlmacenables;
using BombitaTP2.Escenario;
using BombitaTP2.Armamento;
using BombitaTP2.Obstaculos;

namespace BombitaTP2.Tests.ObjetosAlmacenablesFixture
{
/*    [TestFixture]
    public class TimerTest
    {
        private Timer _timer;

        private Mapa _mapa;
        private Coordenada _coordenada;

        private Bombita _bombita;
        private Cecilio _enemigoCecilio;
        private LopezReggaeAlado _enemigoLopezReggaeAlado;
        private LopezReggae _enemigoLopezReggae;

        private Molotov _molotov;
        private ToleTole _toleTole;
        private Proyectil _proyectil;

        private BloqueCemento _bloqueCemento;
        private BloqueAcero _bloqueAcero;
        private BloqueLadrillos _bloqueLadrillo;

        private Direccion _direccion;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            _coordenada = new Coordenada(0, 0);
            _mapa = new Mapa(10, 10);

            _timer = new Timer(_coordenada, _mapa);

            _bombita = new Bombita(_coordenada, _mapa);
            _enemigoCecilio = new Cecilio(_coordenada, _mapa);
            _enemigoLopezReggaeAlado = new LopezReggaeAlado(_coordenada, _mapa);
            _enemigoLopezReggae = new LopezReggae(_coordenada, _mapa);

            _direccion = new DireccionAbajo();
            _molotov = new Molotov(_mapa);
            _toleTole = new ToleTole(_mapa);
            _proyectil = new Proyectil(5, 5, _mapa, _direccion);

            _bloqueCemento = new BloqueCemento(_coordenada, _mapa);
            _bloqueAcero = new BloqueAcero(_coordenada, _mapa);
            _bloqueLadrillo = new BloqueLadrillos(_coordenada, _mapa);
        }

        [Test]
        public void TestCrearTimerConPosicion()
        {
            //Assert
            Assert.AreEqual(_timer.Coordenada.CoordenadaX, 0);
            Assert.AreEqual(_timer.Coordenada.CoordenadaY, 0);
            Assert.AreEqual(_timer.Radio, 2);
            Assert.AreEqual(_timer.Porcentaje, 50);
        }

        [Test]
        public void TestAplicarEfectoTimerEnABombita()
        {
            // Arrange
            BombaAbstracta bomba = (BombaAbstracta)_bombita.Armamento;
            Assert.AreEqual(bomba.Retardo, 1);

            // Act
            _timer.AplicarEfecto(_bombita);

            // Assert
            Assert.AreEqual(bomba.Retardo, 0.5);
        }

        [Test]
        public void TestColisionarConEnemigoCecilio()
        {

            // Arrange - Estado inicial
            Assert.AreEqual(_enemigoCecilio.Coordenada.CoordenadaX, 0);
            Assert.AreEqual(_enemigoCecilio.Coordenada.CoordenadaY, 0);
            Assert.AreEqual(_enemigoCecilio.Radio, 4);
            Assert.AreEqual(_enemigoCecilio.Resistencia, 5);
            Assert.IsInstanceOf(typeof(Molotov), _enemigoCecilio.Armamento);

            // Act
            _timer.ColisionarCon(_enemigoCecilio);

            // Assert - Estado final igual
            Assert.AreEqual(_enemigoCecilio.Coordenada.CoordenadaX, 0);
            Assert.AreEqual(_enemigoCecilio.Coordenada.CoordenadaY, 0);
            Assert.AreEqual(_enemigoCecilio.Radio, 4);
            Assert.AreEqual(_enemigoCecilio.Resistencia, 5);
            Assert.IsInstanceOf(typeof(Molotov), _enemigoCecilio.Armamento);
        }

        [Test]
        public void TestColisionarConEnemigoLopezReggae()
        {
            // Arrange - Estado inicial
            Assert.AreEqual(_enemigoLopezReggae.Coordenada.CoordenadaX, 0);
            Assert.AreEqual(_enemigoLopezReggae.Coordenada.CoordenadaY, 0);
            Assert.AreEqual(_enemigoLopezReggae.Radio, 4);
            Assert.AreEqual(_enemigoLopezReggae.Resistencia, 10);
            Assert.IsInstanceOf(typeof(Molotov), _enemigoLopezReggae.Armamento);

            // Act
            _timer.ColisionarCon(_enemigoLopezReggae);

            // Assert - Estado final igual
            Assert.AreEqual(_enemigoLopezReggae.Coordenada.CoordenadaX, 0);
            Assert.AreEqual(_enemigoLopezReggae.Coordenada.CoordenadaY, 0);
            Assert.AreEqual(_enemigoLopezReggae.Radio, 4);
            Assert.AreEqual(_enemigoLopezReggae.Resistencia, 10);
            Assert.IsInstanceOf(typeof(Molotov), _enemigoLopezReggae.Armamento);
        }

        [Test]
        public void TestColisionarConEnemigoLopezReggaeAlado()
        {
            // Arrange - Estado inicial
            Assert.AreEqual(_enemigoLopezReggaeAlado.Coordenada.CoordenadaX, 0);
            Assert.AreEqual(_enemigoLopezReggaeAlado.Coordenada.CoordenadaY, 0);
            Assert.AreEqual(_enemigoLopezReggaeAlado.Radio, 4);
            Assert.AreEqual(_enemigoLopezReggaeAlado.Resistencia, 5);
            Assert.IsInstanceOf(typeof(Molotov), _enemigoLopezReggaeAlado.Armamento);

            // Act
            _timer.ColisionarCon(_enemigoLopezReggaeAlado);

            // Assert - Estado final igual
            Assert.AreEqual(_enemigoLopezReggaeAlado.Coordenada.CoordenadaX, 0);
            Assert.AreEqual(_enemigoLopezReggaeAlado.Coordenada.CoordenadaY, 0);
            Assert.AreEqual(_enemigoLopezReggaeAlado.Radio, 4);
            Assert.AreEqual(_enemigoLopezReggaeAlado.Resistencia, 5);
            Assert.IsInstanceOf(typeof(Molotov), _enemigoLopezReggaeAlado.Armamento);
        }

        [Test]
        public void TestColisionarConBombita()
        {
            // Act - Assert
            BombaAbstracta bomba = (BombaAbstracta)_bombita.Armamento;
            Assert.AreEqual(bomba.Retardo, 1);
            _timer.ColisionarCon(_bombita);
            Assert.AreEqual(bomba.Retardo, 0.5);
        }

        [Test]
        public void TestImpactarMolotov()
        {
            // Arrange - Estado inicial
            Assert.AreEqual(_timer.Coordenada.CoordenadaX, 0);
            Assert.AreEqual(_timer.Coordenada.CoordenadaY, 0);
            Assert.AreEqual(_timer.Radio, 2);
            Assert.AreEqual(_timer.Porcentaje, 50);

            // Act
            _timer.Impactar(_molotov);

            // Assert - Estado final igual
            Assert.AreEqual(_timer.Coordenada.CoordenadaX, 0);
            Assert.AreEqual(_timer.Coordenada.CoordenadaY, 0);
            Assert.AreEqual(_timer.Radio, 2);
            Assert.AreEqual(_timer.Porcentaje, 50);
        }

        [Test]
        public void TestImpactarToleTole()
        {
            // Arrange - Estado inicial
            Assert.AreEqual(_timer.Coordenada.CoordenadaX, 0);
            Assert.AreEqual(_timer.Coordenada.CoordenadaY, 0);
            Assert.AreEqual(_timer.Radio, 2);
            Assert.AreEqual(_timer.Porcentaje, 50);

            // Act
            _timer.Impactar(_toleTole);

            // Assert - Estado final igual
            Assert.AreEqual(_timer.Coordenada.CoordenadaX, 0);
            Assert.AreEqual(_timer.Coordenada.CoordenadaY, 0);
            Assert.AreEqual(_timer.Radio, 2);
            Assert.AreEqual(_timer.Porcentaje, 50);
        }

        [Test]
        public void TestImpactarProyectil()
        {
            // Arrange - Estado inicial
            Assert.AreEqual(_timer.Coordenada.CoordenadaX, 0);
            Assert.AreEqual(_timer.Coordenada.CoordenadaY, 0);
            Assert.AreEqual(_timer.Radio, 2);
            Assert.AreEqual(_timer.Porcentaje, 50);

            // Act
            _timer.Impactar(_proyectil);

            // Assert - Estado final igual
            Assert.AreEqual(_timer.Coordenada.CoordenadaX, 0);
            Assert.AreEqual(_timer.Coordenada.CoordenadaY, 0);
            Assert.AreEqual(_timer.Radio, 2);
            Assert.AreEqual(_timer.Porcentaje, 50);
        }

        [Test]
        public void TestAlmacenarBloqueEnCemento()
        {
            // Act - Assert
            Assert.IsTrue(_timer.AlmacenarEn(_bloqueCemento));
        }

        [Test]
        public void TestAlmacenarBloqueLadrillo()
        {
            Assert.IsTrue(_timer.AlmacenarEn(_bloqueLadrillo));
        }

    }
    */
}
