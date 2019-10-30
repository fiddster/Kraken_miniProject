using System;
using System.Collections.Generic;
using System.Text;

namespace Kraken_WeaponSystem.Models
{
    class Target
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime? AttackedAt { get; private set; }
        public bool Status { get; protected set; } = false;
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int Z { get; protected set; }

        

        public Target(string name, string description, int x, int y, int z)
        {
            Name = name;
            Description = description;
            X = x;
            Y = y;
            Z = z;
        }

        public void Hit()
        {
            Status = true;
            AttackedAt = DateTime.Now;
        }

        public void Miss()
        {
            Status = false;
            AttackedAt = DateTime.Now;
        }

    }
}
