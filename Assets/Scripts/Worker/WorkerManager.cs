using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Worker
{
    public class WorkerManager
    {
        //Init Variables
        private Worker worker;

        private Step.Step[] steps;

        //Workflow Variables

        private float timer;
        private int currentStepCounter;
        private Step.Step currentStep;

        public void Init(Worker worker, Step.Step[] steps)
        {
            this.worker = worker;
            this.steps = steps;
            StartCurrentStep();
        }

        private void NextStep()
        {
            if (currentStepCounter == steps.Length - 1)
            {
                Debug.Log("Finish Steps");
                currentStepCounter = 0;
            }
            else
            {
                currentStepCounter++;
                StartCurrentStep();
            }
        }

        public void StartCurrentStep()
        {
            if (steps.Length == 0) throw new ArgumentOutOfRangeException("steps");

            currentStep = steps[currentStepCounter];
            currentStep.OnStepCompleted += OnStepCompleted;
            currentStep.OnStepFailed += OnStepFailed;
            currentStep.Start(worker);
        }

        #region Handlers

        private void OnStepCompleted(Step.Step step)
        {
            Debug.Log("StepCompleted");
            step.Release();
            NextStep();
        }

        private void OnStepFailed()
        {
            Debug.Log("StepFailed");
            //WaitAngry
        }

        #endregion Handlers
    }
}