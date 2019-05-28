using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using waddle.GF;
using waddle.Grid;

namespace waddle {
    public class InGameScene : Scene {
        public override void Start() {
            base.Start();

            var camMover = new CamMover { camSpeed = 300 };
            baseLayer.cam.entity.AddComponent(camMover);

            var grid = new Entity("grid");
            grid.AddComponent(new GridSystem { Width = 10, Height = 10 });
            baseLayer.AddEntity(grid);

            var logger = new Entity("logger");
            logger.AddComponent(new Logger());
        }
    }
}
