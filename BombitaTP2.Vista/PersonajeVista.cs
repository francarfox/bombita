using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombitaTP2.Personajes;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BombitaTP2.Vista
{
    public class PersonajeVista : IObjetoDibujable
    {
        private PersonajeAbstracto _personaje;
        private Sprite _sprite;

        public PersonajeVista(PersonajeAbstracto personaje, Texture2D imagen)
        {
            _personaje = personaje;
            _sprite = new Sprite(imagen, new Vector2(1, 4), 1);
        }

        public void Activar(Direccion direccion)
        {
            _sprite.Activar((int)direccion-1);
        }

        public void Dibujar(SpriteBatch spriteBatch)
        {
            _sprite.Dibujar(spriteBatch, _personaje.Coordenada);
        }

        public IObjetoDeMapa Modelo
        {
            get { return _personaje; }
        }
    }
}
