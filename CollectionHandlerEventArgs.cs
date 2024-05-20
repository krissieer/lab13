using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    public class CollectionHandlerEventArgs: EventArgs
    {
        public string TypeChange { get; set; }
        public object ChangedObject { get; set; }

        public CollectionHandlerEventArgs(string typeChange, object changedObject)
        {
            TypeChange = typeChange;
            ChangedObject = changedObject;
        }
    }
}
