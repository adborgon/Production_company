using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

namespace Step
{
    [Serializable]
    public class StepVendingMachine : Step
    {
        public Worker.Worker _currentWorker { get; private set; }

        public override void Start(Worker.Worker worker)
        {
            EventDispatcherService.Instance.Subscribe<VendingMachineTimeOut>(StepCompleted);
            _currentWorker = worker;
            _waitTimer = worker.workbenchWaiting;
            elementReady = (Element.VendingMachine)Element.ElementWareHouse.Instance.isAElemenReadyAndAssign<Element.VendingMachine>();
            if (elementReady == null)
            {
                OnStepFailed?.Invoke();
                return;
            }
            Debug.Log($"{worker.id} is assign to {elementReady.id}");
            Assign();
        }

        public override void Assign()
        {
            elementReady?.Assign(this);
        }

        private void StepCompleted(Signal signal)
        {
            if (_currentWorker.Equals(((VendingMachineTimeOut)signal).step._currentWorker))
                OnStepCompleted?.Invoke(this);
        }

        public override void Release()
        {
            EventDispatcherService.Instance.Unsubscribe<VendingMachineTimeOut>(StepCompleted);
        }
    }
}