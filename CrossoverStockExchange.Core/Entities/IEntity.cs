using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CrossoverStockExchange.Core.Attributes;


namespace CrossoverStockExchange.Core.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
        [ScaffoldColumn(false)]
        [DefaultValue(true)]
        bool IsActive { get; set; }
        [ScaffoldColumn(false)]
        [DefaultDateTime(0)]
        DateTime CreatedAt { get; set; }
    }
}
