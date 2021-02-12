using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Graphics
{
    /// <summary>
    /// 2d Graphic to be drawn on screen
    /// </summary>
    public class Sprite
    {
        protected Texture2D texture;
        protected Rectangle sourceRect;
        protected Vector2 position;
        protected Color color;
        protected float rotation;
        protected float scale;
        protected Vector2 origin;
        protected SpriteEffects spriteEffect;
        protected Effect effect;

        public Sprite()
        {
            rotation = 0f;
            scale = 1f;
            color = Color.White;
        }

        public virtual void LoadContent(ContentManager content)
        {

        }
        public virtual void Update(GameTime gameTime)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            // If effect is active, we stop the current spritebatch in order to apply the effect to the spritebatch
            if(effect != null)
            {
                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, effect);
            }

            spriteBatch.Draw(texture, position, sourceRect, color, rotation, origin, scale, spriteEffect, .5f);

            // Ends the spritebatch with effect active and resets it back to original settings
            if (effect != null)
            {
                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null);
            }
        }
    }
}
