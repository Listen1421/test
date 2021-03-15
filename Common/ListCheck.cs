using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ListCheck
    {
        public static bool CheckList<T>(IList<T> ts)
        {
            if (ts.Count > 0 && ts != null)
                return true;
            else
                return false;
        }
    }
}
