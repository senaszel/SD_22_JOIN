using System;
using System.Collections.Generic;
using System.Linq;

namespace SD_22_JOIN
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> itemList = new List<Item>
            {
           new Item { ItemId = 1, ItemName = "Biscuit" },
           new Item { ItemId = 2, ItemName = "Chocolate" },
           new Item { ItemId = 3, ItemName = "Butter" },
           new Item { ItemId = 4, ItemName  = "Bread" },
           new Item { ItemId = 5, ItemName = "Honey" }
            };

            List<Purchase> purchaseList = new List<Purchase>
            {
           new Purchase { InvoiceNo =100, ItemId = 3,  PurchaseQuantity = 800 },
           new Purchase { InvoiceNo =101, ItemId = 2,  PurchaseQuantity = 650 },
           new Purchase { InvoiceNo =102, ItemId = 3,  PurchaseQuantity = 900 },
           new Purchase { InvoiceNo =103, ItemId = 4,  PurchaseQuantity = 700 },
           new Purchase { InvoiceNo =104, ItemId = 3,  PurchaseQuantity = 900 },
           new Purchase { InvoiceNo =105, ItemId = 4,  PurchaseQuantity = 650 },
           new Purchase { InvoiceNo =106, ItemId = 1,  PurchaseQuantity = 458 }
            };

            var linq =
                        from purchase in purchaseList
                        join item in itemList on purchase.ItemId equals item.ItemId
                        select (ItemId: purchase.ItemId, ItemName: item.ItemName, PurchaseQuantity: purchase.PurchaseQuantity);


            var header = string.Concat("Item ID".PadLeft(10), "Item Name".PadLeft(20), "Purchase Quantity".PadLeft(20));
            Console.WriteLine(header);
            Console.WriteLine(new string('-',50));

            linq.ToList().ForEach(x => {

                var formattedX = string.Concat(x.ItemId.ToString().PadLeft(10),x.ItemName.PadLeft(20),x.PurchaseQuantity.ToString().PadLeft(20));
                Console.WriteLine(formattedX);
                
                });

            Console.WriteLine("Program ended.");
        }
        

    }
}
