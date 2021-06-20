using System;
using System.Reflection;

namespace TestUtils
{
    public static class ReflectionUtils
    {
        public static FieldInfo GetFieldInfo<T>(string fieldName,
            BindingFlags bindingFlags = BindingFlags.Default | BindingFlags.Instance | BindingFlags.NonPublic)
        {
            return typeof(T).GetField(fieldName, bindingFlags);
        }

        public static void SetFieldValue<T>(T obj, string fieldName, object value,
            BindingFlags bindingFlags = BindingFlags.Default | BindingFlags.Instance | BindingFlags.NonPublic)
        {
            GetFieldInfo<T>(fieldName, bindingFlags).SetValue(obj, value);
        }

        public static void SetStaticFieldValue<T>(string fieldName, object value,
            BindingFlags bindingFlags = BindingFlags.Default | BindingFlags.Static | BindingFlags.NonPublic)
        {
            GetFieldInfo<T>(fieldName, bindingFlags).SetValue(null, value);
        }

        public static object GetFieldValue<T>(T obj, string fieldName,
            BindingFlags bindingFlags = BindingFlags.Default | BindingFlags.Instance | BindingFlags.NonPublic)
        {
            return GetFieldInfo<T>(fieldName, bindingFlags).GetValue(obj);
        }

        public static void FireEvent<T>(T objectToInvokeOn, string eventToInvoke, params object[] eventParams)
        {
            MulticastDelegate eventDelagates = (MulticastDelegate) GetFieldValue(objectToInvokeOn, eventToInvoke);

            Delegate[] delegates = eventDelagates.GetInvocationList();

            foreach (Delegate delegation in delegates)
            {
                delegation.Method.Invoke(delegation.Target, eventParams);
            }
        }

        public static string ConvertPropertyNameToFieldName(string propertyName)
        {
            return $"<{propertyName}>k__BackingField";
        }
    }
}