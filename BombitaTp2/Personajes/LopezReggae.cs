using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombitaTP2.Escenario;
using BombitaTP2.Armamento;
using BombitaTP2.Desarrollo_de_Juego;

namespace BombitaTP2.Personajes
{
    public class LopezReggae : EnemigoAbstracto
    {
        private CreadorProyectil _creadorProyectil;

        public LopezReggae(Coordenada nuevaCoordenada, Mapa mapa)
            : base(nuevaCoordenada, mapa, 10, 10,50)
        {
            _creadorProyectil = new CreadorProyectil();
        }

        protected override void ActivarArmamento()
        {
            foreach (IObservadorEnemigo observador in _observadoresDeEnemigos)
            {
                IArmamento armamentoActivado = _creadorProyectil.FabricarProyectil(_mapa, _coordenada, _direccionMovimiento);
                armamentoActivado.AgregarObservadorDeArmamento(this);
                observador.NotificarCreacionArmamento(armamentoActivado);                            
            }
            
        }

    }
}
