using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Template
{
    public class Enemy : GameObject
    {
        public int damage;

        public Enemy(string spriteName, Transform Transform, int damage) : base(spriteName, Transform)
        {
        }
    }
}