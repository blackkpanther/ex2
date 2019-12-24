using System;
using System.Collections.Generic;
using System.Text;

namespace dotNet5780_02_8338_2406
{
    class GuestRequest
    {

        private DateTime entryDate;
        private DateTime releaseDate;
        private bool isApproved;

       
        public DateTime EntryDate
        {
            get => entryDate;
            set => entryDate = value; }
        public bool IsApproved
        {
            get => isApproved;
            set => isApproved = false;
        }
        public DateTime ReleaseDate
        {
            get => releaseDate;
            set => releaseDate = value;
        }


        public override string ToString()
        {
            return " Entry Date: " + EntryDate + "\nRelease Date: " + ReleaseDate + "\nIs Approved: " + IsApproved;
        }






       
        

    }
}
