using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector.Advanced;
using System.Reflection;
using System.ComponentModel.Composition;

namespace AgileWays.ThunderDome.Dapper.Attributes
{
    class ImportPropertySelectionBehavior : IPropertySelectionBehavior
    {
        public bool SelectProperty(Type type, PropertyInfo prop)
        {
            return prop.GetCustomAttributes(typeof(ImportAttribute)).Any();
        }
    }
}