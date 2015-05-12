using System;

namespace BlenderSharpTranslation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FuGUISidePanel : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class FuGUIIntInput : Attribute
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Default { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
