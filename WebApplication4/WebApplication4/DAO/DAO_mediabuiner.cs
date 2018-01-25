using NLog;
using WebApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.DAO
{
    public class DAO_mediabuiner
    {
        
        private Entities1 _entities = new Entities1();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public IEnumerable<Mediabuiner> GetAll()
        {
            try
            {
                IEnumerable<Mediabuiner> list = _entities.Mediabuiner.Select(n => n);
                logger.Debug("Получен список медиабайнеров");
                return list;
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
            }
            return null;
        }

        public Mediabuiner Get(int id)
        {
            try
            {
                Mediabuiner item = _entities.Mediabuiner.Where(n => n.Id_mediabuiner == id).First();
                logger.Debug("Получен медиабайнер");
                return item;
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
            }
            return null;
        }

        public bool Add(Mediabuiner st, string id)
        {
            try
            {
                var currentUser = new Entities1().AspNetUsers.Where(n => n.Id.Equals(id)).FirstOrDefault();
                st.Id_user = currentUser.Id;
                st = _entities.Mediabuiner.Add(st);
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
