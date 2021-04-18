using System;

namespace stock_manager.Models
{
    public class Move
    {
        public int Id { get; set; }
        
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string Description { get; set; }

        public DateTime ModeDate { get; set; }
    }
}