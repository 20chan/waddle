using Microsoft.Xna.Framework;

namespace waddle.GF {
    public class Time {
        public float DeltaTime { get; private set; }

        public void Update(GameTime gameTime) {
            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
