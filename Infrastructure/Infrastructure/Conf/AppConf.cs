namespace CiccioGest.Infrastructure.Conf
{
    public class AppConf : IAppConf
    {
        public UI UserInterface { get; set; }
        public Storage DataAccess { get; set; }
        public Databases Database { get; set; }
        public string CS { get; set; }
        public string Name { get; set; }
    }
}
