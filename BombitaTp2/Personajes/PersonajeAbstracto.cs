using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombitaTP2.Armamento;
using BombitaTP2.Escenario;
using BombitaTP2.ObjetosAlmacenables;
using BombitaTP2.Obstaculos;
using BombitaTP2.Desarrollo_de_Juego;



namespace BombitaTP2.Personajes
{
    public abstract class PersonajeAbstracto :  IPersonaje , IObservadorArmamento
    {
        static int _cantidadObjetosClase = 0;
        private int _primaryKey;
        private int _foreignKeyMapa;
        private int _foreignKeyCoordenada;
        private int _foreignKeyCronometroTiempoAtacar;
        private int _foreignKeyCronometroTiempoMovimiento;
        protected bool _nodoProcesado;       

        protected Direccion _direccionMovimiento;
        protected Coordenada _coordenada;
        protected bool _estaEnMovimiento;
        protected bool _debeAtacar;
        protected bool _habilitadoParaAtacar;
        protected Mapa _mapa;        
        protected Cronometro _contadorTiempoMovimiento, _contadorTiempoAtacar;
        
        
        public PersonajeAbstracto(Coordenada nuevaCoordenada, Mapa mapa,int retardoDeMovimiento)            
        {
            _direccionMovimiento = Direccion.Ninguna;            
            this._estaEnMovimiento = false;
            this._debeAtacar = false;
            _habilitadoParaAtacar = true;
            _coordenada = nuevaCoordenada;
            _mapa = mapa;
            _contadorTiempoMovimiento = new Cronometro(retardoDeMovimiento);
            _contadorTiempoAtacar = new Cronometro(20);
            

            _cantidadObjetosClase += 1;
            this._primaryKey = _cantidadObjetosClase;
            this._foreignKeyMapa = _mapa.PrimaryKey;
            this._foreignKeyCoordenada = _coordenada.PrimaryKey;
            this._foreignKeyCronometroTiempoAtacar = _contadorTiempoAtacar.PrimaryKey;
            this._foreignKeyCronometroTiempoMovimiento = _contadorTiempoAtacar.PrimaryKey;
            _nodoProcesado = false;
        }

        public void Vivir()
        {
            if (_estaEnMovimiento)
                this.Moverse();
            if (_debeAtacar)
                this.ActivarArmamento();
        }

        public void Atacar()
        {
            if (_habilitadoParaAtacar)
            {
                _debeAtacar = true;
                _habilitadoParaAtacar = false;
            }
        }

        public virtual void Destruir()
        {            
            _mapa.EliminarObjeto(this);
        }

        
        public abstract bool EstaMuerto();
                    
        public bool EstaEnContactoCon(Coordenada coordenadaObjetoAContactar)
        {
            return _coordenada.EsIgualA(coordenadaObjetoAContactar);
        }

        private bool EstaFueraDeLimitesDeMapa()
        {
            if ((_coordenada.CoordenadaX) > _mapa.DimensionX)
                return true;
            if ((_coordenada.CoordenadaX) < 0)
                return true;
            if ((_coordenada.CoordenadaY) > _mapa.DimensionY)
                return true;
            if ((_coordenada.CoordenadaY) < 0)
                return true;

            return false;
        }

        protected virtual void ActivarArmamento() { }
                                    
        public virtual void ColisionarCon(ObstaculoAbstracto obstaculo)
        {
            this.RetrotraerMovimiento();            
        }

        public void ColisionarCon(ArmamentoAbstracto armamento)
        {
            this.RetrotraerMovimiento();
        }

        public abstract void ColisionarCon(Bombita bombita);

        public abstract void ColisionarCon(EnemigoAbstracto enemigo);

        public abstract void ColisionarCon(LopezReggaeAlado alado);

        protected abstract void RealizarColisiones(List<IObjetoDeMapa> listObjetos);

        public abstract void ImpactarCon(Proyectil proyectil);

        public abstract void ImpactarCon(Molotov molotov);

        public abstract void ImpactarCon(ToleTole toleTole);
                
        public void ActivarMovimiento(Direccion nuevaDireccionMovimiento)
        {
            if (!_estaEnMovimiento)
            {
                _direccionMovimiento = nuevaDireccionMovimiento;
                _estaEnMovimiento = true;
            }
        }

        private void Moverse()
        {
            List<IObjetoDeMapa> objetosColisionados = null;
            bool seMovio;
            Coordenada coordenadaAntigua = new Coordenada(_coordenada);

            if (_contadorTiempoMovimiento.EstaFinalizadoElConteo())
            {
                _contadorTiempoMovimiento.ResetearConteo();                
                _coordenada.ModificarEnDireccion(_direccionMovimiento);
                if (!this.EstaFueraDeLimitesDeMapa())
                    seMovio = true;
                else
                {
                    _coordenada = coordenadaAntigua;
                    seMovio = false;
                    _estaEnMovimiento = false;
                }
            }
            else
            {
                _contadorTiempoMovimiento.IncrementarConteo();
                seMovio = false;
            }
                                                 
            if (seMovio)
            {
                objetosColisionados = _mapa.BuscarColisiones(this);
                _estaEnMovimiento = false;
                if (objetosColisionados != null)
                    RealizarColisiones(objetosColisionados);                
            }
        }
        
        // Recupera la coordenada antigua
        public void RetrotraerMovimiento()
        {            
            _coordenada.ModificarEnDireccionInversaA(_direccionMovimiento);
        }

        public void NotificarBajaArmamento(IArmamento armamento)
        {
            _habilitadoParaAtacar = true;
        }

        public virtual void Guardar(String archivo)
        {
            this._nodoProcesado = true;

            this.GuardarNodo(archivo);

            this.GuardarAdyacentes(archivo);
        }

        protected virtual void GuardarNodo(string archivo)
        {
            List<AtributoNodo> listaDatosNodo = new List<AtributoNodo>();
            listaDatosNodo.Add( new AtributoNodo("DireccionMovimiento", this._direccionMovimiento.ToString()) );
            listaDatosNodo.Add( new AtributoNodo("EstaEnMovimiento", this._estaEnMovimiento) );
            listaDatosNodo.Add( new AtributoNodo("DebeAtacar", this._debeAtacar) );
            List<IObjetoPersistible> listaDatosForeing = new List<IObjetoPersistible>();
            listaDatosForeing.Add(this._coordenada);
            listaDatosForeing.Add(this._mapa);
            listaDatosForeing.Add(this._contadorTiempoMovimiento);
            listaDatosForeing.Add(this._contadorTiempoAtacar);

            FormateadorXml.CreateNodoObjeto(archivo, this, listaDatosNodo, listaDatosForeing);
        }

        protected virtual void GuardarAdyacentes(string archivo)
        {
            if (!this._coordenada.NodoProcesado)
                this._coordenada.Guardar(archivo);

            if (!this._contadorTiempoMovimiento.NodoProcesado)
                this._contadorTiempoMovimiento.Guardar(archivo);

            if (!this._contadorTiempoAtacar.NodoProcesado)
                this._contadorTiempoAtacar.Guardar(archivo);

            if (!this._mapa.NodoProcesado)
            {
                //this._mapa.Guardar(archivo);
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

        public int ForeignKeyCronometroTiempoAtacar
        {
            get
            {
                return this._foreignKeyCronometroTiempoAtacar;
            }
        }

        public int ForeignKeyCronometroTiempoMovimiento
        {
            get
            {
                return this._foreignKeyCronometroTiempoMovimiento;
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
