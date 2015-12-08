using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombitaTP2.Armamento;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BombitaTP2.Vista
{
    public class ArmamentoVista : IObjetoDibujable
    {
        private ArmamentoAbstracto _armamento;
        private Texture2D _imagenArmamento;

        public ArmamentoVista(ArmamentoAbstracto armamento, Texture2D imagenArmamento)
        {
            _armamento = armamento;
            _imagenArmamento = imagenArmamento;
        }

        public void Dibujar(SpriteBatch spriteBatch)
        {
            Rectangle posicion = new Rectangle(32*_armamento.Coordenada.CoordenadaX, 32*_armamento.Coordenada.CoordenadaY, 32, 32);
            spriteBatch.Draw(_imagenArmamento, posicion, Color.White);
        }

        public IObjetoDeMapa Modelo
        {
            get { return _armamento; }
        }
    }
}
