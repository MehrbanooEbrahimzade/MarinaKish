using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Application.Services.classes
{
    public class CartItemService
    {
        //   public void addItem(TicketItem item)
        //{
        //    if (CartItems.Exists(i => i.Id == item.Id))
        //    {
        //        CartItems.Find(i => i.Item.Id == item.Id)
        //            .Quantity += 1;
        //    }
        //    else
        //    {
        //        CartItems.Add(item);
        //    }
        //}

        //public void removeItem(int itemId)
        //{
        //    var item = CartItems
        //        .SingleOrDefault(c => c.Item.Id == itemId);
        //    if (item?.Quantity <= 1)
        //    {
        //        CartItems.Remove(item);
        //    }
        //    else if (item != null)
        //    {
        //        item.Quantity -= 1;
        //    }
        //}
    }
}
