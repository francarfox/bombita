using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BombitaTP2.Personajes;
using BombitaTP2.Escenario;
using BombitaTP2.Armamento;

namespace BombitaTP2.Tests.PersonajesFixture
{
    //Se testean los métodos comunes a todos los Enemigos,los implementados en la clase EnemigoAbstracto
    [TestFixture]
    public class EnemigoTests
    {
        private Cecilio _cecilio;
        private LopezReggae _lopezReggae;
        private Mapa _mapa;

        [Test]
        public void TestSiQuiereAvansarYHayUnEnemigoNoAvanza()
        {
            _mapa = new Mapa(50, 50);
            _cecilio = new Cecilio(new Coordenada(20, 20), _mapa);
            _lopezReggae = new LopezReggae(new Coordenada(21, 20), _mapa);
            _mapa.AgregarObjeto(_cecilio);
            _mapa.AgregarObjeto(_lopezReggae);

            _cecilio.ActivarMovimiento(Direccion.Derecha);
            RealizarCicloVivirPersonaje(_cecilio, 20);

            Coordenada coordenadaActual = _cecilio.Coordenada;
            Assert.AreEqual(20, coordenadaActual.CoordenadaX);
            Assert.AreEqual(20, coordenadaActual.CoordenadaY);

        }

        [Test]
        public void TestAlImpactarConToleToleSeDestruye()
        {
            _mapa = new Mapa(100, 100);
            _cecilio = new Cecilio(new Coordenada(20,20), _mapa);
            CreadorToleTole creadorToleTole = new CreadorToleTole();
            ToleTole toleTole = (ToleTole)creadorToleTole.FabricarBomba(_mapa, new Coordenada(54, 50));
            _mapa.AgregarObjeto(_cecilio);

            _cecilio.ImpactarCon(toleTole);

            Assert.AreEqual(false, _mapa.ContieneAlObjeto(_cecilio));
        }




        #region [Metodos adicionales para Testeo]

        private void RealizarCicloVivirPersonaje(PersonajeAbstracto personaje, int retardoMovimiento)
        {
            for (int i = 0; i < (retardoMovimiento + 1); i++)
            {
                personaje.Vivir();
            }
        }

        #endregion


    }
}
