using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manatee;
using Manatee.Trello;



namespace TrelloAutomation
{
    class MyScript
    {
        static void MoveTodaysCards(Board board)
        {
            var lists = board.Lists;
            var today = DateTime.Now.DayOfWeek;
            var sourceList = lists.ListByName(today.ToString());
            var destList = lists.ListByName("Today");
            sourceList.MoveAllCards(destList);
        }
        

        static void Main(string[] args)
        {
            TrelloOps.Initialize();
            var board = new Board("566c9eb231c1dc186fe938fe");

            LabelUnfinishedCards(board);

            MoveTodaysCards(board);


            TrelloProcessor.Flush();

            Console.ReadLine();
        }

        private static void LabelUnfinishedCards(Board board)
        {
            List today = board.Lists.ListByName("Today");
            foreach(Card c in today.Cards)
            {
                //c.Labels.Add()
            }
        }
    }
}
