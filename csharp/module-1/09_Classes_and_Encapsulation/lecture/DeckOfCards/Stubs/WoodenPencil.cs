using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DeckOfCards.Stubs
{
    // <summary>
    // NAMESPACE definition:
    // Uppercase and aligned with a module or general purpose it provides. 
    // separated by periods like techElevator.Classes


    // CLASS DECLARATION
    // naming convention: singular and PascalCase


    public class WoodenPencil
    {
        /* summary:
         * CLASS VARIABLES AND PROPERTIES:
         * Static modifier, or const (implicit statistic).
         * may be public or private.
         * often const, byt not required.
         * 
         * All wooden pencils have a "fixed" set of default values for length, shape, hardness, and color. external code should be ableto ask
         * WoodenPencil for these defaults.
         * 
         * All wooden pencils have a min. length below which they are considered a "stub" and shoudl be discarded.
         * 
         * All wooden pencilshave a minimum sharpnes below which they are too dull and need sharpening.
         * 
         * Note: These values belong to "ALL" wooden pencils, and thus belong tothe class of WoodenPencil, hence the static modifier
         * explicitly written or implied by 'const'..
    */
        // all of this is data we care about. it's all shared between all pencils.
        // public means everyone can access this, including other classes and methods. *can* be changed unless we add "const"
        // static = shared among all members of a class. 
        // readonly = cannot be altered outside of the class. can't change once set. 
        // static + readonly ends up very similar to a constant.

        public const double DefaultLength = 8.0; //default value as referenced above.
        public const int DefaultShape = 2;
        public const string DefaultHardness = "HB";
        public static readonly Color DefaultColor = Color.Yellow;    // color can't be a const b/c color is coming from the system.drawing at top. 
        public const double DefaultStubLength = 2.0;  
        public const double DefaultMaxDullness = 0.3;

        private static double stubLength = DefaultStubLength; //when a pencil is considered a stub, in inches.

        public double Length { get; set; }

    }
}
