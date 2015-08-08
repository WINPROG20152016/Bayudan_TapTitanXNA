using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TapTitanXNA_ACBayudan
{
    public class Level
    {
        Button playButton;
        Button attackButton;
        public static int windowWidth = 800;
        public static int windowHeight = 800;
        #region Properties
        ContentManager content;

        Texture2D background;

        public MouseState oldMouseState;
        public MouseState mouseState;
        bool mpressed, prev_mpressed = false;
        int mouseX, mouseY;

        Hero hero;

        SpriteFont damageStringFont;
        public static int damageNumber;
        public static int attackidle;


        #endregion

        public Level(ContentManager content)
        {
            this.content = content;
            hero = new Hero(content, this);
        }

        public void LoadContent()
        {
            background = content.Load<Texture2D>("HeroSprite/bg");
            damageStringFont = content.Load<SpriteFont>("Font");

            playButton = new Button(content, "HeroSprite/badge-red", Vector2.Zero);
            attackButton = new Button(content, "HeroSprite/blue-badge", new Vector2(310, 650));

            hero.LoadContent();
        }

        public void Update(GameTime gameTime)
        {


            mouseState = Mouse.GetState();
            mouseX = mouseState.X;
            mouseY = mouseState.Y;
            prev_mpressed = mpressed;
            mpressed = mouseState.LeftButton == ButtonState.Pressed;


            if (attackButton.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed) && damageNumber < 40)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    hero.IdleUpdate(gameTime);

                }
                if (mouseState.LeftButton == ButtonState.Released)
                {
                    damageNumber += 1;
                    hero.AttackUpdate(gameTime);

                }
            
            }
            


        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, null, Color.Pink,0.0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0.4f);
             hero.Draw(gameTime, spriteBatch);

             if (damageNumber <= 9)
             {
                 spriteBatch.DrawString(damageStringFont, damageNumber + "sad", Vector2.Zero, Color.Pink);
                 attackButton.Draw(gameTime, spriteBatch);
             }

             if (damageNumber >= 10 && damageNumber <= 25)
             {
                 spriteBatch.DrawString(damageStringFont, damageNumber + " IT'S OVER 9.000!", Vector2.Zero, Color.Pink);
                 attackButton.Draw(gameTime, spriteBatch);
             }
             if(damageNumber > 25 && damageNumber < 35)
             {
                 spriteBatch.DrawString(damageStringFont, damageNumber + "it's starting to hurt", Vector2.Zero, Color.Pink);
                 attackButton.Draw(gameTime, spriteBatch);
             }

             if (damageNumber >= 35 && damageNumber != 40)
             {
                 spriteBatch.DrawString(damageStringFont, damageNumber + "we fokken won", Vector2.Zero, Color.Pink);
                 attackButton.Draw(gameTime, spriteBatch);
             }
             if (damageNumber == 40)
             {
                 damageNumber = 40;

                 spriteBatch.DrawString(damageStringFont," STAHP, we won already, nigger", Vector2.Zero, Color.Pink);
                 attackButton.Draw(gameTime, spriteBatch);
             }

        }
    }
}
