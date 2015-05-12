using System.Reflection;
using BlenderSharpTranslation;

namespace TestTranslation
{
    class Program
    {
        static void Main(string[] args)
        {
            Translator.Translate(Assembly.GetExecutingAssembly());
        }
    }

    [FuGUISidePanel]
    public class GuiPanel
    {
        [FuGUIIntInput(Name = "Magnit", Default = 2)]
        public int Magnitude { get; set; }

        [FuGUIIntInput(Name = "Step")]
        public int Steps { get; set; }

        [FuGUIIntInput]
        public int Anotherint { get; set; }

        public int NoAttrib { get; set; } 
    }
}
