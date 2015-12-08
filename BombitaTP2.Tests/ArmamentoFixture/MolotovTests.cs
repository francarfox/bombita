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
    public class MolotovTests
    {
        private BombaAbstracta _molotov;
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


        [SetUp]
        public void SetUp()
        {
            _mapa = new Mapa(100, 100);
            _molotov = (new CreadorMolotov()).FabricarBomba(_mapa, new Coordenada(50, 50));


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
            
            _molotov.Detonar();

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

        }

        [Test]
        public void TestAlDetonarLaMismaEsDestruidaDelMapa()
        {
            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_molotov));

            _molotov.Detonar();

            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_molotov));
        }

        [Test]
        public void TestNoPuedeDestruirBloqueAcero()
        {
            _mapa = new Mapa(100, 100);
            _bloqueAcero = new BloqueAcero(new Coordenada(51, 50), _mapa);
            _mapa.AgregarObjeto(_bloqueAcero);

            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_bloqueAcero));

            _molotov.Detonar();

            Assert.AreEqual(true, _mapa.ContieneAlObjeto(_bloqueAcero));
        }

        [Test]
        public void TestSiEsAlcansadoPorUnaExplosionDetona()
        {
            _mapa = new Mapa(100, 100);
            _molotov = (new CreadorMolotov()).FabricarBomba(_mapa, new Coordenada(50, 50));
            BombaAbstracta molotovDos = (new CreadorMolotov()).FabricarBomba(_mapa, new Coordenada(53, 50));
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
            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_molotov));

        }

        [Test]
        public void TestLuegoDeActivarseTranscurridoTiempoDetona()
        {
            RealizarCicloVivirBomba(_molotov, 80);

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

        }

        #region [Metodos adicionales para Testeo]

        private void RealizarCicloVivirBomba(BombaAbstracta molotov, int retardoExplosion)
        {
            for (int i = 0; i < (retardoExplosion + 1); i++)
            {
                molotov.Vivir();
            }
        }

        #endregion


    }
}
