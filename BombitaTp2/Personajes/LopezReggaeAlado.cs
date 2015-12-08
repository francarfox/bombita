using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombitaTP2.Escenario;
using BombitaTP2.Armamento;
using BombitaTP2.Obstaculos;


namespace BombitaTP2.Personajes
{
    public class LopezReggaeAlado : Cecilio
    {
        public LopezReggaeAlado(Coordenada nuevaCoordenada, Mapa mapa)
            : base(nuevaCoordenada, mapa)
        {


        }

        protected override void RealizarColisiones(List<IObjetoDeMapa> listObjetos)
        {
            foreach (IObjetoDeMapa objectoColisionado in listObjetos)
            {
                objectoColisionado.ColisionarCon(this);
            }
        }

        public override void ColisionarCon(ObstaculoAbstracto obstaculo)
        {
            
        }

    }
}
