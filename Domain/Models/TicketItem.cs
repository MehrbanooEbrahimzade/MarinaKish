using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class TicketItem
    {
        public TicketItem(Guid scheduleId, int quantity, int quantityInStock, decimal price, Guid cartItemId, Ticket ticket)
        {
            Id = Guid.NewGuid();
            Quantity = quantity;
            Price = price;
            CartItemId = cartItemId;
            Ticket = ticket;
            QuantityInStock = quantityInStock;
            ScheduleId = scheduleId;
            CartItemId = cartItemId;
            Ticket = ticket;
        }

        public TicketItem() { }

        public Guid CartItemId { get; private set; }
        public Guid ScheduleId { get; private set; }
        public Ticket Ticket { get; private set; }

        public Guid Id { get;private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public int QuantityInStock { get; private set; }

    }
}
