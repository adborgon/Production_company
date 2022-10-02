using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;

namespace Step
{
    [Serializable]
    public abstract class Step
    {
        public Action<Step> OnStepCompleted;
        public Action OnStepFailed;

        public Element.Element elementReady;
        public float _waitTimer; //in seconds

        public abstract void Start(Worker.Worker worker); //Falta Input Worker

        public virtual void Assign()
        {
            elementReady?.Assign();
            StartCountDown();
        }

        public virtual void StartCountDown()
        {
            Timer timer = new Timer(_waitTimer * 1000); // seconds to miliseconds
            timer.Elapsed += (sender, e) => ElapsedMethod(sender, e);
            timer.AutoReset = false;
            timer.Start();
        }

        public virtual void ElapsedMethod(object sender, ElapsedEventArgs e)
        {
            OnStepCompleted?.Invoke(this);
        }

        public virtual void Release()
        {
            elementReady.Release();
        }
    }
}