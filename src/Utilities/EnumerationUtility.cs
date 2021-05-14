using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class EnumerationUtility
    {
        private static List<LiteralContainer> LiteralContainers = new List<LiteralContainer>();
        private static object lockObj = new object();

        /// <summary>
        /// 得枚举的codesystem.
        /// </summary>
        /// <param name="t"></param>
        public static string Enumeration2Code<T>(this T t)
        {
            if (t == null)
            {
                return null;
            }

            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            var typeString = type.ToString();
            if (LiteralContainers.Count(c => c.Type == typeString) <= 0)
            {
                lock (lockObj)
                {
                    if (LiteralContainers.Count(c => c.Type == typeString) <= 0)
                    {
                        foreach (var field in type.GetFields())
                        {
                            var attr = field.GetCustomAttribute<LiteralAttribute>();
                            if (attr == null)
                                continue;

                            var value = field.GetValue(null);
                            LiteralContainers.Add(new LiteralContainer { 
                                Type = type.ToString(),
                                Key = value,
                                Value = attr.Value
                            });
                        }
                    }
                }
            }

            return LiteralContainers.FirstOrDefault(c => c.Type == typeString && c.Key.Equals(t))?.Value;
        }

        /// <summary>
        /// 从code得到枚举值.
        /// </summary>
        /// <param name="code"></param>
        public static T Code2Enumeration<T>(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return default;
            }

            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            var typeString = type.ToString();
            if (LiteralContainers.Count(c => c.Type == typeString) <= 0)
            {
                lock (lockObj)
                {
                    if (LiteralContainers.Count(c => c.Type == typeString) <= 0)
                    {
                        foreach (var field in type.GetFields())
                        {
                            var attr = field.GetCustomAttribute<LiteralAttribute>();
                            var value = field.GetValue(null);
                            LiteralContainers.Add(new LiteralContainer
                            {
                                Type = type.ToString(),
                                Key = value,
                                Value = attr.Value
                            });
                        }
                    }
                }
            }

            var item = LiteralContainers.FirstOrDefault(c => c.Type == typeString && c.Value == code);
            if (item.Key != null)
            {
                return (T)item.Key;
            }

            return default;
        }


        public class LiteralContainer
        {
            public string Type { get; set; }

            public object Key { get; set; }

            public string Value { get; set; }
        }
    }
}
