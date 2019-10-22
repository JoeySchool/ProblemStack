using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project_Pitfall
{
    class SplashScreen : GameScreen
    {
        //KeyboardState keyState;
        SpriteFont font;
        Texture2D startScreen;
        FadeAnimation fade;

        public override void LoadContent(ContentManager Content, InputManager _inputManager)
        {
            base.LoadContent(Content, inputManager);
            fade = new FadeAnimation();
            startScreen = Content.Load<Texture2D>("StartScreen");

            fade.LoadContent(Content, startScreen, "", Vector2.Zero);
            fade.IsActive = true;
            if (font == null)
            {
                font = content.Load<SpriteFont>("Comic");
            }
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            //keyState = Keyboard.GetState();
            //if (keyState.IsKeyDown(Keys.Z))
            //{
            //    ScreenManager.Instance.AddScreen(new TitleScreen());
            //}
            
            fade.Update(gameTime);

            if (fade.Alpha == 0.0f)
            {
                ScreenManager.Instance.AddScreen(new TitleScreen(), inputManager);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.DrawString(font, "Project PitFall", new Vector2(100, 100), Color.Black);
            //spriteBatch.Draw(startScreen, new Rectangle(0, 0, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height), Color.White);
            fade.Draw(spriteBatch);
        }
    }
}
