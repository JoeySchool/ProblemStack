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
    class GameScreen
    {
        protected ContentManager content;
        protected InputManager inputManager;
        public virtual void LoadContent(ContentManager Content, InputManager _inputManager)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            inputManager = _inputManager;
        }
        public virtual void UnloadContent()
        {
            content.Unload();
            inputManager = null;
        }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
