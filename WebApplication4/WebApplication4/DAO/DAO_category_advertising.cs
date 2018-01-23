using NLog;
using WebApplication4.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication4.DAO
{
    public class DAO_category_advertising
    {
        private Entities1 _entities = new Entities1();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        public bool AddMass_media(Category_advertising st, int id)
        {
            try
            {
                var Entity = _entities.Category_advertising.FirstOrDefault(n => n.Id_category_advertising == id);
                Entity.Id_mass_media = st.Id_mass_media;
                _entities.SaveChanges();
                logger.Debug("Добавление масс-медиа");
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
                return false;
            }
            return true;
        }
        public Category_advertising Get(int? id)
        {
            try
            {
                Category_advertising item = _entities.Category_advertising.Where(n => n.Id_category_advertising == id).First();
                logger.Debug("Получена категория рекламы");
                return item;
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
            }
            return null;
        }
        public IEnumerable<Category_advertising> GetAll()
        {
            try
            {
                IEnumerable<Category_advertising> list = _entities.Category_advertising.Select(n => n);
                logger.Debug("Получен список категорий рекламы");
                return list;
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
            }
            return null;
        }
        public IEnumerable<Category_advertising> Add(Category_advertising st, string id)
        {
            try
            {
                var currentUser = new Entities1().AspNetUsers.Where(n => n.Id.Equals(id)).FirstOrDefault();
                var EntityManager = _entities.Manager.FirstOrDefault(n => n.Id_user == currentUser.Id);
                st.Id_manager = EntityManager.Id_manager;
                _entities.Category_advertising.Add(st);
                _entities.SaveChanges();
                logger.Debug("Добавлена категория рекламы");
                
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
            }
            return null;
        }
    }
}