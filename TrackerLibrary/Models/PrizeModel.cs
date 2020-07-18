using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PrizeModel
    {
        public int Id { get; set; }
        public int PlaceNumber { get; set; }
        public string PlaceName { get; set; }
        public decimal PrizeAmount { get; set; }
        public double PrizePercentage { get; set; }

        public PrizeModel(string id, string placeNumber, string placeName, string prizeAmount)
        {

            

            int placeNumberValue = 0;
            int.TryParse(placeNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            
            PlaceName = placeName;

            
            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;


        }


            public PrizeModel(string id, string placeName, string placeNumber, string prizeAmount, string prizePercentage)
            {

                int idValue = 0;
                int.TryParse(id, out idValue);
                idValue = Id;



                int placeNumberValue = 0;
                int.TryParse(placeNumber, out placeNumberValue);
                PlaceNumber = placeNumberValue;
                PlaceName = placeName;

                decimal prizeAmountValue = 0;
                decimal.TryParse(prizeAmount, out prizeAmountValue);
                PrizeAmount = prizeAmountValue;

                double prizePercentageValue = 0;
                double.TryParse(prizePercentage, out prizePercentageValue);
                PrizePercentage = prizePercentageValue;
            }

        public PrizeModel()
        {

        }
        
    }
}
