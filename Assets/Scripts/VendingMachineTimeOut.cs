public class VendingMachineTimeOut : Signal
{
    public readonly Step.StepVendingMachine step;

    public VendingMachineTimeOut(Step.StepVendingMachine step)
    {
        this.step = step;
    }

    public string Print()
    {
        return step.elementReady.id;
    }
}