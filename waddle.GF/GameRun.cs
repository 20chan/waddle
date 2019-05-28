using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace waddle.GF {
    public sealed class GameRun : Game {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        Scene _currentScene;
        bool _sceneStartCalled = false;

        public GameRun(Scene scene) {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Resources.Init(Content);
             _currentScene = scene;

            IsFixedTimeStep = true;
            IsMouseVisible = true;
        }

        public void ChangeScene(Scene scene) {
            _currentScene = scene;
            _sceneStartCalled = false;
        }

        protected override void Initialize() {
            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteBatchUIExtensions.Init(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime) {
            if (!_sceneStartCalled) {
                _sceneStartCalled = true;
                _currentScene.Start();
            }
            _currentScene.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _currentScene.Draw(GraphicsDevice, _spriteBatch);

            //TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
