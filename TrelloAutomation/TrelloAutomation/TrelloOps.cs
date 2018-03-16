using Manatee.Trello;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manatee.Trello.Rest;
using Manatee.Trello.ManateeJson;
using Manatee.Trello.WebApi;
using System.Xml;

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
            {
                position = 1;
            }
            card.Position = position;
        }

        public static List ByName(this ListCollection lists, string name)
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

        public static Label ByName(this BoardLabelCollection labels, string name)
        {
            foreach(Label label in labels)
            {
                if (label.Name.Equals(name))
                {
                    return label;
                }
            }
            return null;
        }

        public static Label ByName(this CardLabelCollection labels, string name)
        {
            foreach (Label label in labels)
            {
                if (label.Name.Equals(name))
                {
                    return label;
                }
            }
            return null;
        }

        public static bool HasLabel(this Card card, string name)
        {
            return card.Labels.ByName(name) != null;
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
            XmlDocument doc = new XmlDocument();
            doc.Load(@"secrets.xml");
            TrelloAuthorization.Default.AppKey = doc.LastChild.FirstChild.InnerText;
            TrelloAuthorization.Default.UserToken = doc.LastChild.LastChild.InnerText;
        }

    }
}
