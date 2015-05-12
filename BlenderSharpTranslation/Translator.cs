using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BlenderSharpTranslation
{
    public static class Translator
    {
        public static void Translate(Assembly assembly)
        {
            var types = assembly.GetTypes().Where(t => t.GetCustomAttributes<FuGUISidePanel>().Any());

            foreach (var type in types)
            {
                Console.WriteLine(type.Name);

                var properties = type.GetProperties().Where(p => p.GetCustomAttributes<FuGUIIntInput>().Any());

                foreach (var property in properties)
                {
                    var bCode = "bpy.props.IntProperty(";
                    var bAttrib = new List<string>();

                    Console.WriteLine("\t" + property.Name);

                    var attributes = property.GetCustomAttributes(true);
                    foreach (var attribute in attributes)
                    {
                        var fuAttribute = attribute as FuGUIIntInput;

                        Console.WriteLine("\t\tName: " + fuAttribute.Name);
                        Console.WriteLine("\t\tDefault: " + fuAttribute.Default);

                        if (fuAttribute.Name != null)
                        {
                            bAttrib.Add("name=\"" + fuAttribute.Name + "\"");
                        }
                        else
                        {
                            bAttrib.Add("name=\"" + property.Name + "\"");
                        }
                        if (fuAttribute.Default != 0)
                        {
                            bAttrib.Add("default=" + fuAttribute.Default);
                        }
                    }
                    bCode += String.Join(", ", bAttrib) + ")";

                    Console.WriteLine("\nBlender: " + bCode + "\n\n");
                }
            }
        }
    }
}
