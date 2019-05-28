using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace waddle.GF {
    public static class SpriteBatchUIExtensions {
        private static Texture2D dummy;

        internal static void Init(GraphicsDevice gd) {
            dummy = new Texture2D(gd, 1, 1);
            dummy.SetData(new[] { Color.White });
        }

        public static void DrawLine(this SpriteBatch sb, Vector2 p1, Vector2 p2, Color color, float border = 1f) {
            var angle = (float)Math.Atan2(p2.Y - p1.Y, p2.X - p1.X);
            var length = Vector2.Distance(p1, p2);
            var scale = new Vector2(length, border);
            var offset = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * border * .5f;
            var fromPos = p1 - offset;
            sb.Draw(dummy, fromPos, null, color, angle, Vector2.Zero, scale, SpriteEffects.None, 0);
        }

        public static void DrawLine(this SpriteBatch sb, float x1, float y1, float x2, float y2, Color color, float border = 1f) {
            DrawLine(sb, new Vector2(x1, y1), new Vector2(x2, y2), color, border);
        }

        public static void DrawRectangle(this SpriteBatch sb, Rectangle rect, Color color, int border = 1) {
            // TODO: border considered draw logic
            sb.Draw(dummy, new Rectangle(rect.X, rect.Y, border, rect.Height + border), color);
            sb.Draw(dummy, new Rectangle(rect.X, rect.Y, rect.Width + border, border), color);
            sb.Draw(dummy, new Rectangle(rect.X + rect.Width, rect.Y, border, rect.Height + border), color);
            sb.Draw(dummy, new Rectangle(rect.X, rect.Y + rect.Height, rect.Width + border, border), color);
        }

        public static void FillRectangle(this SpriteBatch sb, Rectangle rect, Color color) {
            sb.Draw(dummy, rect, color);
        }

        public static Rectangle DrawString(this SpriteBatch sb, SpriteFont font, string text, Alignment align, Vector2 pos, Color color, float rotation = 0) {
            var bound = new Rectangle(pos.ToPoint(), font.MeasureString(text).ToPoint());
            DrawString(sb, font, text, align, bound, color, rotation);
            return bound;
        }

        public static void DrawString(this SpriteBatch sb, SpriteFont font, string text, Alignment align, Rectangle bound, Color color, float rotation = 0) {
            Vector2 size = font.MeasureString(text);
            Point pos = bound.Center;
            Vector2 origin = size * 0.5f;

            if (align.HasFlag(Alignment.Left))
                origin.X += bound.Width / 2 - size.X / 2;

            if (align.HasFlag(Alignment.Right))
                origin.X -= bound.Width / 2 - size.X / 2;

            if (align.HasFlag(Alignment.Top))
                origin.Y += bound.Height / 2 - size.Y / 2;

            if (align.HasFlag(Alignment.Bottom))
                origin.Y -= bound.Height / 2 - size.Y / 2;

            sb.DrawString(font, text, new Vector2(pos.X, pos.Y), color, rotation, origin, 1, SpriteEffects.None, 0);
        }
    }
}
