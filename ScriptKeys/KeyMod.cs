namespace ScriptKeys
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;

    public class KeyMod
    {
        public const int L_SHIFT = (1 << 0);
        public const int L_ALT = (1 << 1);
        public const int L_CONTROL = (1 << 2);
        public const int L_WIN = (1 << 3);

        public const int R_SHIFT = (1 << 4);
        public const int R_ALT = (1 << 5);
        public const int R_CONTROL = (1 << 6);
        public const int R_WIN = (1 << 7);

        public static string GetKeyAsText(int key)
        {
            var list = new List<string>(8);
            Keys k = (Keys)(key >> 8);
            int modifiers = key & 0xFF;

            if ((modifiers & KeyMod.L_SHIFT) > 0) list.Add("LSHIFT");
            if ((modifiers & KeyMod.L_ALT) > 0) list.Add("LALT");
            if ((modifiers & KeyMod.L_CONTROL) > 0) list.Add("LCONTROL");
            if ((modifiers & KeyMod.L_WIN) > 0) list.Add("LWIN");
            if ((modifiers & KeyMod.R_SHIFT) > 0) list.Add("RSHIFT");
            if ((modifiers & KeyMod.R_ALT) > 0) list.Add("RALT");
            if ((modifiers & KeyMod.R_CONTROL) > 0) list.Add("RCONTROL");
            if ((modifiers & KeyMod.R_WIN) > 0) list.Add("RWIN");

            string modifiersText = string.Join(" + ", list.ToArray());

            return string.Format("{0} + {1}", modifiersText, k.ToString());
        }
    }
}
