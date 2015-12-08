using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using BombitaTP2.Exceptions;
using BombitaTP2;
using System.Collections;

namespace BombitaTP2
{
    public class Coordenada: IObjetoPersistible
    {
        static int _cantidadObjetosClase = 0;
        private int _primaryKey;
        protected bool _nodoProcesado;       

        int _coordenadaX;
        int _coordenadaY;

        public Coordenada(int coordenadaX, int coordenadaY)
        {
            _coordenadaX = coordenadaX;
            _coordenadaY = coordenadaY;

            _cantidadObjetosClase += 1;
            _primaryKey = _cantidadObjetosClase;
            _nodoProcesado = false;
        }

        public Coordenada(Coordenada coordenadaACopiar)
        {
            _coordenadaX = coordenadaACopiar.CoordenadaX;
            _coordenadaY = coordenadaACopiar.CoordenadaY;
        }

        public double CalcularDistanciaConCoordenada(Coordenada parametroCoordenada)
        {
            return Math.Sqrt((Math.Pow(_coordenadaX - parametroCoordenada.CoordenadaX, 2)) + (Math.Pow(_coordenadaY - parametroCoordenada.CoordenadaY, 2)));
        }

        public void ModificarEnDireccion(Direccion direccion)
        {
            if (direccion == Direccion.Arriba) {
                _coordenadaY--;
            } else if (direccion == Direccion.Abajo) {
                _coordenadaY++;
            } else if (direccion == Direccion.Derecha) {
                _coordenadaX++;
            } else if (direccion == Direccion.Izquierda) {
                _coordenadaX--;
            } else if(direccion == Direccion.Ninguna){

            }
        }

        public void ModificarEnDireccionInversaA(Direccion direccion)
        {
            if (direccion == Direccion.Arriba)
            {
                _coordenadaY++;
            }
            else if (direccion == Direccion.Abajo)
            {
                _coordenadaY--;
            }
            else if (direccion == Direccion.Derecha)
            {
                _coordenadaX--;
            }
            else if (direccion == Direccion.Izquierda)
            {
                _coordenadaX++;
            }
            else if (direccion == Direccion.Ninguna)
            {

            }

        }

        public bool EsIgualA(Coordenada coordenadaAComparar)
        {
            if ((_coordenadaX == coordenadaAComparar.CoordenadaX) && (_coordenadaY == coordenadaAComparar.CoordenadaY))
                return true;
            else
                return false;

        }


        public virtual void Guardar(String archivo)
        {
            this._nodoProcesado = true;

            this.GuardarNodo(archivo);

            this.GuardarAdyacentes(archivo);
        }

        protected virtual void GuardarNodo(string archivo)
        {
            //  Proceso nodo
            List<AtributoNodo> listaDatosNodo = new List<AtributoNodo>();
            listaDatosNodo.Add(new AtributoNodo("CoordenadaX", this.CoordenadaX));
            listaDatosNodo.Add(new AtributoNodo("CoordenadaY", this.CoordenadaY));
            List<IObjetoPersistible> listaDatosForeing = new List<IObjetoPersistible>();

            FormateadorXml.CreateNodoObjeto(archivo, this, listaDatosNodo, listaDatosForeing);
        }

        protected virtual void GuardarAdyacentes(string archivo)
        {
        }


        public static Coordenada Restaurar(int primaryKey, string archivo, List<ObjetoRestaurado> objetosRestaurados)
        {
            try
            {
                Coordenada coordenadaRestaurar = new Coordenada(0, 0);

                // Valido objeto no fue restaurado previamente, conservo identidad
                foreach (ObjetoRestaurado a in objetosRestaurados)
                {
                    if (a.PrimaryKey == primaryKey)
                        if (a.ObetoRestaurado.GetType().Name == coordenadaRestaurar.GetType().Name)
                            return (Coordenada)a.ObetoRestaurado;
                }
                
                // Restauro
                XmlElement elementoXml = getXmlElementObjeto(primaryKey, archivo, coordenadaRestaurar);

                RestaurarNodo(elementoXml, coordenadaRestaurar);

                RestaurarAdyacentes(elementoXml);
                
                // Finalizo
                objetosRestaurados.Add( new ObjetoRestaurado( coordenadaRestaurar, primaryKey) );
                return coordenadaRestaurar;

            }
            catch (RestauracionObjetoNoExistenteException)
            {
                throw;
            }
        }

        protected static void RestaurarNodo(XmlElement elementoNodo, Coordenada coordenadaRestaurar)
        {
            coordenadaRestaurar._coordenadaX = int.Parse( elementoNodo.Attributes["CoordenadaX"].Value );
            coordenadaRestaurar._coordenadaY = int.Parse( elementoNodo.Attributes["CoordenadaY"].Value );
        }

        protected static void RestaurarAdyacentes(XmlElement elementoNodo)
        {
        }

        protected static XmlElement getXmlElementObjeto(int primaryKey, string archivo, Coordenada coordenadaRestauracion)
        {
            return FormateadorXml.getXmlElementObjeto(coordenadaRestauracion.GetType().Name, primaryKey, archivo);
        }

        // Pripiedades
        public int CoordenadaX
        {
            get { return _coordenadaX; }            
        }

        public int CoordenadaY
        {
            get { return _coordenadaY; }
        }

        public int PrimaryKey
        {
            get
            {
                return this._primaryKey;
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


