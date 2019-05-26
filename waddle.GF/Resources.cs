using Microsoft.Xna.Framework.Content;

namespace waddle.GF {
    public static class Resources {
        static ContentManager _content;

        internal static void Init(ContentManager content) {
            _content = content;
        }

        public static T Load<T>(string path) {
            return _content.Load<T>(path);
        }
    }
}
