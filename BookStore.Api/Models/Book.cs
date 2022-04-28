namespace BookStore.Api.Models
{
	public class Book
	{
		public int Id { get; set; }
		public string Publisher { get; set; }
		public string Title { get; set; }
		public string AuthorLastName { get; set; }
		public string AuthorFirstName { get; set; }
		public decimal Price { get; set; }
		public string MLACitation { get { return GetMLACitation(); } }
		public string Chicagoitation { get { return GetChicagoitation(); } }

		private string GetMLACitation()
		{
			return AuthorLastName + "," + AuthorFirstName + "\"" + Title + "\"";

		}
		private string GetChicagoitation()
		{
			return AuthorLastName + "," + AuthorFirstName + "\"" + Title + "\"";

		}
	}
	}
