using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Template
{
    public class Enemy : GameObject
    {
        public Enemy(string spriteName, Transform Transform) : base(spriteName, Transform)
        {
        }
    }
}