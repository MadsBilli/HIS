using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace HIS.Common
{
    public class EnumHelper
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (System.ComponentModel.DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(System.ComponentModel.DescriptionAttribute),
                false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static object enumValueOf(string Description, Type enumType)
        {
            string[] names = Enum.GetNames(enumType);
            foreach (string name in names)
            {
                if (stringValueOf((Enum)Enum.Parse(enumType, name)).Equals(Description))
                {
                    return Enum.Parse(enumType, name);

                }
            }

            throw new ArgumentException("The string is not a description or value of the specified enum.");
        }

        public static string stringValueOf(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        /// <summary>
        /// Generic method to return an enum based from ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T GetEnum<T>(int id) where T : struct
        {
            Enum retEnumValue = null;

            foreach (Enum e in Enum.GetValues(typeof(T)))
            {
                if (e.GetHashCode() == id)
                {
                    retEnumValue = e;
                    break;
                }
            }

            if (retEnumValue == null)
            {
                return Activator.CreateInstance<T>();
            }

            return (T)(Enum.Parse(typeof(T), retEnumValue.ToString(), true));
        }

        /// <summary>
        /// Generic method to return an enum based from code
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <returns></returns>
        public static T GetEnum<T>(string code) where T : struct
        {
            Enum retEnumValue = null;

            foreach (Enum e in Enum.GetValues(typeof(T)))
            {
                if (e.ToString() == code)
                {
                    retEnumValue = e;
                    break;
                }
            }

            if (retEnumValue == null)
            {
                return Activator.CreateInstance<T>();
            }

            return (T)(Enum.Parse(typeof(T), retEnumValue.ToString(), true));
        }

        /// <summary>
        /// Generic method to return an enum based from description
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <returns></returns>
        public static T GetEnumByDescription<T>(string description) where T : struct
        {
            Enum retEnumValue = null;

            foreach (Enum e in Enum.GetValues(typeof(T)))
            {
                MemberInfo[] memInfo = e.GetType().GetMember(e.ToString());
                if (memInfo != null && memInfo.Length > 0)
                {
                    object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (attrs != null && attrs.Length > 0 && ((DescriptionAttribute)attrs[0]).Description == description)
                    {
                        retEnumValue = e;
                        break;
                    }
                }
            }

            if (retEnumValue == null)
            {
                return Activator.CreateInstance<T>();
            }

            return (T)(Enum.Parse(typeof(T), retEnumValue.ToString(), true));
        }
    }
}
