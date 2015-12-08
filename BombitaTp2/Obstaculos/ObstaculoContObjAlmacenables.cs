using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombitaTP2.Escenario;
using BombitaTP2.ObjetosAlmacenables;
using BombitaTP2.Armamento;

namespace BombitaTP2.Obstaculos
{
    public abstract class ObstaculoContObjAlmacenables : ObstaculoAbstracto
    {

        public ObstaculoContObjAlmacenables(Coordenada nuevaCoordenada, Mapa mapa)
            : base(nuevaCoordenada , mapa) { }

        public override bool AgregarObjetoAlmacenable(IArticulo articulo)
        {
            return AgregarCorrecto(articulo);
        }

        public override bool AgregarObjetoAlmacenable(SalidaCiudad salidaCiudad)
        {
            return AgregarCorrecto(salidaCiudad);
        }

        
        public override void ImpactarCon(Molotov molotov)
        {
            this.Daniarse(molotov.UnidadesDestruccion);
        }

        public override void ImpactarCon(Proyectil proyectil)
        {
            this.Daniarse(proyectil.UnidadesDestruccion);
        }

        private void Daniarse(int? unidadesDeDestruccion)
        {
            ReducirDurabilidad(unidadesDeDestruccion);
            if (SiAgotoDurabilidad())
                Destruir();
        }

    }
}
