using System;
using System.Collections.Generic;
using System.Text;
using BackingServices.Services;
using Database;
using DataBase.Repositories;
using Logic.Models;

namespace Logic.Managers
{
    public class PriceManager
    {
        private UnitOfWork _uow;
        private CampaignService _offerPrice;
        public PriceManager(UnitOfWork uow, CampaignService offerPrice )
        {
            _uow = uow;
            _offerPrice = offerPrice;
        }
        public List<Logic.Models.Price> GetPrices()
        {
            List<Database.Models.Price> priceFromDB = _uow.PriceRepository.GetAll().Result;
            List<Logic.Models.Price> mappedPrices = new List<Logic.Models.Price>();
            foreach (Database.Models.Price price in priceFromDB)
            {
                mappedPrices.Add(new Logic.Models.Price()
                {
                    //Id = price.Id,
                    IdProduct = price.IdProduct, 
                    PercentOffer = price.PercentOffer,
                    Type = price.Type,
                    Year = price.Year
                });
            }
            return mappedPrices;
        }

        public Campaign GetOfferPrice(string offer, int originalPrice)
        {
            BackingServices.Models.Campaign offerPriceFromService = _offerPrice.GetOfferPriceAsync( offer, originalPrice).Result;
            return new Campaign()
            {
                OfferPrice = offerPriceFromService.OfferPrice,
            };
        }
    }
}
