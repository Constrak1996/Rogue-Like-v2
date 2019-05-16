using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private static ContentManager _content;
        public static ContentManager ContentManager{ get => _content; }

        //The lists used for loading and removing items
        public static List<GameObject> gameObjects = new List<GameObject>();
        public static List<GameObject> gameObjectsAdd = new List<GameObject>();
        public static List<GameObject> gameObjectsRemove = new List<GameObject>();

        //Graphics
        public static int Width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        public static int Height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        Player player;

        //Collision
        private Texture2D collisionTexture;

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _content = Content;

            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Collisionbox texture
            collisionTexture = Content.Load<Texture2D>("OnePixel");

            //Player
            player = new Player("Fisher_Bob", new Transform(new Vector2(400, 50), 0));
            gameObjectsAdd.Add(player);
            
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
           
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Updates gameobjects
            foreach (GameObject go in gameObjects)
            {
                go.Update();
            }

            //Adds gameobjects to the gameobjects list
            if (gameObjectsAdd.Count > 0)
            {
                for (int i = 0; i < gameObjectsAdd.Count; i++)
                {
                    gameObjects.Add(gameObjectsAdd[i]);
                }
                gameObjectsAdd.Clear();
            }

            PlayerMovement(3);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //Draws sprites in gameObjects list
            foreach (GameObject go in gameObjects)
            {
                go.Draw(spriteBatch);
            }

            //Collision texture draw
                foreach (GameObject go in gameObjects)
                {
                    go.Draw(spriteBatch);
#if DEBUG
                    DrawCollisionBox(go);
#endif
                }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// DrawCollisionBox draws a line around the given texture, used for debugging any collision issues
        /// </summary>
        /// <param name="go"></param>
        public void DrawCollisionBox(GameObject go)
        {
            //Creating a box around the object
            Rectangle collisionBox = go.Hitbox;

            Rectangle topLine = new Rectangle(collisionBox.Center.X - collisionBox.Width, collisionBox.Center.Y - collisionBox.Height, collisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.Center.X - collisionBox.Width, collisionBox.Center.Y - collisionBox.Height / 30, collisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(collisionBox.Center.X + collisionBox.Width / 30, collisionBox.Center.Y - collisionBox.Height, 1, collisionBox.Height);
            Rectangle leftLine = new Rectangle(collisionBox.Center.X - collisionBox.Width, collisionBox.Center.Y - collisionBox.Height , 1, collisionBox.Height);

            spriteBatch.Draw(collisionTexture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        }

        public void PlayerMovement(int speed)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                player.Transform.Position.Y -= 1 * speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                player.Transform.Position.X -= 1 * speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                player.Transform.Position.Y += 1 * speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                player.Transform.Position.X += 1 * speed;
            }
        }
    }
}
