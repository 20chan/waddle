using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using waddle.GF;

namespace waddle {
    public class CamMover : Component {
        public float camSpeed = 1f;

        public override void Update() {
            base.Update();

            var deltaPos = new Vector2();

            if (Input.IsMouseRightPress()) {
                deltaPos += -60 * Input.MouseDeltaPos.ToVector2();
            }

            deltaPos *= Time.DeltaTime;

            Transform.Position += deltaPos;
        }
    }
}
