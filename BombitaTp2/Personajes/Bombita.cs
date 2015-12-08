 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombitaTP2.Armamento;
using BombitaTP2.Escenario;
using BombitaTP2.ObjetosAlmacenables;
using BombitaTP2.Desarrollo_de_Juego;

namespace BombitaTP2.Personajes
{
    public class Bombita : PersonajeAbstracto, IAplicableArticulo
    {
        private int _vidas;
        private CreadorBombas _creadorBombas;
        private List<IObservadorDeBombita> _obervadoresBombita;

        public Bombita(Coordenada nuevaCoordenada, Mapa mapa)
            : base(nuevaCoordenada , mapa ,20)
        {
            _vidas = 1;
            _creadorBombas = new CreadorMolotov();
            _obervadoresBombita = new List<IObservadorDeBombita>();
        }

        protected override void ActivarArmamento()
        {
            if (_contadorTiempoAtacar.EstaFinalizadoElConteo())
            {                
                _contadorTiempoAtacar.ResetearConteo();
                Coordenada coordenada = new Coordenada(_coordenada.CoordenadaX, _coordenada.CoordenadaY);
                foreach (IObservadorDeBombita observador in _obervadoresBombita)
                {
                    IArmamento bombaAPlantar = _creadorBombas.FabricarBomba(_mapa, coordenada);
                    bombaAPlantar.AgregarObservadorDeArmamento(this);
                    observador.NotificarCreacionArmamento(bombaAPlantar);                    
                }                
                _debeAtacar = false;
            }
            else
            {
                _contadorTiempoAtacar.IncrementarConteo();
            }

        }
        
        public void AplicarEfecto(HabanoChala habano)
        {
            this.AcelerarVelocidadDeMovimiento(habano.RetardoDeTiempoParaCorrer);
        }

        public void AplicarEfecto(BombaToleTole articuloBombaToleTole)
        {
            this.ModificarCreadorBombas(articuloBombaToleTole.CreadorBomba);
        }

        public void AplicarEfecto(Timer timer)
        {
            _creadorBombas.ReducirRetardoExplosionBomba(timer.PorcentajeReduccionRetardo);          
        }
        
        private void ModificarCreadorBombas(CreadorBombas nuevoCreadorBombas)
        {
            _creadorBombas = nuevoCreadorBombas;
        }



        private void RestarVida()
        {
            _vidas--;

            if (this.EstaMuerto())
                this.Destruir();         
        }

        public override bool EstaMuerto()
        {
            if (_vidas <= 0)
                return true;
            else
                return false;
        }

        public void ColisionarCon(SalidaCiudad salidaDeCiudad)
        {
            foreach (IObservadorDeBombita observador in _obervadoresBombita)
            {
                observador.NotificarBombitaEstaEnLaSalida();
            }
        }

        public override void ColisionarCon(Bombita bombita)
        {
            bombita.RetrotraerMovimiento();            
        }

        public override void ColisionarCon(EnemigoAbstracto enemigo)
        {
            this.RestarVida();            
        }

        public override void ColisionarCon(LopezReggaeAlado alado)
        {
            this.RestarVida();             
        }

        
        public override void ImpactarCon(Molotov molotov)
        {
            this.RestarVida();
        }

        public override void ImpactarCon(Proyectil proyectil)
        {
            this.RestarVida();
        }

        public override void ImpactarCon(ToleTole toleTole)
        {
            this.RestarVida();
        }

        protected override void RealizarColisiones(List<IObjetoDeMapa> listObjetos)
        {
            foreach (IObjetoDeMapa objectoColisionado in listObjetos)
            {
                objectoColisionado.ColisionarCon(this);
            }
        }

        private void AcelerarVelocidadDeMovimiento(int nuevoRetardoDeMovimiento)
        {
            _contadorTiempoMovimiento.DisminuirTiempoACronometrar(nuevoRetardoDeMovimiento);
        }

        public void AgregarObservadorDeBombita(IObservadorDeBombita nuevoObservador)
        {
            _obervadoresBombita.Add(nuevoObservador);
        }

        public void RemoverObservadorDeBombita(IObservadorDeBombita nuevoObservador)
        {
            _obervadoresBombita.Remove(nuevoObservador);
        }
        
        public override void Guardar(String archivo)
        {
            this._nodoProcesado = true;

            this.GuardarNodo(archivo);

            this.GuardarAdyacentes(archivo);
        }

        protected override void GuardarNodo(string archivo)
        {
            List<AtributoNodo> listaDatosNodo = new List<AtributoNodo>();
            listaDatosNodo.Add(new AtributoNodo("Vidasr", this._vidas));
            listaDatosNodo.Add(new AtributoNodo("CeadorBombas", this._creadorBombas.GetType().Name));
            List<IObjetoPersistible> listaDatosForeing = new List<IObjetoPersistible>();

            FormateadorXml.CreateNodoObjeto(archivo, this, listaDatosNodo, listaDatosForeing);

            base.GuardarNodo(archivo);        
        }


        protected override void GuardarAdyacentes(string archivo)
        {
            base.GuardarAdyacentes(archivo);
        }



        public int Vidas { get { return _vidas; } }
    }
}
