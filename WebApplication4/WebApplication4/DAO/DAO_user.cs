using WebApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;


namespace WebApplication4.DAO
{
    public class DAO_user
    {
        private Entities1 _entities = new Entities1();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public IEnumerable<AspNetUsers> GetAll()
        {
            try
            {
                IEnumerable<AspNetUsers> list = _entities.AspNetUsers.Select(n => n);
                logger.Debug("Получение списка пользователей");
                return list;
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
            }
            return null;
        }

        public AspNetUsers Get(string id)
        {
            try
            {
                AspNetUsers item = _entities.AspNetUsers.Where(n => n.Id == id).First();
                logger.Debug("Получение пользователя");
                return item;
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
            }
            return null;
        }

        public bool UpdateRoles(string id, AspNetRoles st)
        {
            try
            {
                var Entity = _entities.AspNetUsers.FirstOrDefault(n => n.Id == id);
                var EntityRoles = _entities.AspNetRoles.FirstOrDefault(n => n.Name == st.Name);
                Entity.AspNetRoles.Add(EntityRoles);
                _entities.SaveChanges();
                logger.Debug("Обновление роли пользователя");
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
                return false;
            }
            return true;
        }
        public bool DeleteRoles(string id, AspNetRoles st)
        {
            try
            {
                var Entity = _entities.AspNetUsers.FirstOrDefault(n => n.Id == id);
                var EntityRoles = _entities.AspNetRoles.FirstOrDefault(n => n.Name == st.Name);
                if (Entity.AspNetRoles.Contains(EntityRoles))
                {
                    Entity.AspNetRoles.Remove(EntityRoles);
                    _entities.SaveChanges();
                }
                logger.Debug("Удаление роли пользователя");
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
                return false;
            }
            return true;
        }
        public bool Delete(string id)
        {
            try
            {
                AspNetUsers originalMachines = Get(id);
                _entities.AspNetUsers.Remove(originalMachines);
                _entities.SaveChanges();
                logger.Debug("Удаление пользователя");
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