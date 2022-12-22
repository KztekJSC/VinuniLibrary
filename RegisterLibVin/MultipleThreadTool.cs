using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterLibVin
{
    public static class MultipleThreadTool
    {
        public static void InvokeControl(Control control, Action func)
        {
            control?.Invoke(func);
        }

        public static void InvokeControl(Dictionary<Control, Action> invokes)
        {
            foreach (var pair in invokes)
            {
                pair.Key?.Invoke(pair.Value);
            }
        }

    }
}
