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
    public class StepWorkbench : Step
    {
        public override void Start(Worker.Worker worker)
        {
            _waitTimer = worker.workbenchWaiting;
            elementReady = (Element.Workbech)Element.ElementWareHouse.Instance.isAElemenReady<Element.Workbech>();
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