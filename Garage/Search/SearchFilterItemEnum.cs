namespace Garage.Search
{
    internal class SearchFilterItemEnum<T>(string name)
        : SearchFilterItemBase<T>(name),
        ISearchFilterItemEnum<T> where T : struct, Enum
    {
        public override string GetLimitsString()
        {
            throw new NotImplementedException();
        }
    }
}