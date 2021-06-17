using PPC_HR.DataAccess;
using PPC_HR.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPC_HR.Controllers
{
    public class OrdersController
    {

        public OrdersController()
        {

        }

        public OrderView LoadDisabledEmployeeReport()
        {
            OrderView view = new OrderView(new DataReceiveService().GetOrders());
            return view;
        }

    }
}
