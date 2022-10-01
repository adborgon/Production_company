using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class TimerTester : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Timer timer = new Timer(2000);
        timer.Elapsed += (sender, e) => MyElapsedMethod(sender, e, "Hola");
        timer.AutoReset = false;
        timer.Start();
    }

    private void MyElapsedMethod(object sender, ElapsedEventArgs e, string theString)
    {
    }
}