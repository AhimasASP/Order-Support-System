namespace OSS.Domain.Common.Models.Api.Configs
{
	public class ApplicationConfiguration : IApplicationConfiguration
	{
		public string Version { get; set; }

		public string Name { get; set; }

		public string SwaggerUrlTemplate { get; set; }
	}
}