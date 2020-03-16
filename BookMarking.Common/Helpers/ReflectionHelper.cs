using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace BookMarking.Common.Helpers
{
    public static class ReflectionHelper
    {
        /// <summary>
        ///  获取Asp.Net Core项目所有程序集
        /// </summary>
        /// <returns></returns>
        public static Assembly[] GetAllAssembliesCoreWeb()
        {
            var list = new List<Assembly>();
            DependencyContext dependencyContext = DependencyContext.Default;
            IEnumerable<CompilationLibrary> libs = dependencyContext.CompileLibraries
                .Where(lib => !lib.Serviceable && lib.Type != "package" && lib.Name.StartsWith("igivu"));
            foreach (var lib in libs)
            {
                Assembly assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name));
                list.Add(assembly);
            }
            return list.ToArray();
        }
    }
}
