using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekno.CORE.Entity
{
    public interface IEntity<T> // Unique identifier
    {
        T ID { get; set; }
    }
}
