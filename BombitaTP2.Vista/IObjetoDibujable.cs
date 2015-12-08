using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BombitaTP2.Vista
{
    public interface IObjetoDibujable
    {
        void Dibujar(SpriteBatch spriteBatch);
        IObjetoDeMapa Modelo { get; }
    }
}
