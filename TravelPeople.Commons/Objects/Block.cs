using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Interfaces;

namespace TravelPeople.Commons.Objects
{
	public class Block : Node, IBlock
	{
		[Required(ErrorMessage = "Block name is required.")]
		[StringLength(50)]
		[UIHint("TextBox")]
		[DisplayName("Block Name")]
		public string name
		{
			get;

			set;
		}
		
		[UIHint("CKEditor")]
		[DisplayName("Body")]
		public string content
		{
			get;

			set;
		}

		public string alias
		{
			get;

			set;
		}

		public string position
		{
			get;

			set;
		}

		[StringLength(50)]
		[UIHint("TextBox")]
		[DisplayName("Header Text")]
		public string headerText
		{
			get;

			set;
		}
	}
}
