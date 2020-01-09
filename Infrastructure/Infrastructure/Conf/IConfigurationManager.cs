namespace CiccioGest.Infrastructure.Conf
{
    public interface IConfigurationManager
    {
        void ReadConfiguration();
        void WriteConfiguration();
    }
}