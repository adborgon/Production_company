using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    //To remove, only to show results
    [SerializeReference] public List<KeyValuePair> MyList = new List<KeyValuePair>();

    // Start is called before the first frame update
    private void Start()
    {
        Element.ElementWareHouse.Instance.InitWarehouse();
        Worker.Worker worker = new Worker.Worker();
        worker.Init("1", Config.CompanyConfiguration.Instance.WorkerTableWaiting, Config.CompanyConfiguration.Instance.WorkerWorkbenchWaiting, Config.CompanyConfiguration.Instance.WorkerAngryWaiting);

        Step.Step[] steps = { new Step.StepTable(), new Step.StepWorkbench() };
        Worker.WorkerManager workerManager = new Worker.WorkerManager();
        workerManager.Init(worker, steps);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

        }
        //To remove, only to show results

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

    private void OnStepCompleted(Step.Step step)
    {
        Debug.Log("StepCompleted");
        step.Release();
        //Next Step
    }

    private void OnStepFailed()
    {
        Debug.Log("StepFailed");
        //WaitAngry
    }
}

//To remove, only to show results

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