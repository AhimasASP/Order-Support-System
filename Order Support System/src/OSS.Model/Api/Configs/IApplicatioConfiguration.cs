namespace OSS.Domain.Common.Models.Api.Configs
{
	public interface IApplicationConfiguration
	{
		string Version { get; set; }

		string Name { get; set; }

		string SwaggerUrlTemplate { get; set; }
	}
}