using System;
using System.Collections.Generic;
using System.Text;

namespace OSS.Domain.Models.Api.Configs
{
    public interface IDataBaseConfiguration
    {
        string DbName { get; set; }
        string ConnectionString { get; set; }
    }
}
