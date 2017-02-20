using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class ComponentContainer
    {
        private static log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [ImportMany(typeof(IContainerPlugin))]
        public IEnumerable<IContainerPlugin> Plugins { get; set; }

        public ComponentContainer()
        {
            log4net.ThreadContext.Properties["myContext"] = "Logging from Framework Class";
            //Logger.Debug("Inside Framework Constructor!");

            Logger.Debug("Inside Framework Constructor!");


        }

        public void AssembleComponents()
        {
            AssemblyCatalog sdc = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var test = sdc.Parts;
            try
            {
                //AssemblyCatalog catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
                var catalog = new AggregateCatalog();
                //catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));                
                //catalog.Catalogs.Add(new DirectoryCatalog("."));
                catalog.Catalogs.Add(sdc);
                var container = new CompositionContainer(catalog);
                container.ComposeParts(this);
                foreach (ComposablePartDefinition part in sdc)
                {
                    Logger.Info(part.ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Unable to assemble all logins error: {0}", ex);
            }

        }

        public List<IContainerPlugin> GetObjects()
        {
            //return Plugins;//.ToList<IContainerPlugin>();
            return Plugins.ToList<IContainerPlugin>();
        }
    }

    public class SafeDirectoryCatalog : ComposablePartCatalog
    {
        private readonly AggregateCatalog _catalog;
        private static log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //protected static log4net.ILog Logger([CallerFilePath] string fileName = "") => log4net.LogManager.GetLogger(fileName);

        public SafeDirectoryCatalog()
        {
            log4net.ThreadContext.Properties["myContext"] = "Logging from Framework Class";
            Logger.Debug("Inside Directory Catalog Constructor!");
        }

        public SafeDirectoryCatalog(string directory)
        {
            var files = Directory.EnumerateFiles(directory, "*.dll", SearchOption.AllDirectories);

            _catalog = new AggregateCatalog();

            foreach (var file in files)
            {
                try
                {
                    var asmCat = new AssemblyCatalog(file);

                    //Force MEF to load the plugin and figure out if there are any exports
                    // good assemblies will not throw the RTLE exception and can be added to the catalog
                    if (asmCat.Parts.ToList().Count > 0)
                        _catalog.Catalogs.Add(asmCat);
                }
                catch (ReflectionTypeLoadException ex)
                {
                    Logger.Info(ex.LoaderExceptions.FirstOrDefault());
                }
                catch (BadImageFormatException ex)
                {
                    if (!ex.Message.Contains("AutoItX3.dll")) // Suppress logger if it relates to AutoItX3.dll, this will not load as it is a COM dll
                    {
                        Logger.Info(ex);
                    }
                }
            }
        }
        public override IQueryable<ComposablePartDefinition> Parts
        {
            get { return _catalog.Parts; }
        }
    }
}
