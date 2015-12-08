using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombitaTP2.Armamento;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BombitaTP2.Vista
{
    public class BombaVista : IObjetoDibujable
    {
        private BombaAbstracta _bomba;
        private Texture2D _imagen;

        public BombaVista(BombaAbstracta armamento, Texture2D imagenArmamento)
        {
            _bomba = armamento;
            _imagen = imagenArmamento;
        }

        public void Dibujar(SpriteBatch spriteBatch)
        {
            Rectangle posicion = new Rectangle(32*_bomba.Coordenada.CoordenadaX, 32*_bomba.Coordenada.CoordenadaY, 32, 32);
            spriteBatch.Draw(_imagen, posicion, Color.White);
        }

        public IObjetoDeMapa Modelo
        {
            get { return _bomba; }
        }
    }
}
