using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
                StartCurrentStep();
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
            Debug.Log($"Step Completed: {worker.id} on {step.elementReady.id}");
            ReleaseHandlers();
            step.Release();
            NextStep();
        }

        private void OnStepFailed()
        {
            Debug.Log($"Step Failed: {worker.id} on step {currentStepCounter} ¡Rage quit!");
            ReleaseHandlers();
            StartAngryTimer();
        }

        private void ElapsedMethod(object sender, ElapsedEventArgs e)
        {
            StartCurrentStep();
        }

        private void ReleaseHandlers()
        {
            currentStep.OnStepCompleted -= OnStepCompleted;
            currentStep.OnStepFailed -= OnStepFailed;
        }

        #endregion Handlers

        private void StartAngryTimer()
        {
            Timer timer = new Timer(worker.angryWaiting * 1000); // seconds to miliseconds
            timer.Elapsed += (sender, e) => ElapsedMethod(sender, e);
            timer.AutoReset = false;
            timer.Start();
        }
    }
}