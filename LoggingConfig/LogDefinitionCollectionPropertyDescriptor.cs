using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemDiagnosticsConfig
{
    class LogDefinitionCollectionPropertyDescriptor : PropertyDescriptor
    {
        private LogDefinitionCollection collection = null;
        private int index = -1;

        public LogDefinitionCollectionPropertyDescriptor(LogDefinitionCollection coll, int idx) :
            base("#" + idx.ToString(), null)
        {
            this.collection = coll;
            this.index = idx;
        }

        public override AttributeCollection Attributes
        {
            get
            {
                return new AttributeCollection(null);
            }
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override Type ComponentType
        {
            get
            {
                return this.collection.GetType();
            }
        }

        public override string DisplayName
        {
            get
            {
                LogDefinition c = this.collection[index];
                return $"{c.Name} ({Path.GetFileName(c.Config.Filename)})";
            }
        }

        public override string Description
        {
            get
            {
                var c = this.collection[index];
                return $"{c.LogLocation} ({c.ListenerType})\nSources: {String.Join(", ",c.Listener.Sources().Select(x=>x.Name))}";
            }
        }

        public override object GetValue(object component)
        {
            return this.collection[index];
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override string Name
        {
            get { return "#" + index.ToString(); }
        }

        public override Type PropertyType
        {
            get { return this.collection[index].GetType(); }
        }

        public override void ResetValue(object component)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }

        public override void SetValue(object component, object value)
        {
            // this.collection[index] = value;
        }
    }
}
