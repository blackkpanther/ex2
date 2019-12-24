using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace dotNet5780_02_8338_2406
{
    class Host : IEnumerable
    {
        public long HostKey;
        public List<HostingUnit> HostingUnitCollection;
        public long HostKey1
        {
            get => HostKey;
            set => HostKey = value;
        }
        public List<HostingUnit> HostingUnitCollection1
        {
            get => HostingUnitCollection;
        }
        //constructor
        public Host(long h, int length)
        {
            this.HostKey = h;
            HostingUnitCollection = new List<HostingUnit>();
            for (int i = 0; i < length; i++)
                HostingUnitCollection.Add(new HostingUnit());
        }
        public override string ToString()
        {
            string s = "";
            s = "Host: " + HostKey;
            foreach (var h in HostingUnitCollection)
            {
                s = h.ToString() + "\n";
            }
            return s;
        }
        private long SubmitRequest(GuestRequest guestReq)
        {
            foreach (var h in HostingUnitCollection)
            {
                if (h.ApproveRequest(guestReq))
                    return h.HostingUnitKey;
            }
            return -1;
        }
        public int GetHostAnnualBusyDays()
        {
            int n = 0;
            foreach (var h in HostingUnitCollection)
                n += h.GetAnnualBusyDays();
            return n;
        }
        public void SortUnits()
        {
            this.HostingUnitCollection.Sort();
        }
        public bool AssignRequests(params GuestRequest[] guessTab)
        {
            foreach (GuestRequest gr in guessTab)
            {
                if (SubmitRequest(gr) != -1)
                {
                    return true;
                }
            }
            return false;
        }
        //indexer
        private HostingUnit returnHost(int i)
        {
            if (HostingUnitCollection.Count < i)
            {
                return null;
            }
            else
            {
                return HostingUnitCollection[i];
            }
        }
        public HostingUnit this[int i] => returnHost(i);
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)HostingUnitCollection).GetEnumerator();
        }
    }
}