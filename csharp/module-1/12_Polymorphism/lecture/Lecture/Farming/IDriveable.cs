using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public  interface IDriveable
    {
        void Drive(); //don't care that it has a name and makes a sound, but we do care that we can drive it, so we want it to have ->
        //  a drive method. 
    }
}
