using System.Collections.Generic;

/*
 * Tuwaiq .NET Bootcamp
 * 
 * Authors
 * 
 *  Younes Alturkey
 *  Abdulrahman Bin Maneea
 *  Abdullah Albagshi
 *  Ibrahim Alobaysi
 */

namespace JSONParser
{
    public class JArray : Value
    {
        public List<Value> Items = new List<Value>();
        public override string ToString()
        {
            return $"[{string.Join(", ", Items)}]";
        }

        public override JSONMemberType getType()
        {
            return JSONMemberType.Array;
        }

        public override string Indent(uint indentation = 0)
        {
            string ret = "[\n";
            foreach (var item in this.Items)
            {
                for (uint i = 0; i <= indentation+1; i++) ret += '\t';
                ret += $"{item.Indent(indentation+1)},\n";
            }
            if (ret.Length > 2)
            {
                ret = ret.Substring(0, ret.Length - 2) + "\n";
            }
            for (uint i = 0; i < indentation + 1; i++) ret += '\t';
            return ret + "]";
        }
    }

}