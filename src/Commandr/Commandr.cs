using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Commandr
{
    public class Commandr
    {
        protected IEnumerable<_Assembly> assemblies;

        public Commandr(IEnumerable<_Assembly> assemblies = null)
        {
            this.assemblies = assemblies ?? new _Assembly[] { Assembly.GetCallingAssembly() };
        }
    }
}
