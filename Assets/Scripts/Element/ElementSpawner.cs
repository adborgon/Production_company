using System;
using System.Collections.Generic;
using UnityEngine;

namespace Element
{
    public class ElementSpawner
    {
        /*public static List<T> SpawnElements<T>(int _quantity) where T : Element, new()
        {
            List<T> list = new List<T>();
            for (int i = 0; i < _quantity; i++)
            {
                list.Add((T)ElementFactory.Create<T>(i + 1));
            }
            return list;
        }*/
        public static List<Element> SpawnElements<T>(int _quantity) where T : Element, new()
        {
            List<Element> list = new List<Element>();
            for (int i = 0; i < _quantity; i++)
            {
                list.Add((T)ElementFactory.Create<T>(i + 1));
            }
            return list;
        }
    }
}