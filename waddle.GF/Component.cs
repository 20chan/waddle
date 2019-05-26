using Microsoft.Xna.Framework.Graphics;
using waddle.GF.Components;

namespace waddle.GF {
    public abstract class Component {
        internal bool InEntity = false;
        internal Entity entity;

        protected Input Input => entity.Scene.Input;
        protected Time Time => entity.Scene.Time;

        public Transform Transform => entity.Transform;

        public virtual void Start() {
        }

        public virtual void Update() {
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
        }
    }
}
