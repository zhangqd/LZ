using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLTWarter.Data
{
    interface IIdentifiable
    {
        String QueryId
        {
            get;
        }

        String CurrentQueryVersion
        {
            get;
        }
    }
}
