using System;
using System.Linq;
using System.Text;
using System.IO;

namespace BombitaTP2
{
    public interface IObjetoPersistible
    {
        void Guardar(String archivo);
        //void Recuperar();
        bool NodoProcesado { get; }
        int PrimaryKey { get; }
    }
}
