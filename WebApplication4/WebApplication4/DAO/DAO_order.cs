using NLog;
using WebApplication4.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Data.Entity.Validation;


namespace WebApplication4.DAO
{
    public class DAO_order
    {
        private Entities1 _entities = new Entities1();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public IEnumerable<Order> GetAllClient(string id)
        {
            try
            {
                var currentUser = new Entities1().AspNetUsers.Where(n => n.Id.Equals(id)).FirstOrDefault();
                var EntityClient = _entities.Client.FirstOrDefault(n => n.Id_user == currentUser.Id);
                IEnumerable<Order> list = _entities.Order.Where(n => n.Id_client == EntityClient.Id_client).Select(n => n);
                logger.Debug("Получен список заказов");
                return list;
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
            }
            return null;
        }

        public IEnumerable<Order> GetAllManager(string id)
        {
            try
            {
                IEnumerable<Order> list = _entities.Order.Select(n => n);
                logger.Debug("Получен список заказов");
                return list;
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
            }
            return null;
        }

        public bool Add( Order Entity, string id, string status) //Подтверждение
        {
            try
            {

                Entity.Status = status;
                Entity.Date = DateTime.Now;             
                var currentUser = new Entities1().AspNetUsers.Where(n => n.Id.Equals(id)).FirstOrDefault();
                var EntityClient = _entities.Client.FirstOrDefault(n => n.Id_user == currentUser.Id);
                Entity.Id_client = EntityClient.Id_client;
                _entities.Order.Add(Entity);
                _entities.SaveChanges();
                logger.Debug("Заказ добавлен");
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
                return false;
            }
            return true;
        }
        public bool Decline(int idAp) //Отклонение
        {
            try
            {
                var EntityApplication = _entities.Order.FirstOrDefault(n => n.Id_order == idAp);
                string st = "Черновик";
                EntityApplication.Status = st;
                _entities.SaveChanges();
                logger.Debug("Изменен статус заказа");
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
                return false;
            }
            return true;
        }
        public Order Get(int id)
        {
            try
            {
                Order item = _entities.Order.Where(n => n.Id_order == id).First();
                logger.Debug("Получен заказ");
                return item;
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
            }
            return null;
        }
        public bool Update(int id, Order st)
        {
            try
            {
                var Entity = _entities.Order.FirstOrDefault(n => n.Id_order == id);
                Entity.Product_name = st.Product_name;
                Entity.Description_wish = st.Description_wish;
                _entities.SaveChanges();
                logger.Debug("Заказ обновлен");
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
                return false;
            }
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                Order applicationToDelete = Get(id);
                _entities.Order.Remove(applicationToDelete);
                _entities.SaveChanges();
                logger.Debug("Заказ удален");
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
                return false;
            }
            return true;
        }
        public bool Send(int id)
        {
            try
            {
                var Entity = _entities.Order.FirstOrDefault(n => n.Id_order == id);
                if (new DAO_category_advertising().Get(Entity.Id_category_advertising) == null) return false;
                Entity.Date = DateTime.Now;
                Entity.Status = "Отправлен";
                _entities.SaveChanges();
                logger.Debug("Изменен статус заказа");
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
                return false;
            }
            return true;
        }
    


    public bool AddAnswer(Order st, string id, int idAp)
        {
            try
            {
                var EntityOrder = _entities.Order.FirstOrDefault(n => n.Id_order == idAp);
                var currentUser = new Entities1().AspNetUsers.Where(n => n.Id.Equals(id)).FirstOrDefault();
                var EntityManager = _entities.Manager.FirstOrDefault(n => n.Id_user == currentUser.Id);
                EntityOrder.Id_manager = EntityManager.Id_manager;
                EntityOrder.Status = "Обработан";
                EntityOrder.Temp_of_delivery = st.Temp_of_delivery;
                EntityOrder.Date_of_withdrawal_of_adertising_turnover = st.Date_of_withdrawal_of_adertising_turnover;
                _entities.SaveChanges();
                logger.Debug("Заказ обработан");
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
                return false;
            }
            return true;
        }
    
    }
}