using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Medical.Forms.Interfaces;

namespace Run.Implementation {
    public class WContainer : IContainerProvider {

        private static IWindsorContainer _container = new WindsorContainer(new XmlInterpreter("Components.config.xml"));

        public object GetComponentByKey(string key)
        {
            throw new NotImplementedException();
        }
    }
}
