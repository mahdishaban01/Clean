namespace Clean.Domain.Common.Primitives;

public abstract record BaseRecordValueObject
{
    protected BaseRecordValueObject()
    {
        Validate();
    }

    protected abstract void Validate();
}
