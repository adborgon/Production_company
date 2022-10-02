using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Main : MonoBehaviour
{
    public int workersCount;

    private void Start()
    {
        Element.ElementWareHouse.Instance.InitWarehouse();

        for (int i = 0; i < workersCount; i++)
        {
            Worker.Worker worker = new Worker.Worker();
            worker.Init(i.ToString(), Config.CompanyConfiguration.Instance.WorkerTableWaiting, Config.CompanyConfiguration.Instance.WorkerWorkbenchWaiting, Config.CompanyConfiguration.Instance.WorkerAngryWaiting);

            Step.Step[] steps = { new Step.StepVendingMachine(), new Step.StepTable(), new Step.StepWorkbench() };
            Worker.WorkerManager workerManager = new Worker.WorkerManager();
            workerManager.Init(worker, steps);
        }
    }

    private void OnApplicationQuit()
    {
    }

    #region Show Results On editor

    //To remove, only to show results
    [SerializeReference] public List<KeyValuePair> MyList = new List<KeyValuePair>();

    //To remove, only to show results
    private void Update()
    {
        MyList.Clear();
        foreach (var kvp in Element.ElementWareHouse.Instance.elementsOnWarehouse)
        {
            List<KeyValuePairElement> list = new List<KeyValuePairElement>();
            foreach (var item in kvp.Value)
            {
                list.Add(new KeyValuePairElement(item.id, item.isRealised()));
            }
            MyList.Add(new KeyValuePair(kvp.Key.Name, list));
        }
    }

    [Serializable]
    public class KeyValuePair
    {
        public string key;
        public List<KeyValuePairElement> val;

        public KeyValuePair(string key, List<KeyValuePairElement> val)
        {
            this.key = key;
            this.val = val;
        }
    }

    [Serializable]
    public class KeyValuePairElement
    {
        public string id;
        public bool available;

        public KeyValuePairElement(string id, bool available)
        {
            this.id = id;
            this.available = available;
        }
    }

    #endregion Show Results On editor
}