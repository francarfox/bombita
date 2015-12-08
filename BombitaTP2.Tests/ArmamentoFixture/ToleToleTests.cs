using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BombitaTP2.Armamento;
using BombitaTP2.Personajes;
using BombitaTP2.Escenario;
using BombitaTP2.Obstaculos;

namespace BombitaTP2.Tests.ArmamentoFixture
{
    public class ToleToleTests
    {
        private BombaAbstracta _toleTole;
        private Mapa _mapa;
        private Bombita _personajeUno;
        private Bombita _personajeDos;
        private Bombita _personajeTres;
        private Bombita _personajeCuatro;
        private Bombita _personajeCinco;
        private Bombita _personajeSeis;
        private Cecilio _personajeSiete;
        private Cecilio _personajeOcho;
        private Cecilio _personajeNueve;
        private BloqueAcero _bloqueAcero;
        private BloqueLadrillos _bloqueLadrillos;
        private BloqueLadrillos _bloqueLadrillosDos;
        private BloqueLadrillos _bloqueLadrillosTres;
        private BloqueAcero _bloqueAceroDos;
        private BloqueAcero _bloqueAceroTres;
        private BloqueAcero _bloqueAceroCuatro;
        private BloqueAcero _bloqueAceroCinco;
        private BloqueAcero _bloqueAceroSeis;
        private BloqueAcero _bloqueAceroSiete;
        private BloqueAcero _bloqueAceroOcho;
        private BloqueAcero _bloqueAceroNueve;
        private BloqueAcero _bloqueAceroDiez;
        private BloqueAcero _bloqueAceroOnce;
        


        [SetUp]
        public void SetUp()
        {
            _mapa = new Mapa(100, 100);
            _toleTole = (new CreadorToleTole()).FabricarBomba(_mapa, new Coordenada(50, 50));


            _personajeUno = new Bombita(new Coordenada(50, 47), _mapa);
            _personajeDos = new Bombita(new Coordenada(50, 48), _mapa);
            _personajeTres = new Bombita(new Coordenada(50, 49), _mapa);
            _personajeCuatro = new Bombita(new Coordenada(50, 51), _mapa);
            _personajeCinco = new Bombita(new Coordenada(50, 52), _mapa);
            _personajeSeis = new Bombita(new Coordenada(50, 53), _mapa);
            _personajeSiete = new Cecilio(new Coordenada(51, 50), _mapa);
            _personajeOcho = new Cecilio(new Coordenada(52, 50), _mapa);
            _personajeNueve = new Cecilio(new Coordenada(53, 50), _mapa);
            _bloqueLadrillosDos = new BloqueLadrillos(new Coordenada(47, 50), _mapa);
            _bloqueLadrillosTres = new BloqueLadrillos(new Coordenada(48, 50), _mapa);
            _bloqueLadrillos = new BloqueLadrillos(new Coordenada(49, 50), _mapa);
            _bloqueAcero = new BloqueAcero(new Coordenada(50, 46), _mapa);
            _bloqueAcero = new BloqueAcero(new Coordenada(50, 45), _mapa);
            _bloqueAceroDos = new BloqueAcero(new Coordenada(50, 44), _mapa);
            _bloqueAceroTres = new BloqueAcero(new Coordenada(54, 50), _mapa);
            _bloqueAceroCuatro = new BloqueAcero(new Coordenada(55, 50), _mapa);
            _bloqueAceroCinco = new BloqueAcero(new Coordenada(56, 50), _mapa);
            _bloqueAceroSeis = new BloqueAcero(new Coordenada(50, 54), _mapa);
            _bloqueAceroSiete = new BloqueAcero(new Coordenada(50, 55), _mapa);
            _bloqueAceroOcho = new BloqueAcero(new Coordenada(50, 56), _mapa);
            _bloqueAceroNueve = new BloqueAcero(new Coordenada(44, 50), _mapa);
            _bloqueAceroDiez = new BloqueAcero(new Coordenada(45, 50), _mapa);
            _bloqueAceroOnce = new BloqueAcero(new Coordenada(46, 50), _mapa);


            _mapa.AgregarObjeto(_personajeUno);
            _mapa.AgregarObjeto(_personajeDos);
            _mapa.AgregarObjeto(_personajeTres);
            _mapa.AgregarObjeto(_personajeCuatro);
            _mapa.AgregarObjeto(_personajeCinco);
            _mapa.AgregarObjeto(_personajeSeis);
            _mapa.AgregarObjeto(_personajeSiete);
            _mapa.AgregarObjeto(_personajeOcho);
            _mapa.AgregarObjeto(_personajeNueve);
            _mapa.AgregarObjeto(_bloqueLadrillosDos);
            _mapa.AgregarObjeto(_bloqueLadrillosTres);
            _mapa.AgregarObjeto(_bloqueLadrillos);
            _mapa.AgregarObjeto(_bloqueAcero);
            _mapa.AgregarObjeto(_bloqueAceroDos);
            _mapa.AgregarObjeto(_bloqueAceroTres);
            _mapa.AgregarObjeto(_bloqueAceroCuatro);
            _mapa.AgregarObjeto(_bloqueAceroCinco);
            _mapa.AgregarObjeto(_bloqueAceroSeis);
            _mapa.AgregarObjeto(_bloqueAceroSiete);
            _mapa.AgregarObjeto(_bloqueAceroOcho);
            _mapa.AgregarObjeto(_bloqueAceroNueve);
            _mapa.AgregarObjeto(_bloqueAceroDiez);
            _mapa.AgregarObjeto(_bloqueAceroOnce);
        }

