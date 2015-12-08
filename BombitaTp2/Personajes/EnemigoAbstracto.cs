using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombitaTP2.Escenario;
using BombitaTP2.Armamento;
using BombitaTP2.ObjetosAlmacenables;
using BombitaTP2.Desarrollo_de_Juego;

namespace BombitaTP2.Personajes
{
    public class EnemigoAbstracto : PersonajeAbstracto
    {
        private int _resistencia;
        protected List<IObservadorEnemigo> _observadoresDeEnemigos;
        protected int _puntajePorDestruccion;
        
        public EnemigoAbstracto(Coordenada nuevaCoordenada, Mapa mapa, int resistencia,int retardoDeMovimiento,int puntajePorDestruccion)
            : base(nuevaCoordenada , mapa,retardoDeMovimiento)
        {
            _resistencia = resistencia;
            _direccionMovimiento = Direccion.Izquierda;
            _observadoresDeEnemigos = new List<IObservadorEnemigo>();
            _puntajePorDestruccion = puntajePorDestruccion;
        }

        public override void Destruir()
        {
            foreach (IObservadorEnemigo observador in _observadoresDeEnemigos)
            {
                observador.NotificarBajaEnemigo(this);
            }
            _mapa.EliminarObjeto(this);
        }
        
        private void ReducirResistencia(int? unidadesDestructivas)
        {
            if (_resistencia > 0 && unidadesDestructivas != null)
            {
                _resistencia -= (int)unidadesDestructivas;
            }
            else
                if (unidadesDestructivas == null)
                    _resistencia = 0;

            if (this.EstaMuerto())
                this.Destruir();
        }   

        public override bool EstaMuerto()
        {
            if ( _resistencia <= 0)
                return true;
            else
                return false;
        }


        public override void ColisionarCon(Bombita bombita)
        {
            bombita.ColisionarCon(this);
        }

        public override void ColisionarCon(EnemigoAbstracto enemigo)
        {
            enemigo.RetrotraerMovimiento();
        }

        public override void ColisionarCon(LopezReggaeAlado alado) 
        {
            alado.RetrotraerMovimiento();
        }

        public override void ImpactarCon(Molotov molotov)
        {
            ReducirResistencia(molotov.UnidadesDestruccion);
        }

        public override void ImpactarCon(Proyectil proyectil)
        {
            ReducirResistencia(proyectil.UnidadesDestruccion);
        }

        public override void ImpactarCon(ToleTole toleTole)
        {
            this.ReducirResistencia(toleTole.UnidadesDestruccion);
        }

        protected override void RealizarColisiones(List<IObjetoDeMapa> listObjetos)
        {
            foreach (IObjetoDeMapa objectoColisionado in listObjetos)
            {
                objectoColisionado.ColisionarCon(this);
            }
        }

        public void AgregarObservadorDeEnemigo(IObservadorEnemigo nuevoObservador)
        {
            _observadoresDeEnemigos.Add(nuevoObservador);
        }

        public void RemoverObservadorDeEnemigo(IObservadorEnemigo observadorARemover)
        {
            _observadoresDeEnemigos.Remove(observadorARemover);
        }

        public int PuntajePorDestruccion
        {
            get { return _puntajePorDestruccion; }
        }

        public Direccion Direccion
        {
            get { return _direccionMovimiento; }
        }

        
    }
}
