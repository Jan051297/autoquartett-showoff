﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.QuartetsProperties
{
    public enum PropertyResult
    {
        Invalid,
        Disabled,

        Lower,
        Equal,
        Higher
    }

    public abstract class IProperty
    {
        // GetName
        // Returns name of Property
        public abstract string GetName();

        // CheckValueType
        // Checks given object's type and converts it, if neccessary
        // Returns null if it cannot be converted
        public abstract object CheckValueType(object obj);

        // ParseValueType
        // Checks given string and tries to convert it to correct
        // type
        // Returns null if it unable to convert/parse or is invalid
        public abstract object ParseValueType(string str);

        // Compare
        // Compares given values and returns result
        public abstract PropertyResult Compare(object a, object b);

        // GetWinningPropertyResult
        // Returns result which determines winning
        public abstract PropertyResult GetWinningPropertyResult();
    }

}
