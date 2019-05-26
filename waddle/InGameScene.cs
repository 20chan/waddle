using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using waddle.GF;

namespace waddle {
    public class InGameScene : Scene {
        public override void Start() {
            base.Start();

            var camMover = new CamMover();
            baseLayer.cam.entity.AddComponent(camMover);

            var square = new Entity("square");
            square.AddComponent(new SquareRenderer { Size = 100 });
            baseLayer.AddEntity(square);

            var logger = new Entity("logger");
            logger.AddComponent(new Logger());
        }
    }
}
