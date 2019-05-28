using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using static Microsoft.Xna.Framework.Input.ButtonState;

namespace waddle.GF {
    public class Input {
        KeyboardState _curKey, _prevKey;
        MouseState _curMouse, _prevMouse;

        public Point PrevMousePos { get; private set; }
        public Point MousePos { get; private set; }
        public Point MouseDeltaPos { get; private set; }

        public Vector2 CamRelativeMousePos { get; private set; }
        public Vector2 CamRelativePrevMousePos { get; private set; }
        public Vector2 CamRelativeMouseDeltaPos { get; private set; }

        public void Update() {
            _prevKey = _curKey;
            _prevMouse = _curMouse;
            _curKey = Keyboard.GetState();
            _curMouse = Mouse.GetState();

            PrevMousePos = MousePos;
            MousePos = _curMouse.Position;
            MouseDeltaPos = MousePos - PrevMousePos;

            var camTransform = Components.Camera.main.CreateTransform();

            CamRelativePrevMousePos = CamRelativeMousePos;
            CamRelativeMousePos = Vector2.Transform(MousePos.ToVector2(), Matrix.Invert(camTransform));
            CamRelativeMouseDeltaPos = CamRelativeMousePos - CamRelativePrevMousePos;
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
