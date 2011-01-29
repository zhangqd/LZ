using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;

namespace GLTWarter.Data
{
    /// <summary>
    /// This BackObject is to indicate the page return is actually coming from a back command
    /// </summary>
    public sealed class BackObject : BusinessEntity
    {
        public static bool IsReturnGenuine(ReturnEventArgs<GLTWarter.Data.BusinessEntity> e)
        {
            if (e.Result == null) return true;
            if (e.Result is BackObject) return false;
            return true;
        }
    }
}
