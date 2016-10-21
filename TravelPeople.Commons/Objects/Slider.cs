using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TravelPeople.Commons.Interfaces;

namespace TravelPeople.Commons.Objects
{
	/// <summary>
	/// Description of Slider.
	/// </summary>
	public class Slider : Node, ISlider
	{
		[Required(ErrorMessage = "Name is required.")]
		[StringLength(50)]
		[DisplayName("Slider Name")]		
		public string name { get; set; }
		
		[StringLength(100)]
		[DisplayName("Image Path")]
		public string imagePath { get; set; }
		
		[StringLength(50)]
		[DisplayName("Alternative Text")]
		public string altText { get; set; }
	}
}
