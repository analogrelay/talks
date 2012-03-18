using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuddy
{
    public static class DynamicRecordHelper
    {
        public static IEnumerable<dynamic> ToDynamicList(this IDataReader rdr)
        {
            string[] cols = Enumerable.Range(0, rdr.FieldCount).Select(i => rdr.GetName(i)).ToArray();
            while (rdr.Read()) {
                ExpandoObject row = new ExpandoObject();
                IDictionary<string, object> asDict = row as IDictionary<string, object>;
                for (int i = 0; i < cols.Length; i++)
                {
                    asDict.Add(cols[i], rdr.GetValue(i));
                }
                yield return row;
            }
        }
    }
}
