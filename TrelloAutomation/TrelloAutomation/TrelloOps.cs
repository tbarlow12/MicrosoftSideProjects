using Manatee.Trello;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manatee.Trello.Rest;
using Manatee.Trello.ManateeJson;
using Manatee.Trello.WebApi;

namespace TrelloAutomation
{
    static class TrelloOps
    {

        // Key: fff37eb4d5dc0d32cb123cc06f88b032
        // Secret: 73555407d85bdb0b7d3fcadc8c97554464f9195f53018d936271864806d5738d
        // Token: 52373a93deb25e10e724265ef787ce9e46c06fee40e3bef6fd31f4c94f8f6367

        public static void Move(this Card card, List list = null, int? position = null)
        {
            if (list != null && list != card.List)
            {
                card.List = list;
            }
            if (position == null)
                position = list.Cards.Count();
            card.Position = position;
        }

        public static List ListByName(this ListCollection lists, string name)
        {
            foreach(List list in lists)
            {
                if (list.Name.Equals(name))
                {
                    return list;
                }
            }
            return null;
        }

        public static void MoveAllCards(this List sourceList, List destList)
        {
            var cards = sourceList.Cards;
            foreach (Card c in cards)
            {
                c.Move(destList);
            }
        }


        public static void Initialize()
        {
            var serializer = new ManateeSerializer();
            TrelloConfiguration.Serializer = serializer;
            TrelloConfiguration.Deserializer = serializer;
            TrelloConfiguration.JsonFactory = new ManateeFactory();
            TrelloConfiguration.RestClientProvider = new WebApiClientProvider();
            TrelloAuthorization.Default.AppKey = "fff37eb4d5dc0d32cb123cc06f88b032";
            TrelloAuthorization.Default.UserToken = "52373a93deb25e10e724265ef787ce9e46c06fee40e3bef6fd31f4c94f8f6367";
        }

    }
}
