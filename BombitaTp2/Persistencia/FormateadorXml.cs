using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombitaTP2.Escenario;
using BombitaTP2.Obstaculos;
using BombitaTP2.Armamento;
using System.Xml;
using System.IO;
using System.Collections;
using BombitaTP2.Exceptions;
using BombitaTP2;

namespace BombitaTP2
{
    public static class FormateadorXml
    {

        // Descripcion: Crea nodo root en el archivo xml indicado. 
        // Pre: No tiene. 
        // Post: Nodo creado en el documento xml.
        public static void CrearRootNodeDocument(string archivo, IObjetoPersistible objeto)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement xmlNodoRootDest = doc.CreateElement(objeto.GetType().Name);
            doc.AppendChild(xmlNodoRootDest);
            
            FormateadorXml.CreateNodeDatoClase(doc, xmlNodoRootDest, "PrimaryKey", objeto.PrimaryKey.ToString());

            doc.Save(archivo);
        }

        
        // Descripcion: Agrega un nodo y todos sus atributos distinguiendo entre atributos de Clase (tipos base) y 
        //              y tipos definidos por el programador. En estos ultimos almacena la FK a efecto de restaurarlo. 
        // Pre: Nodo root creado en el documento xml.
        // Post: Nodo agregado en el documento xml.
        public static void CreateNodoObjeto(    string archivo, 
                                                IObjetoPersistible NodoCrear, 
                                                List<AtributoNodo> atributosNodo, 
                                                List<IObjetoPersistible> atributosForeign)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(archivo);
            XmlElement xmlNodoRoot = doc.DocumentElement;

            // Busco el nodo donde almacenar el objeto
            XmlElement xmlPosicionAlmacenamiento = ObtenerNodoDeTipoDeDatoAAlmacenar(NodoCrear, doc, xmlNodoRoot);

            XmlElement xmlElementoGuardar = ObtenerNodoDeDatoAAlmacenar(doc, xmlPosicionAlmacenamiento, NodoCrear);

            FormateadorXml.CreateNodeDatoClase(doc, xmlElementoGuardar, "PrimaryKey", NodoCrear.PrimaryKey.ToString());

            // Proceso los atributos del nodos
            IEnumerator it = atributosNodo.GetEnumerator();
            while (it.MoveNext())
            {
                AtributoNodo elemento = (AtributoNodo)it.Current;
                FormateadorXml.CreateNodeDatoClase(doc, xmlElementoGuardar, elemento.Nombre, elemento.Objeto.ToString()); 
            }

            // Proceso los objetos foraneos
            IEnumerator it2 = atributosForeign.GetEnumerator();
            while (it2.MoveNext())
            {
                IObjetoPersistible elemento = (IObjetoPersistible)it2.Current;

                XmlElement xmlNodeForeign = FormateadorXml.CreateNodo(doc, xmlElementoGuardar, elemento);
                FormateadorXml.CreateNodeDatoClase(doc, xmlNodeForeign, "ForeignKey", elemento.PrimaryKey.ToString());
            }

