using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Generator.GetSurprise(3);

            // Console.WriteLine(result);

            // Console.WriteLine(result.Id);

            Type type = result.GetType();
            // Type type = typeof(result); wrong!

            /* foreach (PropertyInfo propInfo in type.GetProperties())
            {
                Console.WriteLine(propInfo.Name + " = " + propInfo.GetValue(result));
            } */

            foreach (FieldInfo fInfo in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine(fInfo.Name + " = " + fInfo.GetValue(result));
                Console.WriteLine(fInfo.GetValue(result).GetType().Name);
                if (fInfo.GetValue(result).GetType().Name == "Int32" && fInfo.GetValue(result) == 0)
                {
                    fInfo.SetValue(result, 10);
                }
                Console.WriteLine(fInfo.Name + " = " + fInfo.GetValue(result));
                if (fInfo.GetValue(result).GetType().Name=="Action")
                {
                    Console.WriteLine("!!!");
                    ((Action)fInfo.GetValue(result)).Invoke();

                }
            }

            foreach (var m in type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance))
            {

                if (m.Name == "PrintPerson")
                {
                    m.Invoke(result, null);
                }
                //if (m.)
                //{

                //}

            }




        }
    }
}
