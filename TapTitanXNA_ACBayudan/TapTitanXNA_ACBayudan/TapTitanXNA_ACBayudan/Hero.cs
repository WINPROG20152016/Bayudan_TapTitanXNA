using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace TapTitanXNA_ACBayudan
{
    public class Hero
    {
        #region Properties
        Vector2 playerPosition;
        Texture2D player;
        ContentManager content;
        Level level;

        Animation attackAnimation;
        
        AnimationPlayer spritePlayer;

        #endregion

        public Hero(ContentManager content, Level level)
        {
            this.content = content;
            this.level = level;
        }

        public void LoadContent()
        {
            player = content.Load<Texture2D>("HeroSprite/buu-idle");

            attackAnimation = new Animation(player, 0.1f, true, 7);


            int positionX = (Level.windowWidth / 2) - (attackAnimation.FrameWidth);
            int positionY = (Level.windowHeight / 2) - (attackAnimation.FrameHeight);
            playerPosition = new Vector2((float)positionX, (float)positionY);

            spritePlayer.PlayAnimation(attackAnimation);
        }

        public void IdleUpdate(GameTime gameTime)
        {
                player = content.Load<Texture2D>("HeroSprite/buu-idle");

                attackAnimation = new Animation(player, 0.1f, true, 7);


                int positionX = (Level.windowWidth / 2) - (attackAnimation.FrameWidth);
                int positionY = (Level.windowHeight / 2) - (attackAnimation.FrameHeight);
                playerPosition = new Vector2((float)positionX, (float)positionY);

                spritePlayer.PlayAnimation(attackAnimation);
            }


        public void AttackUpdate(GameTime gameTime)
        {

                player = content.Load<Texture2D>("HeroSprite/buu-attack");

                attackAnimation = new Animation(player, 0.1f, false, 7);


                int positionX = (Level.windowWidth / 2) - (attackAnimation.FrameWidth);
                int positionY = (Level.windowHeight / 2) - (attackAnimation.FrameHeight);
                playerPosition = new Vector2((float)positionX, (float)positionY);

                spritePlayer.PlayAnimation(attackAnimation);

                
            }
        



        

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(player,
            //playerPosition,
            //null,
            //Color.Pink,
            //0.0f,
            //Vector2.Zero,
            //0.5f,
            //SpriteEffects.None,
            //0.4f);
            //spriteBatch.Draw(animation.texture, Vector2.Zero, source, Color.White);
            spritePlayer.Draw(gameTime, spriteBatch, playerPosition, SpriteEffects.None);


        }
    }
}
