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
using BombitaTP2.Exceptions;

namespace BombitaTP2.Tests.ObjetosAlmacenablesFixture
{
    /* [TestFixture]
     public class BombaToleToleTest
     {
         private Bombita _bombita;
         private Mapa _mapa;
         private Coordenada _coordenada;
         private BombaToleTole _bombaToleTole;
       
         private Cecilio _enemigoCecilio;
         private LopezReggaeAlado _enemigoLopezReggaeAlado;
         private LopezReggae _enemigoLopezReggae;

         private Molotov _molotov;
         private ToleTole _toleTole;
         private Proyectil _proyectil;

         private BloqueCemento _bloqueCemento;
         private BloqueAcero _bloqueAcero;
         private BloqueLadrillos _bloqueLadrillo;

         Direccion _direccion;

         [SetUp]
         public void SetUp()
         {
             // Arrange
             _coordenada = new Coordenada(0, 0);
             _mapa = new Mapa(10, 10);

             _bombaToleTole = new BombaToleTole(_coordenada, _mapa);
             _bombita = new Bombita(_coordenada, _mapa);
             _enemigoCecilio = new Cecilio(_coordenada, _mapa);
             _enemigoLopezReggaeAlado = new LopezReggaeAlado(_coordenada, _mapa);
             _enemigoLopezReggae = new LopezReggae(_coordenada, _mapa);

             _molotov = new Molotov(_mapa);
             _toleTole = new ToleTole(_mapa);
             _direccion = new DireccionAbajo();
             _proyectil = new Proyectil(5, 5, _mapa, _direccion);

             _bloqueCemento = new BloqueCemento(_coordenada, _mapa);
             _bloqueAcero = new BloqueAcero(_coordenada, _mapa);
             _bloqueLadrillo = new BloqueLadrillos(_coordenada, _mapa);
         }
        
         [Test]
         public void TestCrearBombaToleToleConPosicion()
         {
             //Assert
             Assert.AreEqual(_bombaToleTole.Coordenada.CoordenadaX, 0);
             Assert.AreEqual(_bombaToleTole.Coordenada.CoordenadaY, 0);
             Assert.AreEqual(_bombaToleTole.Radio, 2);
             Assert.IsInstanceOf(typeof(ToleTole), _bombaToleTole.Armamento);   
         }

         [Test]
         public void TestAplicarEfectoToletoleEnABombita()
         {
             // Arrange
             Assert.IsInstanceOf(typeof(Molotov), _bombita.Armamento);

             // Act
             _bombaToleTole.AplicarEfecto(_bombita);

             // Assert
             Assert.IsInstanceOf(typeof(ToleTole), _bombita.Armamento);
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
             _bombaToleTole.ColisionarCon(_enemigoCecilio);

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
             _bombaToleTole.ColisionarCon(_enemigoLopezReggae);

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
             _bombaToleTole.ColisionarCon(_enemigoLopezReggaeAlado);

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
             Assert.IsInstanceOf(typeof(Molotov), _bombita.Armamento);
             _bombaToleTole.ColisionarCon(_bombita);
             Assert.IsInstanceOf(typeof(ToleTole), _bombita.Armamento);            
         }

         [Test]
         public void TestImpactarMolotov()
         {
             // Arrange - Estado inicial
             Assert.AreEqual(_bombaToleTole.Coordenada.CoordenadaX, 0);
             Assert.AreEqual(_bombaToleTole.Coordenada.CoordenadaY, 0);
             Assert.AreEqual(_bombaToleTole.Radio, 2);
             Assert.IsInstanceOf(typeof(ToleTole), _bombaToleTole.Armamento);   

             // Act
             _bombaToleTole.Impactar(_molotov);

             // Assert - Estado final igual
             Assert.AreEqual(_bombaToleTole.Coordenada.CoordenadaX, 0);
             Assert.AreEqual(_bombaToleTole.Coordenada.CoordenadaY, 0);
             Assert.AreEqual(_bombaToleTole.Radio, 2);
             Assert.IsInstanceOf(typeof(ToleTole), _bombaToleTole.Armamento);   
         }

         [Test]
         public void TestImpactarToleTole()
         {
             // Arrange - Estado inicial
             Assert.AreEqual(_bombaToleTole.Coordenada.CoordenadaX, 0);
             Assert.AreEqual(_bombaToleTole.Coordenada.CoordenadaY, 0);
             Assert.AreEqual(_bombaToleTole.Radio, 2);
             Assert.IsInstanceOf(typeof(ToleTole), _bombaToleTole.Armamento);

             // Act
             _bombaToleTole.Impactar(_toleTole);

             // Assert - Estado final igual
             Assert.AreEqual(_bombaToleTole.Coordenada.CoordenadaX, 0);
             Assert.AreEqual(_bombaToleTole.Coordenada.CoordenadaY, 0);
             Assert.AreEqual(_bombaToleTole.Radio, 2);
             Assert.IsInstanceOf(typeof(ToleTole), _bombaToleTole.Armamento);
         }

         [Test]
         public void TestImpactarProyectil()
         {
             // Arrange - Estado inicial
             Assert.AreEqual(_bombaToleTole.Coordenada.CoordenadaX, 0);
             Assert.AreEqual(_bombaToleTole.Coordenada.CoordenadaY, 0);
             Assert.AreEqual(_bombaToleTole.Radio, 2);
             Assert.IsInstanceOf(typeof(ToleTole), _bombaToleTole.Armamento);

             // Act
             _bombaToleTole.Impactar(_proyectil);

             // Assert - Estado final igual
             Assert.AreEqual(_bombaToleTole.Coordenada.CoordenadaX, 0);
             Assert.AreEqual(_bombaToleTole.Coordenada.CoordenadaY, 0);
             Assert.AreEqual(_bombaToleTole.Radio, 2);
             Assert.IsInstanceOf(typeof(ToleTole), _bombaToleTole.Armamento);
         }    

         [Test]
         public void TestAlmacenarBloqueEnCemento()
         {
             // Act - Assert
             Assert.IsTrue(_bombaToleTole.AlmacenarEn(_bloqueCemento));
             //Assert.IsInstanceOf(_bloqueCemento.ObjetoAlmacenado, typeof(BloqueCemento));
         }

         [Test]
         public void TestAlmacenarBloqueLadrillo()
         {
             Assert.IsTrue(_bombaToleTole.AlmacenarEn(_bloqueLadrillo));
         }
 

     }

     */
}
