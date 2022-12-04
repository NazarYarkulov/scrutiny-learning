public record StudentQueryFilter
{
    public string FullName { get; init; }
    public bool SortByAscending { get; init; } = false;
}