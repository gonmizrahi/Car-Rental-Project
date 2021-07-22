using DAL.Databases;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Logic
{
    // order functions thats connecting the controller to the DB
    public class OrderData
    {
        private IOrders orders = new DAL.functions.OrderFunctions();

        public List<CarsOrder> GetOrder()
        {
            return orders.GetOrder();
        }

        public CarsOrder GetOrderById(int id)
        {
            return orders.GetOrderById(id);
        }
        public List<CarsOrder> GetOrderByUserId(int id)
        {
            return orders.GetOrderByUserId(id);
        }

        public CarsOrder AddNewOrder(CarsOrder order)
        {
            return orders.AddNewOrder(order);
        }

        public CarsOrder DeleteOrder(int id)
        {
            return orders.DeleteOrder(id);
        }
        public int ReturnOrder(CarsOrder returnOrder, int id)
        {
            return orders.ReturnOrder(returnOrder, id);
        }

        public CarsOrder UpdateOrder(CarsOrder order, int id)
        {
            return orders.UpdateOrder(order, id);
        }
    }
}
