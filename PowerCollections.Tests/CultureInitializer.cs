using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCollections.Tests
{
    [TestClass]
    public class CultureInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
        }
    }
}
