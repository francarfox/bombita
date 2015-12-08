using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombitaTP2.Escenario;
using BombitaTP2.Armamento;
using BombitaTP2.Desarrollo_de_Juego;



namespace BombitaTP2.Personajes
{
    public class Cecilio : EnemigoAbstracto
    {
        protected CreadorBombas _creadorBombas;

        public Cecilio(Coordenada nuevaCoordenada, Mapa mapa)
            : base(nuevaCoordenada, mapa, 5, 25,30)
        {
            _creadorBombas = new CreadorMolotov();
        }

        protected override void ActivarArmamento()
        {
            foreach (IObservadorEnemigo observador in _observadoresDeEnemigos)
            {
                IArmamento armamentoActivado = _creadorBombas.FabricarBomba(_mapa, _coordenada);
                armamentoActivado.AgregarObservadorDeArmamento(this);
                observador.NotificarCreacionArmamento(armamentoActivado);                
            }
            _creadorBombas.FabricarBomba(_mapa, _coordenada);
        }
    }
}
