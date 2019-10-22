using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Pitfall
{
    class ScreenManager : GameScreen
    {
        #region Variables

        GameScreen currentScreen;
        GameScreen newScreen;
        //ContentManager content;
        private static ScreenManager instance;

        Stack<GameScreen> screenStack = new Stack<GameScreen>();

        //Width & height scherm
        public Vector2 dimensions { get; set; }

        bool transition;
        FadeAnimation fade;
        Texture2D fadeTexture;
        InputManager inputManager;
        #endregion

        #region Properties

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScreenManager();
                }
                return instance;
            }
        }

        #endregion

        #region Methods

        public void AddScreen(GameScreen screen, InputManager _inputManager)
        {
            transition = true;
            newScreen = screen;
            fade.IsActive = true;
            fade.Alpha = 0.0f;
            fade.ActivateValue = 1.0f;
            inputManager = _inputManager;
        }

        public void Initialize()
        {
            currentScreen = new SplashScreen();
            fade = new FadeAnimation();
            inputManager = new InputManager();
        }

        public override void LoadContent(ContentManager Content, InputManager _inputManager)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(Content, inputManager);
            fadeTexture = content.Load<Texture2D>("BlackPixel");
            fade.LoadContent(content, fadeTexture, "", Vector2.Zero);
            fade.Scale = dimensions.X;
        }

        public override void Update(GameTime gameTime)
        {
            if (!transition)
            {
                currentScreen.Update(gameTime);
            }
            else
            {
                Transition(gameTime);
            }
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
            if (transition)
            {
                fade.Draw(spriteBatch);
            }
        }

        private void Transition(GameTime gameTime)
        {
            fade.Update(gameTime);
            if (fade.Alpha == 1.0f && fade.Timer.TotalSeconds == 1.0f)
            {
                screenStack.Push(newScreen);
                currentScreen.UnloadContent();
                currentScreen = newScreen;
                currentScreen.LoadContent(content, inputManager);
            }
            else if (fade.Alpha == 0.0f)
            {
                transition = false;
                fade.IsActive = false;
            }
        }

        #endregion
    }
}
