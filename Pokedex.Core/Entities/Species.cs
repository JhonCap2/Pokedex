using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Entities
{
    public partial class Species
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Pokemon? Pokemon { get; set; }
    }
}
