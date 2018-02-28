using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manatee;
using Manatee.Trello;
using Manatee.Trello.Rest;
using Manatee.Trello.ManateeJson;
using Manatee.Trello.WebApi;


namespace TrelloAutomation
{
    class Program
    {

        // Key: fff37eb4d5dc0d32cb123cc06f88b032
        // Secret: 73555407d85bdb0b7d3fcadc8c97554464f9195f53018d936271864806d5738d
        // Token: 52373a93deb25e10e724265ef787ce9e46c06fee40e3bef6fd31f4c94f8f6367

        private static void Move(Card card, int position, List list = null)
        {
            if (list != null && list != card.List)
            {
                card.List = list;
            }
            card.Position = position;
        }

        private static void MoveAllCards(List sourceList, List destList)
        {
            var cards = sourceList.Cards;
            foreach(Card c in cards)
            {
                Move(c, destList.Cards.Count(), destList);
            }
        }

        static void Main(string[] args)
        { 

            var serializer = new ManateeSerializer();
            TrelloConfiguration.Serializer = serializer;
            TrelloConfiguration.Deserializer = serializer;
            TrelloConfiguration.JsonFactory = new ManateeFactory();
            TrelloConfiguration.RestClientProvider = new WebApiClientProvider();
            TrelloAuthorization.Default.AppKey = "fff37eb4d5dc0d32cb123cc06f88b032";
            TrelloAuthorization.Default.UserToken = "52373a93deb25e10e724265ef787ce9e46c06fee40e3bef6fd31f4c94f8f6367";

            //Board id is 566c9eb231c1dc186fe938fe
            var board = new Board("566c9eb231c1dc186fe938fe");
            var lists = board.Lists;
            var list = lists.First();
            
            
        }
    }
}
