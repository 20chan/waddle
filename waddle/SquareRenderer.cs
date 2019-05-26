using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using waddle.GF;

namespace waddle {
    public class SquareRenderer : Component {
        public int Size = 10;
        public override void Draw(SpriteBatch spriteBatch) {
            base.Draw(spriteBatch);
            
            var pos = Transform.Position;
            var rect = new Rectangle((int)pos.X - Size / 2, (int)pos.Y - Size / 2, Size, Size);
            spriteBatch.FillRectangle(rect, Color.Blue);
        }
    }
}
