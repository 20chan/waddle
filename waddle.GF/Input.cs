using Microsoft.Xna.Framework.Input;
using static Microsoft.Xna.Framework.Input.ButtonState;

namespace waddle.GF {
    public class Input {
        KeyboardState _curKey, _prevKey;
        MouseState _curMouse, _prevMouse;

        public void Update() {
            _prevKey = _curKey;
            _prevMouse = _curMouse;
            _curKey = Keyboard.GetState();
            _curMouse = Mouse.GetState();
        }

        public bool IsKeyDown(Keys key) {
            return _curKey.IsKeyDown(key) && _prevKey.IsKeyUp(key);
        }

        public bool IsKeyUp(Keys key) {
            return _curKey.IsKeyUp(key) && _prevKey.IsKeyDown(key);
        }

        public bool IsKeyPress(Keys key) {
            return _curKey.IsKeyDown(key);
        }

        public bool IsMouseLeftDown() {
            return _curMouse.LeftButton == Pressed && _prevMouse.LeftButton == Released;
        }

        public bool IsMouseLeftUp() {
            return _curMouse.LeftButton == Released && _prevMouse.LeftButton == Pressed;
        }

        public bool IsMouseLeftPress() {
            return _curMouse.LeftButton == Pressed;
        }

        public bool IsMouseRightDown() {
            return _curMouse.RightButton == Pressed && _prevMouse.RightButton == Released;
        }

        public bool IsMouseRightUp() {
            return _curMouse.RightButton == Released && _prevMouse.RightButton == Pressed;
        }

        public bool IsMouseRightPress() {
            return _curMouse.RightButton == Pressed;
        }

        public bool IsMouseMiddleDown() {
            return _curMouse.MiddleButton == Pressed && _prevMouse.MiddleButton == Released;
        }

        public bool IsMouseMiddleUp() {
            return _curMouse.MiddleButton == Released && _prevMouse.MiddleButton == Pressed;
        }

        public bool IsMouseMiddlePress() {
            return _curMouse.MiddleButton == Pressed;
        }

        public int ScrollValue => _curMouse.ScrollWheelValue;
    }
}
