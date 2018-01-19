using NLog;
using WebApplication4.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication4.DAO
{
    public class DAO_mass_media
    {
        private Entities1 _entities = new Entities1();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public Mass_media Get(int id)
        {
            try
            {
                Mass_media item = _entities.Mass_media.Where(n => n.Id_mass_media == id).First();
                logger.Debug("Получено стедство массовой информации");
                return item;
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
            }
            return null;
        }
        public IEnumerable<Mass_media> GetAll()
        {
            try
            {
                IEnumerable<Mass_media> list = _entities.Mass_media.Select(n => n);
                logger.Debug("Получен список массовой информации");
                return list;
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
            }
            return null;
        }
        public IEnumerable<Mass_media> Add(Mass_media st, string pos_id)
        {
            try
            {
                var currentUser = new Entities1().AspNetUsers.Where(n => n.Id.Equals(pos_id)).FirstOrDefault();
                var EntityMediabuiner = _entities.Mediabuiner.FirstOrDefault(n => n.Id_user == currentUser.Id);
                st.Id_mediabuiner = EntityMediabuiner.Id_mediabuiner;
                _entities.Mass_media.Add(st);
                _entities.SaveChanges();
                logger.Debug("Добавлено стредство массовой информации");

            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
            }
            return null;
        }
    }
}