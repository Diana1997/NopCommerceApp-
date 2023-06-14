using System.Collections.Generic;
using System.Dynamic;

namespace Nop.Plugins.FocusPoint.SLSyncPortal.Models
{
    public class DynamicFormData : DynamicObject
    {
        private Dictionary<string, object> properties = new Dictionary<string, object>();

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            properties[binder.Name] = value;
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return properties.TryGetValue(binder.Name, out result);
        }
    }

}