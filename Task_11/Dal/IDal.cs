using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IDal
    {
        IEnumerable<Entities.Order> GetAll();                           //реализация задачи 1
        bool AddOrder(Entities.Order order);                            //реализация задачи 3
        IEnumerable<Entities.Order> GetById(Guid id);                   //реализация задачи 2
        bool TransferToWork(Guid id, DateTime data);                    //реализация задачи 4.1
        bool MarkMadeComplete(Guid id, DateTime data);                  //реализация задачи 4.2
        IEnumerable<Entities.Order> CustOrderHist(string customerID);   //реализация задачи 5.1
        IEnumerable<Entities.Order> CustOrdersDetail(Guid orderID);     //реализация задачи 5.2
    }
}
