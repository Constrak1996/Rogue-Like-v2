﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Template
{
    public class MeleeEnemy : Enemy
    {
        public MeleeEnemy(string spriteName, Transform Transform, int damage) : base(spriteName, Transform, damage)
        {
        }
    }
}