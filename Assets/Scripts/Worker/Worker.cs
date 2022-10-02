using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Worker
{
    [Serializable]
    public class Worker
    {
        public string id { get; private set; }
        public int tableWaiting { get; private set; }
        public int workbenchWaiting { get; private set; }
        public int angryWaiting { get; private set; }

        public void Init(string id, int tableWaiting, int workbenchWaiting, int angryWaiting)
        {
            this.id = "Worker_" + id;
            this.tableWaiting = tableWaiting;
            this.workbenchWaiting = workbenchWaiting;
            this.angryWaiting = angryWaiting;
        }

        public static bool Equals(Worker obj1, Worker obj2)
        {
            if (obj1.id == obj2.id)
                return true;
            else
                return false;
        }

    }
}