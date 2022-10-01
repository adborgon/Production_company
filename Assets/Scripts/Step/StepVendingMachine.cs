using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

namespace Step
{
    public class StepVendinMachine : Step
    {
        private float _waitTimer; //in seconds

        public override void Start(Worker.Worker worker)
        {
            _waitTimer = worker.workbenchWaiting;
            elementReady = (Element.VendingMachine)Element.ElementWareHouse.Instance.isAElemenReady<Element.VendingMachine>();
            if (elementReady == null)
            {
                OnStepFailed?.Invoke();
                return;
            }
            Assign();
        }

        private void Assign()
        {
            elementReady?.Assign();
        }

        private void StartCountDown()
        {
            Timer timer = new Timer(_waitTimer * 1000); // seconds to miliseconds
            timer.Elapsed += (sender, e) => ElapsedMethod(sender, e);
            timer.AutoReset = false;
            timer.Start();
        }

        private void ElapsedMethod(object sender, ElapsedEventArgs e)
        {
            OnStepCompleted?.Invoke(this);
        }

        public override void Release()
        {
            elementReady.Release();
        }
    }
}