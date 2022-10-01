using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTesterHandler1 : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        EventDispatcherService.Instance.Subscribe<VendingMachineTimeOut>(dosomething);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void dosomething(Signal signal)
    {
        Debug.Log("Leido 1");
    }
}