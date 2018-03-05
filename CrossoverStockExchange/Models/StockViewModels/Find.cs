using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrossoverStockExchange.Models.StockViewModels
{
    public class Find
    {
        [Required(AllowEmptyStrings = false, ErrorMessage="Code cannot be empty")]
        [DisplayName("Stack Exchange Code") ,]
        [RegularExpression("^[a-zA-Z0-9]+$",ErrorMessage = "Only numbers and letters are accepted")]
        public string Code { get; set; }

        public Core.Entities.Stock stock { get; set; }

    }
}