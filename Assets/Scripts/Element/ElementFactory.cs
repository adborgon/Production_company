using System;
using System.Collections.Generic;

namespace Element
{
    internal static class ElementFactory

    {
        public static Element Create<T>(int id) where T : Element, new()
        {
            Element element = new T();
            element.Init(id);
            return element;
        }
    }
}