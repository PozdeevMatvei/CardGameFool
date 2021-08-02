using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public class GameDesk
    {
        List<Cards> desk;
        int length;

        public GameDesk()
        {
            desk = new List<Cards>();
            length = 0;
        }
        public List<Cards> Desk
        {
            get
            {
                return desk;
            }
            private set { }
        }
        public int Length { get { return length; } private set { } }

        public List<Cards> EndMove(Cards attack, Cards protection, bool endMove = false)
        {
            if(!endMove)
            {
                DeskAdd(attack);
                DeskAdd(protection);

                if(protection == null)
                {
                    List<Cards> buf = desk;
                    DeskClear();
                    return buf;
                }
                return null;
            }
            DeskClear();
            return desk;
        }
            
        void DeskClear()
        {
            desk.Clear();
            length = 0;
        }
        void DeskAdd(Cards card)
        {
            if(card != null)
            {
                desk.Add(card);
                length++;
            }    
        }

    }
}
