using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Template
{
    public class Player : GameObject
    {
        public Player(string spriteName, Transform Transform) : base(spriteName, Transform)
        {
        }
    }
}