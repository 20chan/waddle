using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using waddle.GF;

namespace waddle {
    public class Logger : Component {
        public SpriteFont font;
        public Alignment align;
        public string Text;

        public override void Draw(SpriteBatch spriteBatch) {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(font, Text, Alignment.Top | Alignment.Right, Transform.Position, Color.White);
        }
    }
}
