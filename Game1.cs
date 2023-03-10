using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Loading_a_Spritesheet
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        List<Texture2D> characterTextures;
        List<Texture2D> cardTextures;

        Texture2D characterSpritesheet;
        Texture2D cardSpritesheet;

        Texture2D characterTexture; 
        Rectangle characterRect;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            characterRect = new Rectangle(50, 50, 25, 35);
            characterTextures = new List<Texture2D>();  
            cardTextures = new List<Texture2D>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            characterSpritesheet = Content.Load<Texture2D>("pixel_character");
            cardSpritesheet = Content.Load<Texture2D>("card_deck");
            Texture2D cropTexture;
            Rectangle sourceRect;

            // Character Dimensions
            int width = 117;
            int height = 150;


                        /* This is the solution for cropping one texture from a spritesheet
            // This region will be cropped from the spritesheet
            Rectangle sourceRect = new Rectangle(8, 33, width, height);  
            
            // Creates an empty Texture2D that will be filled with pixel data from the region we are cropping
            characterTexture = new Texture2D(GraphicsDevice, sourceRect.Width, sourceRect.Height);
            
            // Creates an array to temporarily store all of the pixeldata from the region we are cropping
            Color[] data = new Color[sourceRect.Width * sourceRect.Height];

            // Fills the array with the pixeldata from the spritesheet contained in the region we are cropping
            characterSpritesheet.GetData(0, sourceRect, data, 0, data.Length);

            // Puts the pixeldata into the Texture2D for our character
            characterTexture.SetData(data);

            Add rest of textures to spritesheet

            */


            // Load Card Textures using a loop
            // Card Dimensions

            


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(characterTexture, characterRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}