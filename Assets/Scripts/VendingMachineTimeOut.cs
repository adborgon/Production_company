public class VendingMachineTimeOut : Signal
{
    public readonly Step.Step step;

    public VendingMachineTimeOut(Step.Step step)
    {
        this.step = step;
    }

    public string Print()
    {
        return step.elementReady.id;
    }
}