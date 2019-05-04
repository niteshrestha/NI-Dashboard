using System;

namespace NIDashboard.Helpers
{
    public class PostFormatter : IPostFormatter
    {
        public string FormatContent(string postContent)
        {
            return postContent.Replace(Environment.NewLine, "<br/>");
        }
    }
}
