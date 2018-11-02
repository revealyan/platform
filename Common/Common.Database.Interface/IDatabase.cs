namespace Common.Database.Interface
{
    public interface IDatabase
    {
        IDatabaseCommand CreateCommand(string command);
    }
}
