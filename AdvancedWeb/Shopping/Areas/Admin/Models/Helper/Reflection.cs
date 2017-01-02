using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Areas.Admin.Models.Helper
{
    public class Reflection
    {
        public static List<Type> GetController(string namespaces)
        {
            List<Type> ls = new List<Type>();
            Assembly asm = Assembly.GetExecutingAssembly();

            IEnumerable<Type> types = asm.GetTypes()
                .Where(type => typeof(Controller).IsAssignableFrom(type) && type.Namespace.Contains(namespaces))
                .OrderBy(x => x.Name);
            return types.ToList();

        }

        public static List<String> GetAction(Type controller)
        {
            List<string> listAction = new List<string>();
            IEnumerable<MemberInfo> mems = controller.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)
                .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true)
                    .Any())
                    .OrderBy(x => x.Name);
            foreach (MemberInfo method in mems)
            {
                if (method.ReflectedType.IsPublic && !method.IsDefined(typeof(NonActionAttribute)))
                {
                    listAction.Add(method.Name.ToString());
                }
            }
            return listAction;
        }

        public static List<Type> GetSubClasses<T>()
        {
            return Assembly.GetCallingAssembly().GetTypes()
                .Where(type => type.IsSubclassOf(typeof(T)))
                .ToList();
        }

        public static List<String> GetControllerNames()
        {
            List<String> controllerNames = new List<String>();
            GetSubClasses<Controller>().ForEach(
                type => controllerNames.Add(type.Name));
            return controllerNames;
        }

        public static List<String> GetActionNames(String controllerName)
        {
            var types =
                from a in AppDomain.CurrentDomain.GetAssemblies()
                from t in a.GetTypes()
                where typeof(IController).IsAssignableFrom(t) &&
                        String.Equals(controllerName, t.Name, StringComparison.OrdinalIgnoreCase)
                select t;

            var controllerType = types.FirstOrDefault();

            if (controllerType == null)
            {
                return Enumerable.Empty<string>().ToList();
            }
            return new ReflectedControllerDescriptor(controllerType)
                .GetCanonicalActions().Select(x => x.ActionName)
                .ToList();
        }
    }
}