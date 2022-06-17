using System;
using System.Collections.Generic;
using System.Text;
using Database;


namespace Logic.Managers
{
    public class PriceManager
    {
        public UnitOfWork _uow;
        public PriceManager(UnitOfWork uow)
        {
            _uow = uow;
        }
        public List<Logic.Models.Price> GetPrices()
        {
            List<DataBase.Models.Price> priceFromDB = _uow.PriceRepository.GetAll().Result;
            List<Logic.Models.Price> mappedPrices = new List<Logic.Models.Price>();
            foreach (DataBase.Models.Price price in priceFromDB)
            {
                mappedPrices.Add(new Logic.Models.Price()
                {
                    Id = price.Id,
                    IdProduct = price.IdProduct,
                    PercentOffer = price.PercentOffer,
                    Type = price.Type,
                    Year = price.Year
                });
            }
            return mappedPrices;
        }
    }
}
