using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Diagnostics;
using SystemDiagnosticsConfig;
using System.Linq.Expressions;

namespace KtaLoggingConfig
{
    public class KtaConfig : ConfigFile
    {
        //<unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
        //<container>
        //<!--KTA Logging - uncomment the below tag to enable logging of method calls-->
        //<!--<extension type = "Agility.Server.Common.Logging.LogMethodRegistration, Agility.Server.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=d86c87abe4a71948" /> -->

        private XNamespace uns=XNamespace.Get("http://schemas.microsoft.com/practices/2010/unity");

        public KtaConfig(string file) : base(file)
        {

        }

        public bool UnityLoggingEnabled
        {
            get
            {
                return Extension(false) != null;
            }
            set
            {
                if (value)
                {
                    var x = Extension(true);
                }
                else
                {
                    var ex = Extension(false);
                    if (ex != null)
                    {
                        ex.CommentOut();
                    }
                }
            }
        }

        private XElement Extension(bool create)
        {
            var u = UnityContainer;
            if (u == null) return null;

            var ex = u.Elements(uns + "extension").Where(x => x.Attributes().Where(at => at.Name == "type" && at.Value.Contains("LogMethod")).FirstOrDefault() != null).FirstOrDefault();
            if (ex != null) return ex;
            
            if (!create) return null;

            u.GetDescendantsCommentedOut(uns + "extension").FirstOrDefault()?.TryUncomment(out ex);
            if (ex != null) return ex;

            ex = new XElement(uns + "extension", new XAttribute("type", "Agility.Server.Common.Logging.LogMethodRegistration, Agility.Server.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=d86c87abe4a71948"));
            //ex = new XElement("extension", new XAttribute("type", "Agility.Server.Common.Logging.LogMethodWithIORegistration, Agility.Server.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=d86c87abe4a71948"));
            u.AddFirst(ex);
            return ex;
        }

        private XElement UnityContainer
        {
            get
            {
                return XDoc.Root?.Elements(uns + "unity").FirstOrDefault()?.Elements(uns + "container").FirstOrDefault();
            }
        }
    }
}
