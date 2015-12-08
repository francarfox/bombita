using System;
using Microsoft.Xna.Framework.Input;
using BombitaTP2.Personajes;
using BombitaTP2.Vista;
using Microsoft.Xna.Framework;

namespace BombitaTP2.Game
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (GameLoop gameLoop = new GameLoop())
            {
                gameLoop.IsMouseVisible = true;

                gameLoop.BeforeUpdate += (sender, arg) =>
                {
                    if (arg.KeyboardState.IsKeyDown(Keys.Up))
                        gameLoop.PersonajePrincipalMover(Direccion.Arriba);
                    else if (arg.KeyboardState.IsKeyDown(Keys.Down))
                        gameLoop.PersonajePrincipalMover(Direccion.Abajo);
                    else if (arg.KeyboardState.IsKeyDown(Keys.Right))
                        gameLoop.PersonajePrincipalMover(Direccion.Derecha);
                    else if (arg.KeyboardState.IsKeyDown(Keys.Left))
                        gameLoop.PersonajePrincipalMover(Direccion.Izquierda);
                    else if (arg.KeyboardState.IsKeyDown(Keys.Enter))
                        gameLoop.PersonajePrincipalAtacar();

                    if (arg.MouseState.LeftButton == ButtonState.Pressed)
                    {
                        gameLoop.SeleccionarBoton();
                    }
                };

                gameLoop.Run();
            }
        }
    }
#endif
}

