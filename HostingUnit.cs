using System;
using System.Collections.Generic;
using System.Text;

namespace dotNet5780_02_8338_2406
{
    class HostingUnit : IComparable<HostingUnit>
    {
        private static int stSerialKey;
        private readonly int hostingUnitKey;
        private bool[,] diary = new bool[11, 30];

        // Properties:
        public static int StSerialKey
        {
            get => stSerialKey;
            set => stSerialKey = value;
        }
        public int HostingUnitKey
        {
          get =>  hostingUnitKey;
        }
        
        public bool[,] Diary
        {
            get => diary;
            set => diary = value;
        }

        public override string ToString()
        {
            return ("Hosting Unit Key: " + HostingUnitKey + PrintDiary(Diary));
        }

        //func's:
        private static string PrintDiary(bool[,] Diary)
        {
            bool flag = true;
            string finalText = "";
            for (int i = 0; i < 12; i++)//a
            {
                for (int j = 0; j < 31; j++)
                {
                    if (Diary[i, j] == true && flag == true)
                    {
                       finalText+=(" From {0:00}/{1:00} To ", j + 1, i + 1);
                        flag = false;
                    }
                    if (Diary[i, j] == false && flag == false)
                    {
                       finalText+=("{0:00}/{1:00}.", j + 1, i + 1);
                        flag = true;
                    }
                }
            }
            return finalText;
        }
        public bool ApproveRequest(GuestRequest guestReq)
        {
            int duration = guestReq.ReleaseDate.Day - guestReq.EntryDate.Day;
            int day = guestReq.EntryDate.Day;
            int month = guestReq.EntryDate.Month;
            for (int i = 0; i < duration; ++i)
            {
                if ((day) > 31)
                {
                    day = 1;
                    month += 1;
                }

                 if (Diary[(month - 1) % 11, day - 1] == true)
                {
                    day++;
                    Console.WriteLine("The date you entered is Unavailable.");
                    return false;
                }
            }
            guestReq.IsApproved = true;
            day = guestReq.EntryDate.Day;
            month = guestReq.EntryDate.Month;
            Console.WriteLine("The date you entered is available. Order scheduled to {0:0}/{1:0}", day, month);
            for (int i = 0; i < duration; ++i)
            {
                if ((day) > 31)
                {
                    day = 1;
                    month += 1;
                }
                Diary[(month - 1) % 11, day - 1] = true;
                day++;
            }
            return true;

        }
        public int GetAnnualBusyDays()
        {

            int counter = 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {

                    if (Diary[i, j] == true)
                    {
                        counter++;
                    }
                }
            }
            return counter;

        }
        public float GetAnnualBusyPercentege()
        {
            return (GetAnnualBusyDays() / (float)(12 * 31)) * 100;
        }

            public int CompareTo(HostingUnit obj)
        {
            return GetAnnualBusyDays().CompareTo(obj.GetAnnualBusyDays());
        }
    }
}
