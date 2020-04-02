using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyTask.Models
{
	public class ForexResult
	{
		public int Amount { get; set; }
		public string FromCurrency { get; set; }
		public string ToCurrency { get; set; }
		public decimal? ConvertedCurrency { get; set; }
	}
}
