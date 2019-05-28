using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using waddle.GF;

namespace waddle.Grid {
    public class GridSystem : Component {
        public int Width, Height;

        public float CellWidth = 100;
        public float CellHeight = 60;

        public float CellWidthHalf = 50;
        public float CellHeightHalf = 30;

        public Vector2 Origin;

        public override void Start() {
            base.Start();

            for (int y = 0; y < Height; y++) {
                for (int x = 0; x < Width; x++) {
                    var cell = new GridCell(this, x, y);
                    entity.AddComponent(cell);
                }
            }
        }
    }
}
