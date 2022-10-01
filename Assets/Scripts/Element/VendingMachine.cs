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

        public Action<VendingMachine> OnVendingMachineCompleted;

        [SerializeField] private List<Step.Step> _workersWaiting = new List<Step.Step>();
        [SerializeField] private bool _running;
        [SerializeField] private int _currentWorkers;

        public override void Init(int id)
        {
            _id = "VendingMachine_" + id;
        }

        public override void Assign(Step.Step step)
        {
            if (_currentWorkers < _maxWorkers)
            {
                _workersWaiting.Add(step);
                _currentWorkers++;
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
            OnVendingMachineCompleted?.Invoke(this);
        }

        public override bool isRealised()
        {
            if (_currentWorkers < _maxWorkers) return true;
            else return false;
        }

        public override void Release()
        {
            if (_currentWorkers > 0) _currentWorkers--;
        }
    }
}