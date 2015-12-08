using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombitaTP2.Armamento;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BombitaTP2.Vista
{
    public class ProyectilVista : IObjetoDibujable
    {
        private Proyectil _proyectil;
        private Sprite _sprite;

        public ProyectilVista(Proyectil proyectil, Texture2D imagen)
        {
            _proyectil = proyectil;
            _sprite = new Sprite(imagen, new Vector2(1, 4));
        }

        public void Activar(Direccion direccion)
        {
            _sprite.Activar((int)direccion-1);
        }

        public void Dibujar(SpriteBatch spriteBatch)
        {
            _sprite.Dibujar(spriteBatch, _proyectil.Coordenada);
        }

        public IObjetoDeMapa Modelo
        {
            get { return _proyectil; }
        }
    }
}
