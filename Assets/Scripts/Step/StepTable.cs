using Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;

namespace Step
{
    public class StepTable : Step
    {
        public override void Start(Worker.Worker worker)
        {
            _waitTimer = worker.tableWaiting;
            elementReady = (Element.Table)Element.ElementWareHouse.Instance.isAElemenReady<Element.Table>();
            if (elementReady == null)
            {
                OnStepFailed?.Invoke();
                return;
            }
            Debug.Log($"{worker.id} is running {elementReady.id}");

            Assign();
        }
    }
}