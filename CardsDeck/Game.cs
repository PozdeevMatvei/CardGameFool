﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

namespace CardsDeck
{
    class Game : IComparer
    {      
        GameDesk gameDesk;
        public Game(GameDesk gameDesk)
        {
            this.gameDesk = gameDesk;
        }
        public int Compare(Object x, Object y)
        {
            return (new CaseInsensitiveComparer()).Compare(y, x);
        }        
               
        public void SkirmishPlayers(Player pAttack, Player pProtected)
        {
            Cards attack, protection;
            List<Cards> desk;

            do
            {
                attack = pAttack.Attack(gameDesk);                           
                protection = pProtected.Protection(attack);

                Console.WriteLine("{0} attack card: ", pAttack.Name);
                if (attack != null)  attack.Show();
                else Console.WriteLine("end attack");

                Console.WriteLine("{0} protection card: ",pProtected.Name);
                if (protection != null) protection.Show();
                else if (attack != null) Console.WriteLine("did not protection");
                else Console.WriteLine("end protection");

                Console.WriteLine("------------");

                if (pProtected.Hand == null || attack == null)
                    desk = gameDesk.EndMove(attack, protection, true);
                else
                    desk = gameDesk.EndMove(attack, protection);
            } while (attack != null & protection != null & 
                        pAttack.Hand != null & pProtected.Hand != null);


            if (desk != null)
            {
                foreach (Cards deskCards in desk)
                    pProtected[pProtected.CountHand] = deskCards;
            }
        }
        
    }
}
