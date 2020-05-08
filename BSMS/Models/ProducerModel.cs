using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BSMS.bsms.localhost;

namespace BSMS.Models
{
    public class ProducerModel
    {
        private static bsms_service Services = new bsms_service();
        internal static List<PRODUCER> GetProducers()
        {
            return Services.GetProducers().ToList();
        }

        internal static PRODUCER Filter(int id)
        {
            foreach(PRODUCER producer in GetProducers()){
                if (producer.PRODUCERID == id)
                {
                    return producer;
                }
            }
            return null;
        }

        internal static void Create(PRODUCER producer)
        {
            Services.InsertProducer(producer);
        }

        internal static void Update(PRODUCER producer)
        {
            Services.UpdateProducer(producer);
        }

        internal static void Delete(int id)
        {
            Services.DeleteProducer(id);
        }
    }
}