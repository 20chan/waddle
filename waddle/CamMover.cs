using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using waddle.GF;

namespace waddle {
    public class CamMover : Component {
        public float camSpeed = 1f;

        public override void Update() {
            base.Update();

            var deltaPos = new Vector2();

            if (Input.IsKeyPress(Keys.Left)) {
                deltaPos.X -= camSpeed;
            }
            if (Input.IsKeyPress(Keys.Right)) {
                deltaPos.X += camSpeed;
            }
            if (Input.IsKeyPress(Keys.Up)) {
                deltaPos.Y -= camSpeed;
            }
            if (Input.IsKeyPress(Keys.Down)) {
                deltaPos.Y += camSpeed;
            }

            deltaPos *= Time.DeltaTime;

            Transform.Position += deltaPos;
        }
    }
}
