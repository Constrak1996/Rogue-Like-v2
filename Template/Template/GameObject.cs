using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public class GameObject
    {
        public Transform Transform;
        public Texture2D Sprite;
        public Vector2 spriteCenter;
        public string spriteName;

        /// <summary>
        /// Makes a rectangle that will be made into the objects hitbox
        /// </summary>
        public virtual Rectangle Hitbox
        {
            get { return new Rectangle((int)Transform.Position.X, (int)Transform.Position.Y, Sprite.Width, Sprite.Height); }
        }

        /// <summary>
        /// Constructor for our GameObject
        /// </summary>
        /// <param name="Sprite">The sprite for the specific object</param>
        /// <param name="Transform">All positions and such is held in here</param>
        public GameObject(string spriteName, Transform Transform)
        {
            this.Sprite = GameWorld.ContentManager.Load<Texture2D>(spriteName);
            this.Transform = Transform;
            spriteCenter = new Vector2(Sprite.Width * 0.5f, Sprite.Height * 0.5f);
        }
        public GameObject(Transform transform)
        {
            this.Transform = transform;

        }

        public virtual void Update()
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
    
    
}
