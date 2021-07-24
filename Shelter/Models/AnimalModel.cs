using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelter.Models
{
    public class AnimalModel
    {
        /*
         * string spieces
         * string name default = null
         * string description
         * int age = null
         * */

        public int Id { get; set; }
        public string Spieces { get; set; }
        public string Name { get; set; } = null;
        public string Description { get; set; } = null;
        public int Age { get; set; } = 0;
    }
}
