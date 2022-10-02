using System;
using System.Configuration;
using System.Collections.Specialized;
using UnityEngine;
using System.Collections.Generic;
using System.Timers;

namespace Element
{
    [Serializable]
    public class VendingMachine : Element
    {
        public readonly int waitingTime = Config.CompanyConfiguration.Instance.VendingMachineWaitingTime;
        private readonly int _maxWorkers = Config.CompanyConfiguration.Instance.VendingMachineMaxWorkers;

        [SerializeField] private List<Step.Step> _workersWaiting = new List<Step.Step>();
        [SerializeField] private bool _running;

        public override void Init(int id)
        {
            _id = "VendingMachine_" + id;
        }

        public override void Assign(Step.Step step)
        {
            if (_workersWaiting.Count < _maxWorkers)
            {
                _workersWaiting.Add(step);
                if (!_running)
                {
                    _running = true;
                    StartCountDown();
                }
            }
        }

        private void StartCountDown()
        {
            Timer timer = new Timer(waitingTime * 1000); // seconds to miliseconds
            timer.Elapsed += (sender, e) => ElapsedMethod(sender, e);
            timer.AutoReset = false;
            timer.Start();
        }

        private void ElapsedMethod(object sender, ElapsedEventArgs e)
        {
            EventDispatcherService.Instance.Dispatch(new VendingMachineTimeOut((Step.StepVendingMachine)_workersWaiting[0]));
            Release();
        }

        public override bool isRealised()
        {
            if (_workersWaiting.Count < _maxWorkers) return true;
            else return false;
        }

        public override void Release()
        {
            _workersWaiting.Remove(_workersWaiting[0]);
            if (_workersWaiting.Count > 0)
                StartCountDown();
            else
                _running = false;
        }
    }
}