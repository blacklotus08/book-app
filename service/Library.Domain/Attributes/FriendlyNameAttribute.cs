namespace Library.Domain.Attributes
{
    public class FriendlyNameAttribute : Attribute
    {
        public string Name { get; set; }
        public FriendlyNameAttribute(string name) 
        {
            Name = name;
        }
    }
}
