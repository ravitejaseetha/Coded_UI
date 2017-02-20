using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class ContainerAccess
    {
        private ComponentContainer compContainer;

        private List<IContainerPlugin> Plugins
        {
            get
            {
                if (compContainer == null)
                {
                    compContainer = new ComponentContainer();
                }

                compContainer.AssembleComponents();
                return compContainer.GetObjects();
            }
        }


        public T GetPlugin<T>() where T : IContainerPlugin
        {
            foreach (IContainerPlugin plugin in Plugins)
            {
                if (plugin.GetType().Equals(typeof(T)))
                {
                    return (T)plugin;
                }
            }

            return default(T);
        }

    }
}
