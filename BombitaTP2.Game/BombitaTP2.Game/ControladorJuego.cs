using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombitaTP2.Personajes;
using BombitaTP2.Vista;
using BombitaTP2.Obstaculos;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using BombitaTP2.Armamento;
using Microsoft.Xna.Framework.Audio;
using BombitaTP2.ObjetosAlmacenables;
using BombitaTP2.Escenario;
using BombitaTP2.Desarrollo_de_Juego;

namespace BombitaTP2.Game
{
    public class ControladorJuego : GameComponent, IObservadorDeMapa
    {
        private bool _enEjecucion;

        private Juego _juego;
        private Nivel _nivel;
        private Bombita _bombita;
        private CreadorVista _creadorVista;
        private PersonajeVista _bombitaVista;
        private ExplosionVista _explosionVista;

        private List<SoundEffect> _sonidos;
        private List<IObjetoDibujable> _objetosDibujables;
        


        public ControladorJuego(GameLoop gameLoop)
            : base(gameLoop)
        {
            _enEjecucion = false;

            _juego = new Juego();
            _nivel = _juego.NivelActual;
            _bombita = _nivel.PersonajePrincipal;
            _creadorVista = new CreadorVista();
        }

        public override void Initialize()
        {
            _objetosDibujables = new List<IObjetoDibujable>();
            _nivel.AgregarObservadorAMapa(this);
            base.Initialize();
        }

        public void CargarContenido(List<Texture2D> imagenes, List<SoundEffect> sonidos)
        {
            this._sonidos = sonidos;
            _creadorVista.CargarContenido(imagenes);
            _nivel.CargarMapa(); 

            _bombitaVista = (PersonajeVista)_creadorVista.GenerarVista(_bombita);
            _explosionVista = new ExplosionVista(imagenes.ElementAt(imagenes.Count - 1));

            _objetosDibujables.Add(_bombitaVista);
        }

        public void DescargarContenido() { }

        public override void Update(GameTime gameTime)
        {
            if (_juego.EstaEnEjecucion())
            {
                _juego.Correr();
                
                if (_nivel != _juego.NivelActual || !_juego.EstaEnEjecucion())
                    this.ProcesarNivelActual();                
            }
            else
            {
                _enEjecucion = false;
            }

            base.Update(gameTime);
        }

        public void Dibujar(SpriteBatch spriteBatch, SpriteFont font) 
        {
            foreach (IObjetoDibujable objetoDibujable in _objetosDibujables)
            {
                objetoDibujable.Dibujar(spriteBatch);
            }
            _bombitaVista.Dibujar(spriteBatch);
            _explosionVista.Dibujar(spriteBatch);

            this.DibujarEstadistica(spriteBatch, font);
        }

        private void DibujarEstadistica(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.DrawString(font, "Nivel " + _nivel.Id, new Vector2(35, 3), Color.White);
            spriteBatch.DrawString(font, "Vidas " + _bombita.Vidas, new Vector2(140, 3), Color.White);
            spriteBatch.DrawString(font, "Puntaje " + _nivel.Puntaje, new Vector2(265, 3), Color.White);
            spriteBatch.DrawString(font, "Tiempo " + _nivel.TiempoRestante, new Vector2(400, 3), Color.White);
        }

        public void ActualizarObjetoAgregado(IObjetoDeMapa objetoMapa)
        {
            IObjetoDibujable vista = _creadorVista.GenerarVista(objetoMapa);
            _objetosDibujables.Add(vista);


            if (objetoMapa is IObjetoAlmacenable && _enEjecucion)
              _sonidos.ElementAt(1).Play();
        }

        public void ActualizarObjetoRemovido(IObjetoDeMapa objetoMapaParametro)
        {
            IObjetoDibujable aux = null;
            foreach (IObjetoDibujable objetoDibujable in _objetosDibujables)
            {
                IObjetoDeMapa modelo = objetoDibujable.Modelo;
                if (modelo == objetoMapaParametro)
                    aux = objetoDibujable;


                if (modelo is ArmamentoAbstracto)
                  this.AnimacionExplosion((ArmamentoAbstracto)modelo);
                if (modelo is IObjetoAlmacenable)
                  _sonidos.ElementAt(1).Play();
                
            }
            if(aux != null)
                _objetosDibujables.Remove(aux);
        }

        private void AnimacionExplosion(ArmamentoAbstracto armamento)
        {
            _sonidos.ElementAt(0).Play();
            _explosionVista.Activar(armamento);
        }

        public bool EnEjecucion()
        {
            return _enEjecucion;
        }

        public void IniciarJuego()
        {            
            _juego.Ejecutar();
            _enEjecucion = true;
        }

        public void ProcesarNivelActual()
        {
            _nivel = _juego.NivelActual;
            _bombita = _nivel.PersonajePrincipal;
            this.Initialize();
            _nivel.CargarMapa();
            _bombitaVista = (PersonajeVista)_creadorVista.GenerarVista(_bombita);
        }

        public void PersonajePrincipalMover(Direccion direccion)
        {
            _bombita.ActivarMovimiento(direccion);
            _bombitaVista.Activar(direccion);
        }

        public void PersonajePrincipalAtacar()
        {
            _bombita.Atacar();
        }

        public List<int> PuntajesAltos { get { return _juego.PuntajesAltos; } }
    }
}
