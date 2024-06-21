namespace Garage.Search
{
    internal abstract class SearchFilterItemLimitBase(string name)
        : ISearchFilterItemLimitBase
    {
        public string Name { get; } = name;

        public abstract string GetLimitsString();
    }
}