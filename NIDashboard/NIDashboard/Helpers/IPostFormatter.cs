using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIDashboard.Helpers
{
    public interface IPostFormatter
    {
        string FormatContent(string postContent);
    }
}
