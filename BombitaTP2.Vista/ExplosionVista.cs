using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using BombitaTP2.Armamento;
using Microsoft.Xna.Framework;

namespace BombitaTP2.Vista
{
    public class ExplosionVista : IObjetoDibujable
    {
        private ArmamentoAbstracto _armamento;
        private List<Coordenada> _coordenadas;
        private Sprite _sprite;

        public ExplosionVista(Texture2D imagenExplosion)
        {
            _sprite = new Sprite(imagenExplosion, new Vector2(13, 1));
        }

        public void Activar(ArmamentoAbstracto armamento)
        {
            _armamento = armamento;
            _coordenadas = new List<Coordenada>();
            _sprite.Activar();

            this.Inicializar();
        }

        private void Inicializar()
        {
            int posX = _armamento.Coordenada.CoordenadaX;
            int posY = _armamento.Coordenada.CoordenadaY;

            for (int i = (posX - _armamento.RadioExplosion); i <= (posX + _armamento.RadioExplosion); i++)
                _coordenadas.Add(new Coordenada(i, posY));
            for (int j = (posY - _armamento.RadioExplosion); j <= (posY + _armamento.RadioExplosion); j++)
                _coordenadas.Add(new Coordenada(posX, j));
        }

        public void Dibujar(SpriteBatch spriteBatch)
        {
            if (_sprite.EstaActivado())
            {
                foreach (Coordenada coordenada in _coordenadas)
                {
                    _sprite.Dibujar(spriteBatch, coordenada);
                }
                _sprite.PasarCuadro();
            }
        }

        public IObjetoDeMapa Modelo
        {
            get { return _armamento; }
        }
    }
}
