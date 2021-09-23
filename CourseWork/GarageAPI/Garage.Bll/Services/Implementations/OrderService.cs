using Garage.Bll.Services.Interfaces;
using Garage.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Bll.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private protected IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
    }
}
