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

        Rectangle cardRect;

        MouseState mouseState;
        MouseState prevMouseState;

        int cardIndex;

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
            cardRect = new Rectangle(300, 50, 66, 100);
            characterTextures = new List<Texture2D>();  
            cardTextures = new List<Texture2D>();
            cardIndex = 0;
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

            // Character dimensions on spritesheet
            int width = 117;
            int height = 150;

            // This is the solution for cropping one texture from a spritesheet
            // This region will be cropped from the spritesheet
            sourceRect = new Rectangle(8, 33, width, height);  

            // Creates an empty Texture2D that will be filled with pixel data from the region we are cropping
            characterTexture = new Texture2D(GraphicsDevice, sourceRect.Width, sourceRect.Height);

            // Creates an array to temporarily store all of the pixeldata from the region we are cropping
            Color[] data = new Color[sourceRect.Width * sourceRect.Height];

            // Fills the array with the pixeldata from the spritesheet contained in the region we are cropping
            characterSpritesheet.GetData(0, sourceRect, data, 0, data.Length);

            // Puts the pixeldata into the Texture2D for our character
            characterTexture.SetData(data);

         
            // Load Card Textures using a loop
            // Card Dimensions.  Make sure the spritesheets dimensions are evenly divisible by the number of items rows and columns
            width = cardSpritesheet.Width / 13;     // 13 cards in a row
            height = cardSpritesheet.Height / 5;    // 5 rows

            for(int y = 0; y < 5; y++)
                for (int x = 0; x < 13; x++)
                {
                    // This is the region that will be cropped from the spritesheet
                    sourceRect = new Rectangle(x * width, y * height, width, height);
                    // Creates an empty Texture2D that will be filled with pixel data from the region we are cropping
                    cropTexture = new Texture2D(GraphicsDevice, width, height);
                    // Creates an array to temporarily store all of the pixeldata from the region we are cropping                    Color[] data = new Color[width * height];
                    data = new Color[width * height];
                    // Puts the pixeldata from the spritesheet into the array
                    cardSpritesheet.GetData(0, sourceRect, data, 0, data.Length);
                    // Puts pixeldata from the array into the Texture2D
                    cropTexture.SetData(data);

                    // Stops adding cards when the final card in the spreadhseet is added
                    if (cardTextures.Count < 55)
                        cardTextures.Add(cropTexture);
                }
        }

        protected override void Update(GameTime gameTime)
        {
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Allows us to scroll through the List of card Texture2D's using the mouse
            // Detects a single left mouse click
            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                cardIndex -= 1;    
            // Detects a single right mouse click
            else if (mouseState.RightButton == ButtonState.Pressed && prevMouseState.RightButton == ButtonState.Released)
                cardIndex += 1;

            // Verifies we don't go beyond the bounds of the List
            if (cardIndex < 0)
                cardIndex = 0;
            else if (cardIndex >= cardTextures.Count)
                cardIndex = cardTextures.Count - 1;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(characterTexture, characterRect, Color.White);
            _spriteBatch.Draw(cardTextures[cardIndex], cardRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}