        [Test]
        public void TestDetonacionCorrectaConEfectoExpansivo()
        {
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_personajeUno));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_personajeDos));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_personajeTres));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_personajeCuatro));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_personajeCinco));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_personajeSeis));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_personajeSiete));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_personajeOcho));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_personajeNueve));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_bloqueLadrillosDos));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_bloqueLadrillosTres));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_bloqueLadrillos));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_bloqueAcero));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_bloqueAceroDos));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_bloqueAceroTres));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_bloqueAceroCuatro));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_bloqueAceroCinco));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_bloqueAceroSeis));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_bloqueAceroSiete));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_bloqueAceroOcho));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_bloqueAceroNueve));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_bloqueAceroDiez));
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_bloqueAceroOnce));
            

            _toleTole.Detonar();

            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeUno));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeDos));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeTres));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeCuatro));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeCinco));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeSeis));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeSiete));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeOcho));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeNueve));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueLadrillosDos));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueLadrillosTres));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueLadrillos));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAcero));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroDos));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroTres));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroCuatro));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroCinco));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroSeis));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroSiete));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroOcho));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroNueve));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroDiez));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroOnce));
        }

        [Test]
        public void TestAlDetonarLaMismaEsDestruidaDelMapa()
        {
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_toleTole));

            _toleTole.Detonar();

            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_toleTole));
        }

        [Test]
        public void TestPuedeDestruirBloqueAcero()
        {
            _mapa = new Mapa(100, 100);
            _toleTole = (new CreadorToleTole()).FabricarBomba(_mapa, new Coordenada(50, 50));
            _bloqueAcero = new BloqueAcero(new Coordenada(51, 50), _mapa);
            _mapa.AgregarObjeto(_bloqueAcero);

            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_bloqueAcero));

            _toleTole.Detonar();

            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAcero));
        }

        [Test]
        public void TestSiEsAlcansadoPorUnaExplosionDetona()
        {
            _mapa = new Mapa(100, 100);
            _toleTole = (new CreadorToleTole()).FabricarBomba(_mapa, new Coordenada(50, 50));
            BombaAbstracta molotovDos = (new CreadorToleTole()).FabricarBomba(_mapa, new Coordenada(56, 50));
            _personajeCuatro = new Bombita(new Coordenada(50, 51), _mapa);
            _personajeCinco = new Bombita(new Coordenada(50, 52), _mapa);
            _personajeSeis = new Bombita(new Coordenada(50, 53), _mapa);
            _mapa.AgregarObjeto(_personajeCuatro);
            _mapa.AgregarObjeto(_personajeCinco);
            _mapa.AgregarObjeto(_personajeSeis);

            molotovDos.Detonar();

            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeCuatro));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeCinco));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeSeis));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_toleTole));

        }

        [Test]
        public void TestLuegoDeActivarseTranscurridoTiempoDetona()
        {
            RealizarCicloVivirBomba(_toleTole, 300);

            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeUno));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeDos));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeTres));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeCuatro));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeCinco));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeSeis));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeSiete));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeOcho));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_personajeNueve));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueLadrillosDos));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueLadrillosTres));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueLadrillos));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAcero));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroDos));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroTres));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroCuatro));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroCinco));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroSeis));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroSiete));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroOcho));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroNueve));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroDiez));
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_bloqueAceroOnce));

        }

        #region [Metodos adicionales para Testeo]

        private void RealizarCicloVivirBomba(BombaAbstracta toleTole, int retardoExplosion)
        {
            for (int i = 0; i < (retardoExplosion + 1); i++)
            {
                toleTole.Vivir();
            }
        }

        #endregion



    }
}
