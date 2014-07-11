using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;

namespace MvcPlugins.Main
{
    public class PluginAreaBootstrapper
    {
        public static readonly List<Assembly> PluginAssemblies = new List<Assembly>();

        public static List<string> PluginNames()
        {
            return PluginAssemblies.Select(
                pluginAssembly => pluginAssembly.GetName().Name)
                .ToList();
        }

        public static void Init()
        {
            var pluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Areas");
            var fullPluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Areas\Temp");

            if (!Directory.Exists(fullPluginPath))
                Directory.CreateDirectory(fullPluginPath);

            if (Directory.Exists(pluginPath))
            {
                foreach (var file in Directory.GetFiles(pluginPath, "*.dll"))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    string fileName = fullPluginPath + @"\" + fileInfo.Name;

                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }

                    File.Copy(file, fileName, true);
                }
            }

            if (Directory.Exists(fullPluginPath))
            {
                foreach (var file in Directory.EnumerateFiles(fullPluginPath, "*.dll"))
                    PluginAssemblies.Add(Assembly.LoadFile(file));

                PluginAssemblies.ForEach(BuildManager.AddReferencedAssembly);

                // Add assembly handler for strongly-typed view models
                AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;
            }
        }

        private static Assembly AssemblyResolve(object sender, ResolveEventArgs resolveArgs)
        {
            var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            // Check we don't already have the assembly loaded
            foreach (var assembly in currentAssemblies)
            {
                if (assembly.FullName == resolveArgs.Name || assembly.GetName().Name == resolveArgs.Name)
                {
                    return assembly;
                }
            }

            return null;
        }
    }
}