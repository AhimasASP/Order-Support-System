namespace OSS.Domain.Models.Api.Configs
{
    public class DataBaseConfiguration : IDataBaseConfiguration
    {
        public string DbName { get; set; }
        public string ConnectionString { get; set; }
    }
}