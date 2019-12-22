using System;
using System.Collections.Generic;
using System.Text;

namespace Mainframe.Data.DbServices
{
    public abstract class BaseDbService
    {
        protected readonly MainframeContext _mainframeContext;
        protected BaseDbService()
        {
            _mainframeContext = MainframeContext.Instance;
        }
    }
}
