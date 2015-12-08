
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombitaTP2.Armamento;
using BombitaTP2.Escenario;
using BombitaTP2.ObjetosAlmacenables;
using BombitaTP2.Personajes;
using BombitaTP2.Exceptions;

namespace BombitaTP2.Obstaculos
{
    public abstract class ObstaculoAbstracto : IObjetoDeMapa
    {
        static int _cantidadObjetosClase = 0;
        private int _primaryKey;
        private int _foreignKeyMapa;
        private int _foreignKeyCoordenada;
        private int _foreignKeyObjetoAlmacenable;
        protected bool _nodoProcesado;       
        
        protected int? _durabilidad;
        protected IObjetoAlmacenable _objetoAlmacenable;
        protected Mapa _mapa;
        protected Coordenada _coordenada;

        public ObstaculoAbstracto(Coordenada nuevaCoordenada, Mapa mapa)            
        {            
            _objetoAlmacenable = null;            
            _mapa = mapa;
            _coordenada = nuevaCoordenada;

            _cantidadObjetosClase += 1;
            this._primaryKey = _cantidadObjetosClase;
            this._foreignKeyMapa = _mapa.PrimaryKey;
            this._foreignKeyCoordenada = _coordenada.PrimaryKey;
            _nodoProcesado = false;
        }

        public  void Destruir()
        {
            if (_objetoAlmacenable != null)
            {
                _objetoAlmacenable.Coordenada = _coordenada;
                
                _mapa.AgregarObjeto(_objetoAlmacenable);
            }
            _mapa.EliminarObjeto(this);

        }

        public virtual bool AgregarObjetoAlmacenable(IArticulo articulo)
        {
            return false;
        }

        public virtual bool AgregarObjetoAlmacenable(SalidaCiudad salidaCiudad)
        {
            return false;
        }

        protected bool AgregarCorrecto(IObjetoAlmacenable nuevoObjetoAlmacenable)
        {
            _objetoAlmacenable = nuevoObjetoAlmacenable;
            this._foreignKeyObjetoAlmacenable = nuevoObjetoAlmacenable.PrimaryKey;
            return true;
        }

        protected void ReducirDurabilidad(int? unidadesDestruccion)
        {
            if (_durabilidad > 0 && unidadesDestruccion != null)
            {
                _durabilidad -= (int)unidadesDestruccion;
            }

        }

        protected bool SiAgotoDurabilidad()
        {
            if (_durabilidad <= 0)
                return true;
            else
                return false;
        }

        public void ColisionarCon(Bombita bombita)
        {
            bombita.ColisionarCon(this);
        }

        public void ColisionarCon(EnemigoAbstracto enemigo)        
        {
            enemigo.ColisionarCon(this);
        }

        public void ColisionarCon(LopezReggaeAlado enemigoAlado)
        {
            enemigoAlado.ColisionarCon(this);
        }
      
        public abstract void ImpactarCon(Molotov molotov);

        public abstract void ImpactarCon(Proyectil proyectil);

        public void ImpactarCon(ToleTole toleTole)
        {
            Destruir();
        }


        public virtual void Guardar(String archivo)
        {
            this._nodoProcesado = true;

            this.GuardarNodo(archivo);

            this.GuardarAdyacentes(archivo);
        }

        protected virtual void GuardarNodo(String archivo)
        {
            List<AtributoNodo> listaDatosNodo = new List<AtributoNodo>();
            if (this._durabilidad != null) listaDatosNodo.Add(new AtributoNodo("Durabilidad", this._durabilidad));
            List<IObjetoPersistible> listaDatosForeing = new List<IObjetoPersistible>();
            listaDatosForeing.Add(this._mapa);
            listaDatosForeing.Add(this._coordenada);
            if ( _objetoAlmacenable != null ) listaDatosForeing.Add(this._objetoAlmacenable);

            FormateadorXml.CreateNodoObjeto(archivo, this, listaDatosNodo, listaDatosForeing);
        }

        protected virtual void GuardarAdyacentes(string archivo)
        {
            if (!this._mapa.NodoProcesado)
            {
                //throw new PersistenciaMapaException();
            }

            if (!this.Coordenada.NodoProcesado)
                this.Coordenada.Guardar(archivo);

            if (_objetoAlmacenable != null)
            {
                if (!this._objetoAlmacenable.NodoProcesado)
                    this._objetoAlmacenable.Guardar(archivo);
            }
        }


        public Coordenada Coordenada
        {
            get
            {
                return _coordenada;
            }
            set
            {
                _coordenada = value;
            }
        }
        
        public int PrimaryKey
        {
            get
            {
                return this._primaryKey;
            }
        }

        public int ForeignKeyMapa
        {
            get
            {
                return this._foreignKeyMapa;
            }
        }

        public int ForeignKeyCoordenada
        {
            get
            {
                return this._foreignKeyCoordenada;
            }
        }

        public int ForeignKeyObjetoAlmacenable
        {
            get
            {
                return this._foreignKeyObjetoAlmacenable;
            }
        }

        public bool NodoProcesado
        {
            get
            {
                return this._nodoProcesado;
            }
        }

    }
}
