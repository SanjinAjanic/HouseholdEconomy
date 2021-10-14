namespace HouseholdEconomy
{
    /// <summary>
    /// Interface for balance related classes. 
    /// </summary>
    public interface IBalance
    {
        public string Name { get; set; }
        public double Amount { get; set; }
    }
}