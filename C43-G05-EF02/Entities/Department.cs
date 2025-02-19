using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C43_G05_EF02.Entities
{
    internal class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateEstablished { get; set; }

        // Navigational property
        public Employee Manager { get; set; }
    }
}
