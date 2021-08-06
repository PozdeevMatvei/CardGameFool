using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

namespace CardsDeck
{
    class Game : GameDesk, IComparer
    {      
        GameDesk gameDesk;
        public Game(GameDesk gameDesk) : base ()
        {
            this.gameDesk = gameDesk;
        }
        public int Compare(Object x, Object y)
        {
            return (new CaseInsensitiveComparer()).Compare(y, x);
        }        
               
        public void SkirmishPlayers(Player pAttack, Player pProtected)
        {
            Cards attack, protection = pProtected.Hand[pProtected.CountHand-1];
            List<Cards> desk;
            bool attackFlag = false;

            do
            {
                
                attack = pAttack.Attack(gameDesk, attackFlag);  // attackFlag                         
                if (protection != null)
                        protection = pProtected.Protection(attack);

                ShowSkirmish(attack, protection, pAttack, pProtected);            

                if (pProtected.CountHand == 0 || attack == null)
                    desk = gameDesk.EndMove(attack, protection, attackFlag, true);
                else
                {
                    desk = gameDesk.EndMove(attack, protection, attackFlag);
                }

                if (attack != null & protection == null)
                    attackFlag = true;

            } while (attack != null & pAttack.CountHand != 0 & pProtected.CountHand != 0);



            if (desk != null)
            {
                foreach (Cards deskCards in desk)
                    pProtected[pProtected.CountHand] = deskCards;
                pProtected.SortingCardsHand();
                gameDesk.EndMove(attack, protection,false, true);
            }
        }
        void ShowSkirmish(Cards attack, Cards protection, Player pAttack, Player pProtection)
        {
            Console.WriteLine("{0} attack card: ", pAttack.Name);
            if (attack != null) attack.Show();
            else Console.WriteLine("end attack");

            Console.WriteLine("{0} protection card: ", pProtection.Name);
            if (protection != null) protection.Show();
            else if (attack != null) Console.WriteLine("did not protection");
            else Console.WriteLine("end protection");

            Console.WriteLine("------------");
        }

    }
}
