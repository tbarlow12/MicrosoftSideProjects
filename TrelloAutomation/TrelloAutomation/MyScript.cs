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
        static string PERSONAL_BOARD = "566c9eb231c1dc186fe938fe";
        static string WORK_BOARD = "5a54e29e078ed25a85b6a7ec";

        

        static void Main(string[] args)
        {
            RunScript(PERSONAL_BOARD);
            RunScript(WORK_BOARD);            
        }

        static void RunScript(string board_id)
        {
            TrelloOps.Initialize();
            var board = new Board(board_id);
            if(DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                board.Lists.ByName("Next Week").MoveAllCards(board.Lists.ByName("This Week"));
            }
            //LabelUnfinishedCards(board);
            ArchiveCompletedCards(board);
            MoveTodaysCards(board);
            TrelloProcessor.Flush();
        }


        static void MoveTodaysCards(Board board)
        {
            var lists = board.Lists;
            var today = DateTime.Now.DayOfWeek;
            var sourceList = lists.ByName(today.ToString());
            var destList = lists.ByName("Today");
            if(sourceList != null)
                sourceList.MoveAllCards(destList);
        }

        private static void ArchiveCompletedCards(Board board)
        {
            var completed = board.Lists.ByName("Completed");
            foreach(Card c in completed.Cards)
            {
                c.IsArchived = true;
            }
        }

        private static void LabelUnfinishedCards(Board board)
        {
            List today = board.Lists.ByName("Today");
            Label unfinished = board.Labels.ByName("Unfinished");
            foreach(Card c in today.Cards)
            {
                if (!c.HasLabel("Unfinished"))
                {
                    c.Labels.Add(unfinished);
                }
            }
        }

        private static void RemoveLabelFromList(Board board, List list, string labelName)
        {
            foreach(Card c in list.Cards)
            {
                if (c.HasLabel(labelName))
                {
                    var label = c.Labels.ByName(labelName);
                    c.Labels.Remove(label);
                }
            }
        }
    }
}
