using BackingServices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BackingServices.Services
{
    public class CampaignService
    {
        public async Task<Campaign> GetOfferPriceAsync(string offer, int originalPrice)
        {
            try
            {
                Console.WriteLine("pidiendo precio de descuento");
                using (HttpClient client = new HttpClient())
                {
                    string offerPriceURL = "https://random-data-api.com/api/campaign/calculate-promotional-prices";
                    HttpResponseMessage response = await client.GetAsync(offerPriceURL);
                    if (response.IsSuccessStatusCode)
                    {
                        string offerPriceBody = await response.Content.ReadAsStringAsync();
                        Campaign offerPrice = JsonConvert.DeserializeObject<Campaign>(offerPriceBody);
                        return offerPrice;
                    }
                    else
                    {
                        throw new Exception("Hubo fallas al calcular el precio de oferta");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hubo fallas al calcular el precio de oferta");
                Console.WriteLine(ex.Message + ex.StackTrace);
                throw;
            }
        }
    }
}
