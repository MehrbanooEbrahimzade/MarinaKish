using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class CartItem
    {
        public CartItem(Guid userId)
        {
            UserId = userId;
            Id = Guid.NewGuid();
            Items = new List<TicketItem>();
        }

        public CartItem() {}

        public Guid UserId { get; private set; }
        public List<TicketItem> Items { get; private set; }


        public Guid Id { get; private set; }

        private decimal _totalPrice;

        public decimal TotalPrice {
            get => _totalPrice;
            private set
            {
                foreach (var x in Items)
                {
                    value += x.Price * x.Quantity;
                }

                _totalPrice = value;
            }
        }
    }
}
