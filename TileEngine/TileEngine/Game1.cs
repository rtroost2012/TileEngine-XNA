using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TileEngine
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        int squaresAcross = 5;
        int squaresDown = 5;

        TileMap myMap = new TileMap();
        Camera camera;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            camera = new Camera(myMap, squaresDown, squaresAcross);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load textures
            Tile.TileSetTexture = Content.Load<Texture2D>(@"Textures\TileSets\part1_tileset");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // Camera movement
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Left)) {
               camera.moveLeft();
            } else if (ks.IsKeyDown(Keys.Right)) {
                camera.moveRight();
            } else if (ks.IsKeyDown(Keys.Up)) {
                camera.moveUp();
            } else if (ks.IsKeyDown(Keys.Down)) {
                camera.moveDown();
            }

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

            Vector2 firstSquare = new Vector2(camera.location.X / 32, camera.location.Y / 32);
            int firstX = (int)firstSquare.X;
            int firstY = (int)firstSquare.Y;

            /*
             * If we are halfway through a tile to the right (Camera.Location = (16,0)) 
             * we want to shift everything we draw 16 pixels to the left so that the right part 
             * of the tile shows up in the upper left corner of the screen. 
             */
            Vector2 squareOffset = new Vector2(camera.location.X % 32, camera.location.Y % 32);
            int offsetX = (int)squareOffset.X;
            int offsetY = (int)squareOffset.Y;

            Window.Title = "TileEngine | Camera: " + camera.location.X + "," + camera.location.Y + " | firstSquare: " + firstX + "," + firstY + " | offset: " + offsetX + "," + offsetY;

            for (int y = 0; y < squaresDown; y++)
            {
                for (int x = 0; x < squaresAcross; x++)
                {
                    spriteBatch.Draw(
                        Tile.TileSetTexture,
                        new Rectangle((x * 32) - offsetX, (y * 32) - offsetY, 32, 32), // Determines where on the screen the tile will be drawn
                        Tile.getSourceRectangle(myMap.rows[y + firstY].columns[x + firstX].tileID), // Look up tile information
                        Color.White);
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
