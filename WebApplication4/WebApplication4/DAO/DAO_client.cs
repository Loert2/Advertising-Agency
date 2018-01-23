using NLog;
using WebApplication4.Models;
using System.Collections.Generic;
using System.Linq;


namespace WebApplication4.DAO
{

    public class DAO_client
    {
        private Entities1 _entities = new Entities1();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public IEnumerable<Client> GetAll()
        {
            try
            {
                IEnumerable<Client> list = _entities.Client.Select(n => n);
                logger.Debug("Получение списка клиентов");
                return list;
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
            }
            return null;
        }
        
        public bool Add(Client st, string id)
        {
            try
            {
                st.Id_user = id;
                _entities.Client.Add(st);
                _entities.SaveChanges();
                logger.Debug("Добавление информации клиента");
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
                return false;
            }
            return true;
        }

        public Client Get(string id) 
        {
            try
            {
                var currentUser = new Entities1().AspNetUsers.Where(n => n.Id.Equals(id)).FirstOrDefault();
                Client item = _entities.Client.Where(n => n.Id_user == currentUser.Id).First();
                logger.Debug("Получение текущего клиента");
                return item;
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                logger.Error("Ошибка: ", ex);
            }
            return null;
        }
    }
}