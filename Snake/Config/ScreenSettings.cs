using Microsoft.Xna.Framework;

namespace Snake.Config
{
    public class ScreenSettings
    {
        private float gameWidth;
        private float gameHeight;

        public Rectangle ScreenBounds;

        public ScreenSettings()
        {
            gameWidth = 960;
            gameHeight = 540;

            ScreenBounds = new Rectangle(0, 0, 960, 540);
        }
    }
}
