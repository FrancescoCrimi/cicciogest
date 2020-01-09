namespace CiccioGest.Infrastructure.Conf
{
    public interface IAppConf
    {
        UI UserInterface { get; }
        Storage DataAccess { get; }
        Databases Database { get; }
        string CS { get; }
        string Name { get; }
    }
}
