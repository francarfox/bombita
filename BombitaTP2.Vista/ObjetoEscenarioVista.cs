using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BombitaTP2.Vista
{
    public class ObjetoEscenarioVista : IObjetoDibujable
    {
        private IObjetoDeMapa _modelo;
        private Texture2D _imagen;

        public ObjetoEscenarioVista(IObjetoDeMapa modelo, Texture2D imagen)
        {
            _modelo = modelo;
            _imagen = imagen;
        }

        public void Dibujar(SpriteBatch spriteBatch)
        {
            Rectangle posicion = new Rectangle(32 * _modelo.Coordenada.CoordenadaX, 32 * _modelo.Coordenada.CoordenadaY, 32, 32);
            spriteBatch.Draw(_imagen, posicion, Color.White);
        }

        public IObjetoDeMapa Modelo
        {
            get { return _modelo; }
        }
    }
}
