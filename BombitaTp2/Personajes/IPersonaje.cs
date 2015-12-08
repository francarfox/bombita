using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BombitaTP2.Escenario;
using BombitaTP2.ObjetosAlmacenables;

namespace BombitaTP2.Personajes
{
    public interface IPersonaje :  IObjetoVivo
    {
        void Atacar();        
    }
}
