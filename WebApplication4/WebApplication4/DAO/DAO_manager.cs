using NLog;
using WebApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication4.DAO
{
    public class DAO_manager
    {
        private Entities1 _entities = new Entities1();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public IEnumerable<Manager> GetAll()
        {
            try
            {
                IEnumerable<Manager> list = _entities.Manager.Select(n => n);
                logger.Debug("Получен список менеджеров");
                return list;
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
            }
            return null;
        }

        public Manager Get(int id)
        {
            try
            {
                Manager item = _entities.Manager.Where(n => n.Id_manager == id).First();
                logger.Debug("Получен менеджер");
                return item;
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
            }
            return null;
        }

        public bool Add(Manager st, string id)
        {
            try
            {
                var currentUser = new Entities1().AspNetUsers.Where(n => n.Id.Equals(id)).FirstOrDefault();
                st.Id_user = currentUser.Id;
                st = _entities.Manager.Add(st);              
                _entities.SaveChanges();
                logger.Debug("Добавлен");
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