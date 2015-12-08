using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using BombitaTP2.Personajes;

namespace BombitaTP2.Vista
{
    public class Sprite
    {
        private Texture2D _imagen;
        private int _cantidadCuadros, _cantidadDirecciones, _cuadro, _direccion;
        private int _width, _height;
        private bool _activado;

        public Sprite(Texture2D imagen, Vector2 matriz)
            : this(imagen, matriz, 0)
        { }

        public Sprite(Texture2D imagen, Vector2 matriz, int direccion)
        {
            _imagen = imagen;
            _cantidadCuadros = (int)matriz.X;
            _cantidadDirecciones = (int)matriz.Y;
            _cuadro = 0;
            _direccion = direccion;
            _width = _imagen.Width / _cantidadCuadros;
            _height = _imagen.Height / _cantidadDirecciones;
            _activado = false;
        }

        public void PasarCuadro()
        {
            _cuadro++;
            if (_cuadro >= _cantidadCuadros)
            {
                _cuadro = 0;
                _activado = false;
            }
        }

        public void Activar()
        {
            _activado = true;
        }

        public void Activar(int direccion)
        {
            _direccion = direccion;
            _activado = true;
        }

        public bool EstaActivado()
        {
            return _activado;
        }

        public void Dibujar(SpriteBatch spriteBatch, Coordenada coordenada)
        {
            Rectangle posicion = new Rectangle(32 * coordenada.CoordenadaX, 32 * coordenada.CoordenadaY, 32, 32);
            Rectangle frame = new Rectangle(_cuadro * _width, _direccion * _height, _width, _height);
            
            spriteBatch.Draw(_imagen, posicion, frame, Color.White);
        }
    }
}
