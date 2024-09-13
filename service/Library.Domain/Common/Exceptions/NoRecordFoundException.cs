namespace Library.Domain.Common.Exceptions
{
    public class NoRecordFoundException<T> : Exception
    {
        public NoRecordFoundException() :base(String.Format(Localization.NoRecordFound, typeof(T).FullName)) { }
    }
}
