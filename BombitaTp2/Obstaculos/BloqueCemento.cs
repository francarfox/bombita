using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombitaTP2.Escenario;
using BombitaTP2.ObjetosAlmacenables;

namespace BombitaTP2.Obstaculos
{
    public class BloqueCemento : ObstaculoContObjAlmacenables
    {
        public BloqueCemento(Coordenada nuevaCoordenada, Mapa mapa)
            : base(nuevaCoordenada, mapa)
        {
            _durabilidad = 10;
        }
    }
}
