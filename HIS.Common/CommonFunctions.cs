using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace HIS.Common
{
    public static class CommonFunctions
    {
        public static decimal FormatDecimal(decimal value)
        {
            return Math.Round(value, Constants.NO_OF_DECIMALS);
        }

        public static DataTable CopyListToDataTable<T>(this IEnumerable<T> source)
        {
            return new ObjectShredder<T>().Shred(source, null, null);
        }

        public static T Cast<T>(this Object myobj)
        {
            Type objectType = myobj.GetType();
            Type target = typeof(T);
            var x = Activator.CreateInstance(target, false);
            var z = from source in objectType.GetMembers().ToList() where source.MemberType == MemberTypes.Property select source;
            var d = from source in target.GetMembers().ToList() where source.MemberType == MemberTypes.Property select source;
            List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name).ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                value = myobj.GetType().GetProperty(memberInfo.Name).GetValue(myobj, null);

                propertyInfo.SetValue(x, value, null);
            }
            return (T)x;
        }

        public static int ConvertInt(string strVal)
        {
            try
            {
                return Convert.ToInt32(strVal);
            }
            catch
            {
                return 0;
            }
        }
    }
}
