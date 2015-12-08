using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BombitaTP2.Personajes;
using BombitaTP2.Armamento;
using BombitaTP2.Obstaculos;
using BombitaTP2.Escenario;

namespace BombitaTP2.Tests.PersonajesFixture
{
    [TestFixture]
    public class LopezReggaeAladoTests
    {
        private LopezReggaeAlado _alado;
        private Mapa _mapa;

        [Test]
        public void TestAtraviesaMuros()
        {
            Coordenada coordenadaActual;
            _mapa = new Mapa(100, 100);
            _alado = new LopezReggaeAlado(new Coordenada(50, 50), _mapa);
            _mapa.AgregarObjeto(_alado);
            BloqueLadrillos bloqueLadrillo = new BloqueLadrillos(new Coordenada(51, 50), _mapa);
            _mapa.AgregarObjeto(bloqueLadrillo);

            _alado.ActivarMovimiento(Direccion.Derecha);
            RealizarCicloVivirPersonaje(_alado, 20);
            RealizarCicloVivirPersonaje(_alado, 20);
            coordenadaActual = _alado.Coordenada;

            Assert.AreEqual(51, coordenadaActual.CoordenadaX);
            Assert.AreEqual(50, coordenadaActual.CoordenadaY);
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
