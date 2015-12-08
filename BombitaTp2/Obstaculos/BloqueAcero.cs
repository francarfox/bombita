using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombitaTP2.ObjetosAlmacenables;
using BombitaTP2.Escenario;
using BombitaTP2.Armamento;

namespace BombitaTP2.Obstaculos
{
    public class BloqueAcero : ObstaculoAbstracto
    {

        public BloqueAcero(Coordenada nuevaCoordenada, Mapa mapa)
            : base(nuevaCoordenada, mapa)
        {
            _durabilidad = null;
        }
        
        public override void ImpactarCon(Molotov molotov) { }

        public override void ImpactarCon(Proyectil proyectil) { }

        public override bool AgregarObjetoAlmacenable(IArticulo articulo)
        {
            return AgregarCorrecto(articulo);
        }
        
    }
}
