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
    class FadeAnimation : Animation
    {
        #region Variables

        bool increase, stopUpdating;
        float fadeSpeed, activateValue, defaultAlpha;
        TimeSpan defaultTime, timer;

        #endregion

        #region Properties

        public override float Alpha
        {
            get { return alpha; }
            set
            {
                alpha = value;
                if (alpha == 1.0f)
                {
                    increase = false;
                }
                else if (alpha == 0.0f)
                {
                    increase = true;
                }
            }
        }

        public float ActivateValue
        {
            get { return activateValue; }
            set { activateValue = value; }
        }

        public float FadeSpeed
        {
            get { return fadeSpeed; }
            set { fadeSpeed = value; }
        }

        public TimeSpan Timer
        {
            get { return timer; }
            set { defaultTime = value; timer = defaultTime; }
        }

        #endregion

        #region Methods

        public override void LoadContent(ContentManager _content, Texture2D _image, string _text, Vector2 _position)
        {
            base.LoadContent(_content, _image, _text, _position);
            increase = false;
            fadeSpeed = 1.0f;
            defaultTime = new TimeSpan(0, 0, 1);
            timer = defaultTime;
            activateValue = 0.0f;
            stopUpdating = false;
            defaultAlpha = alpha;
        }
        public override void Update(GameTime gameTime)
        {
            if (isActive)
            {
                if (!stopUpdating)
                {
                    if (!increase)
                    {
                        //Fade out
                        alpha -= fadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    else
                    {
                        //Fade in
                        alpha += fadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }

                    if (alpha <= 0.0f)
                    {
                        alpha = 0.0f;
                        increase = true;
                    }
                    else if (alpha >= 1.0f)
                    {
                        alpha = 1.0f;
                        increase = false;
                    }
                }
                if (alpha == activateValue)
                {
                    stopUpdating = true;
                    timer -= gameTime.ElapsedGameTime;
                    if (timer.TotalSeconds <= 0)
                    {
                        //increase = !increase;
                        timer = defaultTime;
                        stopUpdating = false;
                    }
                }
            }
            else
            {
                alpha = defaultAlpha;
            }
            
        }
        #endregion
    }
}
