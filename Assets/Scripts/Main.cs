using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Element.ElementWareHouse.Instance.InitWarehouse();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Element.Table tableReady = (Element.Table)Element.ElementWareHouse.Instance.isAElemenReady<Element.Table>();
            Debug.Log(tableReady.id);
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

    //To remove, only to show results
    [SerializeReference] public List<KeyValuePair> MyList = new List<KeyValuePair>();
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