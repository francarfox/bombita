using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace BombitaTP2.Game
{
    public class Button
    {
        private String _nombre;
        private Texture2D _imagen;
        private Rectangle _superficie;
        private int _width, _heigth;
        private bool _seleccionado;

        public Button(String nombre, Vector2 posicion)
        {
            _nombre = nombre;
            _width = 150;
            _heigth = 40;
            _superficie = new Rectangle((int)posicion.X, (int)posicion.Y, _width, _heigth);
            _seleccionado = false;
        }

        public void Inicializar(Texture2D imagen)
        {
            _imagen = imagen;
        }

        public void Actualizar()
        {
            Rectangle supMouse = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);
            if (supMouse.Intersects(_superficie))
                _seleccionado = true;
            else
                _seleccionado = false;
        }

        public bool EstaSeleccionado()
        {
            return _seleccionado;
        }

        internal void Deseleccionar()
        {
            _seleccionado = false;
        }

        public void Dibujar(SpriteBatch spriteBatch, SpriteFont font)
        {
            Color color = Color.White;
            if (_seleccionado)
                color = Color.Red;

            spriteBatch.Draw(_imagen, _superficie, color);
            spriteBatch.DrawString(font, _nombre, new Vector2(_superficie.X + 20, _superficie.Y + 10), Color.Yellow);
        }
    }
}
