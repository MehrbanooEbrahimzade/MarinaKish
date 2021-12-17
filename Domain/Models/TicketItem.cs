using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class TicketItem
    {
        public TicketItem( int quantity, int quantityInStock, decimal price, Ticket ticket)
        {
            Id = Guid.NewGuid();
           
            Quantity = quantity;
            
            Price = price;
            
            Ticket = ticket;
            
            QuantityInStock = quantityInStock;

            Ticket = ticket;
        }

        private TicketItem() { }



        public Ticket Ticket { get; private set; }

        public Guid Id { get;private set; }

        public int Quantity { get; private set; }
        
        public decimal Price { get; private set; }
        
        public int QuantityInStock { get; private set; }

    }
}
