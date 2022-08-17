using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace TestTransaction
{
    public static class Helper
    {
        public static bool GetParsedValue<T>(string value, Func<string, T> parse, out T result)
        where T : struct
        {
            result = default(T);
            try
            {
                result = parse(value);
                return true;
            }
            catch { }
            return false;
        }
    }
}