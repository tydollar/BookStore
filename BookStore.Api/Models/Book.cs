using System;

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
		public string PageRange { get; set; }
		public DateTime PublishDate { get; set; }
		public string MLACitation { get { return GetMLACitation(); } }
		public string Chicagoitation { get { return GetChicagoitation(); } }

		/***
		 * AuthorLast, AuthorFirst."Title"Publisher, PublicationDate,pp location
		 * 
		 */
		private string GetMLACitation()
		{
			return AuthorLastName + "," + AuthorFirstName + ".\"" + Title + "\""+Publisher+", "+PublishDate.ToString("MMMM yyyy")
				+", pp "+PageRange+".";

		}
		/**
		 * Using the format AuthorFirstName AuthorLastName, Title(Publisher,PublisherDate),Location.
		 */
		private string GetChicagoitation()
		{
			return AuthorFirstName + " " + AuthorLastName +", "+ Title + " (" + Title + "," 
				+ PublishDate.ToString("MMMM yyyy") + ")"
				+ PageRange + ".";

		}
	}
	}
