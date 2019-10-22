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
    class TitleScreen : GameScreen
    {
        SpriteFont font;
        Texture2D titleScreen;
        MenuManager menu;

        public override void LoadContent(ContentManager Content, InputManager _inputManager)
        {
            base.LoadContent(Content, inputManager);
            titleScreen = Content.Load<Texture2D>("TitleScreen");
            if (font == null)
            {
                font = content.Load<SpriteFont>("Comic");
            }
            menu = new MenuManager();
            menu.LoadContent(Content);
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
            menu.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            inputManager.Update();
            menu.Update(gameTime);
            if (inputManager.KeyPressed(Keys.Z))
            {
                ScreenManager.Instance.AddScreen(new SplashScreen(), inputManager);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(titleScreen, new Rectangle(0,0,GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height), Color.White);
            menu.Draw(spriteBatch);
        }
    }
}
