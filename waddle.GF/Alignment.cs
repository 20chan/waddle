using System;

namespace waddle.GF {
    [Flags]
    public enum Alignment {
        Center = 0 << 0,
        Left = 0 << 1,
        Right = 0 << 2,
        Top = 0 << 3,
        Bottom = 0 << 4,
    }
}
