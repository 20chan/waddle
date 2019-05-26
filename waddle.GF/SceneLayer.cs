using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using waddle.GF.Components;

namespace waddle.GF {
    public class SceneLayer {
        public Scene scene { get; private set; }

        public IReadOnlyList<Entity> Entities => _entities;
        private List<Entity> _entities;
        public Camera cam;

        public SceneLayer(Scene scene) {
            this.scene = scene;
            _entities = new List<Entity>();

            var camObj = new Entity("cam");
            cam = new Camera();
            camObj.AddComponent(cam);
            AddEntity(camObj);
        }
        public void AddEntity(Entity entity) {
            _entities.Add(entity);
            entity.Scene = scene;
        }

        public void Update() {
            foreach (var entity in Entities) {
                entity.Update();
            }
        }

        public void Draw(GraphicsDevice gd, SpriteBatch sb) {
            sb.Begin(transformMatrix: cam.CreateTransform());
            foreach (var entity in Entities) {
                entity.Draw(sb);
            }
            sb.End();
        }
    }
}
