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
using BombitaTP2.Vista;
using BombitaTP2;
using BombitaTP2.Personajes;

namespace BombitaTP2.Game
{
    public delegate void Opcion();
    public delegate void BeforeUpdateEventHandler(object sender, BeforeUpdateEventArgs args);

    public class BeforeUpdateEventArgs : System.EventArgs
    {
        public KeyboardState KeyboardState { get { return Keyboard.GetState(); } }
        public MouseState MouseState { get { return Mouse.GetState(); } }
    }


    public class GameLoop : Microsoft.Xna.Framework.Game
    {
        public event BeforeUpdateEventHandler BeforeUpdate;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private SpriteFont _font;
        private Song _song;
        private SoundEffect _efect;
        private Texture2D _button, _presentation;
        private String _rutaSounds, _rutaImages;
        private ControladorJuego _controladorJuego;
        private Dictionary<Button, Opcion> _opciones;
        private Cronometro _retardoRanking;
        private bool _mostrarRanking;

        public GameLoop()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _controladorJuego = new ControladorJuego(this);

            _opciones = new Dictionary<Button, Opcion>();
            _retardoRanking = new Cronometro(120);
            _mostrarRanking = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.Title = "Bombita TP2 - FIUBA - Algoritmos III";
            _rutaSounds = "sounds/";
            _rutaImages = "images/";

            _opciones.Add(new Button("J U G A R", new Vector2(70, 150)), OpcionIniciarJuego);
            _opciones.Add(new Button("R A N K I N G", new Vector2(70, 220)), OpcionVerRanking);
            _opciones.Add(new Button("S A L I R", new Vector2(70, 290)), OpcionSalir);

            _controladorJuego.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _font = Content.Load<SpriteFont>("fonts/font");
            _song = Content.Load<Song>(_rutaSounds + "song");
            _efect = Content.Load<SoundEffect>(_rutaSounds + "efect");
            MediaPlayer.Play(_song);
            MediaPlayer.IsRepeating = true;
            
            _button = Content.Load<Texture2D>(_rutaImages + "button");
            _presentation = Content.Load<Texture2D>(_rutaImages + "presentation");
            List<Button> botones = _opciones.Keys.ToList<Button>();
            foreach (Button boton in botones)
                boton.Inicializar(_button);

            this.CargarContenidoJuego();
        }

        private void CargarContenidoJuego()
        {
            List<SoundEffect> sonidos = new List<SoundEffect>();
            sonidos.Add(Content.Load<SoundEffect>(_rutaSounds + "bomb"));
            sonidos.Add(_efect);

            List<Texture2D> imagenes = new List<Texture2D>();
            imagenes.Add(Content.Load<Texture2D>(_rutaImages + "acero"));
            imagenes.Add(Content.Load<Texture2D>(_rutaImages + "cemento"));
            imagenes.Add(Content.Load<Texture2D>(_rutaImages + "ladrillos"));
            imagenes.Add(Content.Load<Texture2D>(_rutaImages + "chala"));
            imagenes.Add(Content.Load<Texture2D>(_rutaImages + "articuloToleTole"));
            imagenes.Add(Content.Load<Texture2D>(_rutaImages + "timer"));
            imagenes.Add(Content.Load<Texture2D>(_rutaImages + "salida"));
            imagenes.Add(Content.Load<Texture2D>(_rutaImages + "molotov"));
            imagenes.Add(Content.Load<Texture2D>(_rutaImages + "toleTole"));
            imagenes.Add(Content.Load<Texture2D>("sprites/proyectil"));
            imagenes.Add(Content.Load<Texture2D>("sprites/cecilio"));
            imagenes.Add(Content.Load<Texture2D>("sprites/lopez"));
            imagenes.Add(Content.Load<Texture2D>("sprites/lopezAlado"));
            imagenes.Add(Content.Load<Texture2D>("sprites/bombita"));
            imagenes.Add(Content.Load<Texture2D>("sprites/explosion"));

            _controladorJuego.CargarContenido(imagenes, sonidos);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            _controladorJuego.DescargarContenido();
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            if (BeforeUpdate != null)
                BeforeUpdate(this, new BeforeUpdateEventArgs());

            if (this.JuegoEstaEjecutando())
                _controladorJuego.Update(gameTime);
            else
                this.ActualizarBotones();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            try
            {
                if (this.JuegoEstaEjecutando())
                    _controladorJuego.Dibujar(spriteBatch, _font);
                else
                {
                    spriteBatch.Draw(_presentation, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                    this.DibujarBotones();

                    if (_mostrarRanking)
                        this.DibujarRanking();
                }
            }
            finally
            {
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        private void ActualizarBotones()
        {
            List<Button> botones = _opciones.Keys.ToList<Button>();
            foreach (Button boton in botones)
                boton.Actualizar();
        }

        private void DibujarBotones()
        {
            List<Button> botones = _opciones.Keys.ToList<Button>();
            foreach (Button boton in botones)
                boton.Dibujar(spriteBatch, _font);
        }

        private void DibujarRanking()
        {
            List<int> puntajes = _controladorJuego.PuntajesAltos;
            int cantidad = puntajes.Count;
            puntajes.Sort();

            for (int i = 1; i <= cantidad; i++)
            {
                spriteBatch.DrawString(_font, i + ".-", new Vector2(470, 15 * i), Color.Yellow);
                spriteBatch.DrawString(_font, " " + puntajes[cantidad - i], new Vector2(500, 15 * i), Color.Yellow);
            }

            this.CalcularRetardoRanking();
        }

        private void CalcularRetardoRanking()
        {
            _retardoRanking.IncrementarConteo();
            if (_retardoRanking.EstaFinalizadoElConteo())
            {
                _retardoRanking.ResetearConteo();
                _mostrarRanking = false;
            }
        }

        private bool JuegoEstaEjecutando()
        {
            return _controladorJuego.EnEjecucion();
        }

        public void PersonajePrincipalMover(Direccion direccion)
        {
            _controladorJuego.PersonajePrincipalMover(direccion);
        }

        public void PersonajePrincipalAtacar()
        {
            _controladorJuego.PersonajePrincipalAtacar();
        }

        public void SeleccionarBoton()
        {
            List<Button> botones = _opciones.Keys.ToList<Button>();
            foreach(Button boton in botones)
                if (boton.EstaSeleccionado())
                {
                    boton.Deseleccionar();
                    _opciones[boton].Invoke();
                    _efect.Play();
                }
        }

        private void OpcionIniciarJuego()
        {
            _controladorJuego.IniciarJuego();
            MediaPlayer.Play(_song);
        }

        private void OpcionVerRanking()
        {
            _mostrarRanking = true;
        }

        private void OpcionSalir() 
        {
            Environment.Exit(0);
        }
    }
}
