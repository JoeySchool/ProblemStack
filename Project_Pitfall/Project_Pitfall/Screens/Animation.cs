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
    class Animation
    {
        #region Variables

        protected Texture2D image;
        protected string text;
        protected SpriteFont font;
        protected Color color;
        protected Rectangle sourceRectangle;
        protected float rotation, scale, axis;
        protected Vector2 origin, position;
        protected ContentManager content;
        protected bool isActive;
        protected float alpha;

        #endregion

        #region Properties

        public virtual float Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        public float Scale
        {
            set{ scale = value; }
        }

        #endregion
        #region Methods
        public virtual void LoadContent(ContentManager _content, Texture2D _image, string _text, Vector2 _position)
        {
            content = new ContentManager(_content.ServiceProvider, "Content");
            image = _image;
            text = _text;
            position = _position;
            
            if (text != String.Empty)
            {
                font = content.Load<SpriteFont>("Comic");
                color = new Color(114, 77, 255);
            }

            if (image != null)
            {
                sourceRectangle = new Rectangle(0, 0, image.Width, image.Height);
            }
            rotation = 0;
            axis = 0;
            scale = 1;
            isActive = false;
            alpha = 1;
        }

        public virtual void UnloadContent()
        {
            content.Unload();
            text = String.Empty;
            position = Vector2.Zero;
            sourceRectangle = Rectangle.Empty;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (image != null)
            {
                origin = new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2);
                spriteBatch.Draw(image, position + origin, sourceRectangle, Color.White * alpha, rotation, origin, scale, SpriteEffects.None, 0.0f);
            }

            if (text != String.Empty)
            {
                origin = new Vector2(font.MeasureString(text).X / 2, font.MeasureString(text).Y / 2);
                spriteBatch.DrawString(font, text, position + origin, color * alpha, rotation, origin, scale, SpriteEffects.None, 0.0f);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, float _scale)
        {
            scale = _scale;
            if (image != null)
            {
                origin = new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2);
                spriteBatch.Draw(image, position + origin, sourceRectangle, Color.White * alpha, rotation, origin, scale, SpriteEffects.None, 0.0f);
            }

            if (text != String.Empty)
            {
                origin = new Vector2(font.MeasureString(text).X / 2, font.MeasureString(text).Y / 2);
                spriteBatch.DrawString(font, text, position + origin, color * alpha, rotation, origin, scale, SpriteEffects.None, 0.0f);
            }
        }
        #endregion
    }
}
