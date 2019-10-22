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
    class MenuManager
    {
        #region Variables
        List<string> menuItems;
        List<string> animationTypes;
        List<Texture2D> menuImages;
        List<List<Animation>> animation;
        List<Animation> tempAnimation;
        SpriteFont font;
        ContentManager content;
        Vector2 position;
        int axis;
        Rectangle sourceRect;
        int itemNumber;
        #endregion

        #region Properties



        #endregion

        #region Methods

        private void SetMenuItems()
        {
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (menuImages.Count == i)
                {
                    menuImages.Add(null);
                }
                if (menuItems.Count == i)
                {
                    menuItems.Add("");
                }
            }
        }
        private void SetAnimations()
        {
            Vector2 pos = position;
            Vector2 dimensions;

            for (int i = 0; i < menuItems.Count; i++)
            {
                for (int j = 0; j < animationTypes.Count; j++)
                {
                    switch (animationTypes[j])
                    {
                        case "Fade":
                            tempAnimation.Add(new FadeAnimation());
                            tempAnimation[tempAnimation.Count - 1].LoadContent(content, menuImages[i], menuItems[i], pos);
                            break;
                    }
                }
                if (tempAnimation.Count > 0)
                {
                    animation.Add(tempAnimation);
                }
                
                tempAnimation = new List<Animation>();

                dimensions = new Vector2(font.MeasureString(menuItems[i]).X , font.MeasureString(menuItems[i]).Y );
                if (axis == 1)
                {
                    pos.X += dimensions.X;
                }
                else
                {
                    pos.Y += dimensions.Y;
                }
            }
        }
        private void LoadMenuItems()
        {
            menuItems.Add("Start Game");
            menuItems.Add("Options");
            menuItems.Add("Exit Game");
        }

        

        public void LoadContent(ContentManager Content)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            menuItems = new List<string>();
            tempAnimation = new List<Animation>();
            animationTypes = new List<string>();
            menuImages = new List<Texture2D>();
            animation = new List<List<Animation>>();
            font = content.Load<SpriteFont>("MenuFont");
            position = new Vector2(960, 680);
            axis = 2;
            itemNumber = 0;


            //Inladen van items moet nog gebeuren
            animationTypes.Add("Fade");
            LoadMenuItems();
            SetMenuItems();
            SetAnimations();
            
        }

        public void UnloadContent()
        {
            content.Unload();
            position = Vector2.Zero;
            animation.Clear();
            menuItems.Clear();
            menuImages.Clear();
            animationTypes.Clear();
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < animation.Count; i++)
            {
                for (int j = 0; j < animation[i].Count; j++)
                {
                    if (itemNumber == i)
                    {
                        animation[i][j].IsActive = true;
                    }
                    else
                    {
                        animation[i][j].IsActive = false;
                    }

                    animation[i][j].Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < animation.Count; i++)
            {
                for (int j = 0; j < animation[i].Count; j++)
                {
                    animation[i][j].Draw(spriteBatch, 2);
                }
            }
        }
        #endregion
    }
}
