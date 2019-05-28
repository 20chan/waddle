using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using waddle.GF;

namespace waddle.Grid {
    public class GridCell : Component {
        public readonly GridSystem gridSystem;

        public readonly int X, Y;

        public GridCell(GridSystem system, int x, int y) {
            gridSystem = system;
            X = x;
            Y = y;
        }

        public override void Draw(SpriteBatch sb) {
            base.Draw(sb);

            var width = gridSystem.CellWidthHalf;
            var height = gridSystem.CellHeightHalf;

            var x = gridSystem.Origin.X + (Y - X) * width;
            var y = gridSystem.Origin.Y + (X + Y) * height;

            sb.DrawLine(x, y, x - width, y + height, Color.White, 2);
            sb.DrawLine(x, y, x + width, y + height, Color.Yellow, 2);
            sb.DrawLine(x, y + height * 2, x - width, y + height, Color.Green, 2);
            sb.DrawLine(x, y + height * 2, x + width, y + height, Color.Blue, 2);
        }
    }
}
