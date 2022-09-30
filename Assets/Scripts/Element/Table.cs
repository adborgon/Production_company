using System;

namespace Element
{
    [Serializable]
    public class Table : Element
    {
        public override void Init(int id)
        {
            _id = "Table_" + id;
        }
    }
}