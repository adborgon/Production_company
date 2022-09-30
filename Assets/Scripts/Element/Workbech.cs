using System;

namespace Element
{
    [Serializable]
    public class Workbech : Element
    {
        public override void Init(int id)
        {
            _id = "Workbech_" + id;
        }
    }
}