using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CartaoTodos.REST.Common;

namespace CartaoTodos.WebForms.Infra
{
    public class PerfilComparer : IEqualityComparer<REST.Common.Perfil>
    {
        public bool Equals(REST.Common.Perfil x, REST.Common.Perfil y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(REST.Common.Perfil obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}