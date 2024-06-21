namespace Garage.Search
{
    public class SearchFilterItemExtraProp<T>(string name)
        : SearchFilterItemBase<T>(name),
        ISearchFilterItemExtraProp<T> where T : struct, IComparable<T>
    {
        public override string GetLimitsString()
        {
            throw new NotImplementedException();
        }
    }
}