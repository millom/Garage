namespace Garage.Search
{
    public class SearchFilterItemWeels(string name)
        : SearchFilterItemBase<int>(name),
        ISearchFilterItemWeels
    {
        public override string GetLimitsString()
        {
            throw new NotImplementedException();
        }
    }
}