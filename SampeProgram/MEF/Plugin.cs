using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MEF
{
    public class Plugin
    {
        [ImportMany]
        public IEnumerable<IControl> Plugins { get; set; }

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
               
            }
            catch (Exception ex)
            {
                
            }

        }

        public List<IControl> GetObjects()
        {
            //return Plugins;//.ToList<IContainerPlugin>();
            return Plugins.ToList<IControl>();
        }
    }
}
