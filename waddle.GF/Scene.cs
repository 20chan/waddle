using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

using waddle.GF.Components;

namespace waddle.GF {
    public abstract class Scene {
        public Time Time { get; private set; }
        public Input Input { get; private set; }

        private List<SceneLayer> _layers;
        protected SceneLayer baseLayer;

        public Scene() {
            _layers = new List<SceneLayer>();
            Time = new Time();
            Input = new Input();
            baseLayer = AddLayer();
        }

        public virtual void Start() {
        }

        public virtual void Update(GameTime gameTime) {
            foreach (var layer in _layers) {
                layer.Update();
            }

            Time.Update(gameTime);
            Input.Update();
        }

        public void Draw(GraphicsDevice gd, SpriteBatch sb) {
            foreach (var layer in _layers) {
                layer.Draw(gd, sb);
            }
        }

        public SceneLayer AddLayer() {
            var layer = new SceneLayer(this);
            _layers.Add(layer);
            return layer;
        }
    }
}
