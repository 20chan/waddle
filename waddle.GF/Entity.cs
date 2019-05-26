using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace waddle.GF {
    public sealed class Entity {
        public string Name;
        public Transform Transform;

        private List<Component> _components;
        private Queue<Component> _notStartedComponents;

        public Scene Scene;

        public Entity(string name) {
            Name = name;
            _components = new List<Component>();
            _notStartedComponents = new Queue<Component>(capacity: 8);
            Transform = new Transform();
        }

        public void Update() {
            CallComponentStarts();

            foreach (var comp in _components) {
                comp.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach (var comp in _components) {
                comp.Draw(spriteBatch);
            }
        }

        private void CallComponentStarts() {
            for (int i = 0; i < _notStartedComponents.Count; i++) {
                var comp = _notStartedComponents.Dequeue();
                if (_components.Contains(comp)) {
                    // 컴포넌트가 추가되자마자 제거되면 Start를 불러주면 안된다
                    comp.Start();
                }
            }
        }

        public void AddComponent(Component comp) {
            if (comp.InEntity) {
                throw new System.Exception("Component can't be added to two or more entities");
            }

            _components.Add(comp);
            _notStartedComponents.Enqueue(comp);

            comp.entity = this;
            comp.InEntity = true;
        }

        public void RemoveComponent(Component comp) {
            _components.Remove(comp);

            comp.entity = null;
            comp.InEntity = false;
        }

        public Component GetComponent<T>() where T : Component {
            return GetComponents<T>().First();
        }

        public IEnumerable<Component> GetComponents<T>() where T : Component {
            return _components.OfType<T>();
        }
    }
}
