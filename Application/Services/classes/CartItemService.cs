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
        //    if (CartItems.Exists(i => i.commentId == item.commentId))
        //    {
        //        CartItems.Find(i => i.CartItem.commentId == item.commentId)
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
        //        .SingleOrDefault(c => c.CartItem.commentId == itemId);
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
