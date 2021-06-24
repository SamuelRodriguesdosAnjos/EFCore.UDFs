using System;
using Microsoft.EntityFrameworkCore;

namespace EFCore.UDF.Functions
{
    public static class CustomFunctions
    {
        [DbFunction(name: "LEN", IsBuiltIn = true)]
        public static Int64 Len(string data)
        {
            throw new NotImplementedException();
        }
    }
}