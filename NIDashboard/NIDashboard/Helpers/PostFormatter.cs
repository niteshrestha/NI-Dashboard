﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIDashboard.Helpers
{
    public class PostFormatter : IPostFormatter
    {
        public string FormatContent(string postContent)
        {
            var postWithSpaces = TransformSpaces(postContent);
            return postWithSpaces;
        }

        private string TransformSpaces(string postContent)
        {
            return postContent.Replace(Environment.NewLine, "<br/>");
        }
    }
}
