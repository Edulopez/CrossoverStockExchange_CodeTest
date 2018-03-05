using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace CrossoverStockExchange.Core.Entities
{
    public class Entity : IEntity
    {
        public Entity()
        {
            IsActive = true;
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; }
    }
}
