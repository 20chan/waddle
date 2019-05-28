using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace waddle.GF.Components {
    public class Camera : Component {
        public static Camera main;
        public Rectangle ViewRect { get; set; }

        Vector2 pos => Transform.Position;
        float rot => Transform.Rotation;
        Vector2 zoom => Transform.Scale;

        public Matrix CreateTransform() {
            return Matrix.CreateTranslation(-pos.X, -pos.Y, 0) *
                Matrix.CreateRotationZ(rot) *
                Matrix.CreateScale(zoom.X, zoom.Y, 1) *
                Matrix.CreateTranslation(ViewRect.Width / 2, ViewRect.Height / 2, 0);
        }
    }
}
