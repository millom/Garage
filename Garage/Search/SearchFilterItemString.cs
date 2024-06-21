namespace Garage.Search
{
    public class SearchFilterItemString(string name)
        : SearchFilterItemBase<string>(name),
        ISearchFilterItemString 
    {
        public override string GetLimitsString()
        {
            throw new NotImplementedException();
        }
    }
}