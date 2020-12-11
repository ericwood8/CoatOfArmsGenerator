using System.ComponentModel;

namespace CoatOfArmsCore
{
    public enum OpacityEnum
    {
        [Description("100%")] // 100% opacity is opaque (a.k.a. solid)
        Solid = 255, // 1 * 255 

        [Description("75%")]
        Solid75 = 191, // .75 * 255

        [Description("50%")]
        Solid50 = 127, // .5 * 255

        [Description("25%")]
        Solid25 = 64,  // .25 * 255

        [Description("10%")] // almost fully transparent
        Solid10 = 25,  // .10 * 255 
    }
}
