namespace Cash
{
    public interface ICollectable
    {
        int Value { get; set; }
        void Collect();
    }
}