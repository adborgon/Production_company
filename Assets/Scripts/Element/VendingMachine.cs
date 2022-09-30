using System;
using System.Configuration;
using System.Collections.Specialized;
using UnityEngine;

namespace Element
{
    [Serializable]
    public class VendingMachine : Element
    {
        public readonly int waitingTime = Config.CompanyConfiguration.Instance.VendingMachineWaitingTime;
        private readonly int _maxWorkers = Config.CompanyConfiguration.Instance.VendingMachineMaxWorkers;
        [SerializeField] private int _currentWorkers;

        public override void Init(int id)
        {
            _id = "VendingMachine_" + id;
        }

        public override void Release()
        {
            if (_currentWorkers > 0) _currentWorkers--;
        }

        public override void Assign()
        {
            if (_currentWorkers < _maxWorkers) _currentWorkers++;
        }

        public override bool isRealised()
        {
            if (_currentWorkers >= _maxWorkers) return false;
            else return true;
        }
    }
}