using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Snake.Config;

namespace Snake
{
    public class GameManager
    {
        private GraphicsDevice graphics;
        private SpriteBatch spriteBatch;

        private ScreenSettings screenSettings;
        private InputMananger inputManager;

        private RenderTarget2D screenTarget;


        public GameManager(GraphicsDevice graphics, SpriteBatch spriteBatch)
        {
            this.graphics = graphics;
            this.spriteBatch = spriteBatch;

            screenSettings = new ScreenSettings();
            inputManager = new InputMananger();
        }

        public void LoadContent(ContentManager content)
        {
            screenTarget = new RenderTarget2D(graphics, screenSettings.ScreenBounds.Width, screenSettings.ScreenBounds.Height);
        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }
        public void DrawToTarget()
        {

        }
    }
}
