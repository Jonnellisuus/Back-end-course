using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RateTask.Models
{
	public class RateResult
	{
		public DateTime Date { get; set; }
		public int Amount { get; set; }
		public string FromCurrency { get; set; }
		public string ToCurrency { get; set; }
		public decimal? ConvertedCurrency { get; set; }
    }
}
