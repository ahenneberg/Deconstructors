/* Disclaimer: The examples and comments from this program are from
   C#7 in a Nutshell and are written for learning purposes only. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deconstructors
{
    /* C# 7 Introduces the deconstructor pattern. A deconstructor (also called a
     deconstructing method) acts as an approximate opposite to a constructor: Whereas
     a constructor typically takes a set of values (as parameters) and assigns them to
     fields, a deconstructor does the reverse and assigns fields back to a set of 
     variables. A deconstruction method must be called Deconstruct, and have one or more
     out paramaters, such as in the following class: */
     class Rectangle
    {
        public readonly float Width, Height;
        public Rectangle (float width, float height)
        {
            Width = width;
            Height = height;
        }
        public void Deconstruct (out float width, out float height)
        {
            width = Width;
            height = Height;
        }
    }

    class Program
    {
        static void Main()
        {
            // To call the deconstructor, we use the following special syntax:
            var rect = new Rectangle(3, 4);
            (float width, float height) = rect;         // Deconstruction
            Console.WriteLine(width + " " + height);    // 3 4
            /* The second line is the deconstructing call. It creates two local variables
             and then calls the Deconstruct method. Our deconstructing call is equivalent to: */
            float width, height; // COMPILER ERROR. ALREADY BEEN DEFINED.
            rect.Deconstruct(out width, out height);
            // Or:
            rect.Deconstruct(out var width, out var height);
            // Deconstucting calls allow implicit typing, so we could shorten our call to:
            (var width, var height) = rect;
            // Or simply:
            var (width, height) = rect;
            /* If the variables into which you're deconstructing are already defined, omit
             the types altogether: */
            float width, height;
            (width, height) = rect;
            /* This is called a deconstructing assignment. You can offer the caller a range
             of deconstruction options by overloading the Deconstruct method. */
        }
    }
}
