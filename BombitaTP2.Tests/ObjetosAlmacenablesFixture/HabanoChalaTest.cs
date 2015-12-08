using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BombitaTP2.ObjetosAlmacenables;
using BombitaTP2.Personajes;
using BombitaTP2.Armamento;
using BombitaTP2;
using BombitaTP2.Escenario;
using BombitaTP2.Obstaculos;

namespace BombitaTP2.Tests.ObjetosAlmacenablesFixture
{
    /*
    [TestFixture]
    public class HabanoChalaTest
    {
        HabanoChala _habano1;
        HabanoChala _habano2;
        HabanoChala _habano3;

        Mapa _mapa1;
        Coordenada _coordenada1;
        Mapa _mapa2;
        Coordenada _coordenada2;
        Mapa _mapa3;
        Coordenada _coordenada3;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            _mapa1 = new Mapa(10, 10);
            _coordenada1 = new Coordenada(3, 4);
            _mapa2 = new Mapa(30, 30);
            _coordenada2 = new Coordenada(34, 34);
            _mapa3 = new Mapa(40, 40);
            _coordenada3 = new Coordenada(80, 80);


            _habano1 = new HabanoChala(_coordenada1, _mapa1);
            _habano2 = new HabanoChala(_coordenada2, _mapa2);
            _habano3 = _habano1;

        }
        
        [Test]
        public void TestGuardarEnDisco()
        {
            //Assert
            if (!this._habano1.NodoProcesado)
                this._habano1.Guardar();

//            if (!this._habano2.NodoProcesado)
  //              this._habano2.Guardar();

    //        if (!this._habano3.NodoProcesado)
      //          this._habano3.Guardar();
        }

    }
  /*  [TestFixture]
    public class HabanoChalaTest
    {
        private HabanoChala _habanoChala;

        private Bombita _bombita;
        private Mapa _mapa;
        private Coordenada _coordenada;

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

                    _habanoChala = new HabanoChala(_coordenada, _mapa);

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
                public void TestCrearHabanoChalaConPosicion()
                {
                    //Assert
                    Assert.AreEqual(_habanoChala.Coordenada.CoordenadaX, 0);
                    Assert.AreEqual(_habanoChala.Coordenada.CoordenadaY, 0);
                    Assert.AreEqual(_habanoChala.Radio, 2);
                    Assert.AreEqual(_habanoChala.Aceleracion, 1);
                }

                [Test]
                public void TestAplicarEfectoHabanoChalaEnABombita()
                {
                    // Arrange
                    Assert.AreEqual(_bombita.MovimientoPersonaje.TiempoDeRetardo, 2);

                    // Act
                    _habanoChala.AplicarEfecto(_bombita);
            
                    // Assert
                    Assert.AreEqual(_bombita.MovimientoPersonaje.TiempoDeRetardo, 1);
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
                    _habanoChala.ColisionarCon(_enemigoCecilio);

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
                    _habanoChala.ColisionarCon(_enemigoLopezReggae);

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
                    _habanoChala.ColisionarCon(_enemigoLopezReggaeAlado);

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
                    Assert.AreEqual(_bombita.MovimientoPersonaje.TiempoDeRetardo, 2);
                    _habanoChala.ColisionarCon(_bombita);
                    Assert.AreEqual(_bombita.MovimientoPersonaje.TiempoDeRetardo, 1);
                }

                [Test]
                public void TestImpactarMolotov()
                {
                    // Arrange - Estado inicial
                    Assert.AreEqual(_habanoChala.Coordenada.CoordenadaX, 0);
                    Assert.AreEqual(_habanoChala.Coordenada.CoordenadaY, 0);
                    Assert.AreEqual(_habanoChala.Radio, 2);
                    Assert.AreEqual(_habanoChala.Aceleracion, 1);   

                    // Act
                    _habanoChala.Impactar(_molotov);

                    // Assert - Estado final igual
                    Assert.AreEqual(_habanoChala.Coordenada.CoordenadaX, 0);
                    Assert.AreEqual(_habanoChala.Coordenada.CoordenadaY, 0);
                    Assert.AreEqual(_habanoChala.Radio, 2);
                    Assert.AreEqual(_habanoChala.Aceleracion, 1);   
                }

                [Test]
                public void TestImpactarToleTole()
                {
                    // Arrange - Estado inicial
                    Assert.AreEqual(_habanoChala.Coordenada.CoordenadaX, 0);
                    Assert.AreEqual(_habanoChala.Coordenada.CoordenadaY, 0);
                    Assert.AreEqual(_habanoChala.Radio, 2);
                    Assert.AreEqual(_habanoChala.Aceleracion, 1);   

                    // Act
                    _habanoChala.Impactar(_toleTole);

                    // Assert - Estado final igual
                    Assert.AreEqual(_habanoChala.Coordenada.CoordenadaX, 0);
                    Assert.AreEqual(_habanoChala.Coordenada.CoordenadaY, 0);
                    Assert.AreEqual(_habanoChala.Radio, 2);
                    Assert.AreEqual(_habanoChala.Aceleracion, 1);   
                }

                [Test]
                public void TestImpactarProyectil()
                {
                    // Arrange - Estado inicial
                    Assert.AreEqual(_habanoChala.Coordenada.CoordenadaX, 0);
                    Assert.AreEqual(_habanoChala.Coordenada.CoordenadaY, 0);
                    Assert.AreEqual(_habanoChala.Radio, 2);
                    Assert.AreEqual(_habanoChala.Aceleracion, 1);   

                    // Act
                    _habanoChala.Impactar(_proyectil);

                    // Assert - Estado final igual
                    Assert.AreEqual(_habanoChala.Coordenada.CoordenadaX, 0);
                    Assert.AreEqual(_habanoChala.Coordenada.CoordenadaY, 0);
                    Assert.AreEqual(_habanoChala.Radio, 2);
                    Assert.AreEqual(_habanoChala.Aceleracion, 1);   
                }    

                [Test]
                public void TestAlmacenarBloqueEnCemento()
                {
                    // Act - Assert
                    Assert.IsTrue(_habanoChala.AlmacenarEn(_bloqueCemento));
                }

                [Test]
                public void TestAlmacenarBloqueLadrillo()
                {
                    Assert.IsTrue(_habanoChala.AlmacenarEn(_bloqueLadrillo));
                }

            }
         */
}