            doc.Save(archivo);
        }

        private static XmlElement ObtenerNodoDeTipoDeDatoAAlmacenar(IObjetoPersistible Objeto, XmlDocument doc, XmlElement xmlRootElemnt)
        {
            foreach (XmlElement a in doc.DocumentElement.ChildNodes)
            {
                if (a.Name == Objeto.GetType().Name + "Main")
                    return a;
            }
            // Caso de no existir lo creo
            XmlElement xmlNodo = doc.CreateElement(Objeto.GetType().Name + "Main");
            xmlRootElemnt.AppendChild(xmlNodo);
            return xmlNodo;
        }

        private static XmlElement ObtenerNodoDeDatoAAlmacenar(XmlDocument doc, XmlElement xmlPosicionAlmacenamiento, IObjetoPersistible NodoCrear)
        {
            foreach (XmlElement a in xmlPosicionAlmacenamiento.ChildNodes)
            {
                if (a.Attributes["PrimaryKey"].Value == NodoCrear.PrimaryKey.ToString())
                {
                    return a;
                }
            }

            XmlElement xmlElementoGuardar = CreateNodo(doc, xmlPosicionAlmacenamiento, NodoCrear);

            return xmlElementoGuardar;
        }

        private static XmlElement CreateNodo(XmlDocument doc, XmlElement xmlNodoRoot, IObjetoPersistible objeto)
        {
            XmlElement xmlNodeNuevo = doc.CreateElement(objeto.GetType().Name);
            xmlNodoRoot.AppendChild(xmlNodeNuevo);
            return xmlNodeNuevo;
        }

        private static void CreateNodeDatoClase(XmlDocument doc, XmlElement xmlNodo, String atributo, String value)
        {
            bool esta = false;
            foreach (XmlElement a in xmlNodo.ChildNodes)
            {
                if (a.Name == atributo)
                    esta = true;
            }

            if (!esta)
            {
                XmlAttribute xmlAtributo = doc.CreateAttribute(atributo);
                xmlAtributo.Value = value;
                xmlNodo.Attributes.Append(xmlAtributo);
            }
        }


        // Descripcion: Regresa el elemento de almacenamiento del objeto. Si no lo encuentra lanza exception.
        // Pre: Nodo de busqueda existente (primaryKey + classType)
        // Post: -
        public static XmlElement getXmlElementObjeto(string tipoDato, int primaryKey, string archivo)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(archivo);
            XmlElement xmlNodoRoot = doc.DocumentElement;

            // Busco el nodo y lo retorno
            try
            {
                XmlElement xmlPosicionTipoClase = ObtenerNodoDeTipoDeDato(tipoDato, doc, xmlNodoRoot);

                XmlElement xmlElemento = ObtenerNodoDeDato(primaryKey, xmlPosicionTipoClase);

                return xmlElemento;
            }
            catch (RestauracionObjetoNoExistenteException)
            {
                throw;
            }

        }

        private static XmlElement ObtenerNodoDeTipoDeDato(string nombreTipoDato, XmlDocument doc, XmlElement xmlRootElemnt)
        {
            foreach (XmlElement a in doc.DocumentElement.ChildNodes)
            {
                if (a.Name == nombreTipoDato + "Main")
                    return a;
            }

            throw new RestauracionObjetoNoExistenteException();
        }

        // Descripcion: Regresa el elemento de almacenamiento del objeto. Si no lo encuentra lanza exception.
        // Pre: Nodo de busqueda existente (primaryKey )
        // Post: -
        public static XmlElement ObtenerNodoDeDato(int primaryKey, XmlElement xmlPosicion)
        {
            foreach (XmlElement a in xmlPosicion.ChildNodes)
            {
                if (a.Attributes["PrimaryKey"].Value == primaryKey.ToString())
                {
                    return a;
                }
            }

            throw new RestauracionObjetoNoExistenteException();
        }

    }

}

public class AtributoNodo
{
    private String _nombre;
    private Object _objeto;

    public AtributoNodo(String nombre, Object objeto)
    {
        this._nombre = nombre;
        this._objeto = objeto;
    }
    public String Nombre
    {
        get { return _nombre; }
    }
    public Object Objeto
    {
        get { return _objeto; }
    }
}

public class ObjetoRestaurado
{
    private IObjetoPersistible _obetoRestaurado;
    private int _primaryKey;

    public ObjetoRestaurado(IObjetoPersistible obetoRestaurado, int primaryKey)
    {
        this._primaryKey = primaryKey;
        this._obetoRestaurado = obetoRestaurado;
    }

    public IObjetoPersistible ObetoRestaurado
    {
        get { return _obetoRestaurado; }
    }

    public int PrimaryKey
    {
        get { return _primaryKey; }
    }
}