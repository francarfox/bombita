using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using BombitaTP2.Personajes;
using BombitaTP2.Obstaculos;
using BombitaTP2.ObjetosAlmacenables;
using BombitaTP2.Armamento;

namespace BombitaTP2.Vista
{
    public class CreadorVista
    {
        private Dictionary<Type, Texture2D> _vistas;

        public CreadorVista()
        {
            _vistas = new Dictionary<Type, Texture2D>();
        }

        public void CargarContenido(List<Texture2D> _imagenes)
        {
            _vistas.Add(typeof(BloqueAcero), _imagenes.ElementAt(0));
            _vistas.Add(typeof(BloqueCemento), _imagenes.ElementAt(1));
            _vistas.Add(typeof(BloqueLadrillos), _imagenes.ElementAt(2));
            _vistas.Add(typeof(HabanoChala), _imagenes.ElementAt(3));
            _vistas.Add(typeof(BombaToleTole), _imagenes.ElementAt(4));
            _vistas.Add(typeof(Timer), _imagenes.ElementAt(5));
            _vistas.Add(typeof(SalidaCiudad), _imagenes.ElementAt(6));
            _vistas.Add(typeof(Molotov), _imagenes.ElementAt(7));
            _vistas.Add(typeof(ToleTole), _imagenes.ElementAt(8));
            _vistas.Add(typeof(Proyectil), _imagenes.ElementAt(9));
            _vistas.Add(typeof(Cecilio), _imagenes.ElementAt(10));
            _vistas.Add(typeof(LopezReggae), _imagenes.ElementAt(11));
            _vistas.Add(typeof(LopezReggaeAlado), _imagenes.ElementAt(12));
            _vistas.Add(typeof(Bombita), _imagenes.ElementAt(13));
        }

        public IObjetoDibujable GenerarVista(IObjetoDeMapa modelo)
        {
            IObjetoDibujable vista = null;
            Texture2D imagen = _vistas[modelo.GetType()];

            if (modelo is IObjetoVivo)
            {
                if (modelo is PersonajeAbstracto)
                {
                    vista = new PersonajeVista((PersonajeAbstracto)modelo, imagen);
                }
                else if (modelo is Proyectil)
                {
                    vista = new ProyectilVista((Proyectil)modelo, imagen);
                }
                else
                {
                    vista = new BombaVista((BombaAbstracta)modelo, imagen);
                }
            }
            else
            {
                vista = new ObjetoEscenarioVista(modelo, imagen);
            }

            return vista;
        }
    }
}
