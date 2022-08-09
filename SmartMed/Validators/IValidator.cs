namespace SmartMed.Validators
{
    public interface IValidator<T>
    {
        public bool Validate(T value);
    }
}
