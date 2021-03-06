using Newtonsoft.Json;

namespace Mendes.Trucks.Domain.Dto
{
	public class PurchaseApiDto
	{
		[JsonProperty("statusCode")]
		public int StatusCode { get; set; }

		[JsonProperty("body")]
		public BodyDto Body { get; set; }

		public class BodyDto
		{
			[JsonProperty("credit")]
			public int Credit { get; set; }
		}
	}
}
