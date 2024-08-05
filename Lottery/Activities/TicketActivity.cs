using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Activities
{
    [Activity(Label = "TicketActivity")]
    public class TicketActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TicketView);

            var generateTicketButton = FindViewById<Button>(Resource.Id.generateTicketButton);
            var ticketTextView = FindViewById<TextView>(Resource.Id.ticketTextView);

            generateTicketButton.Click += (sender, e) =>
            {
                var ticket = GenerateRandomTicket();
                ticketTextView.Text = $"Ticket: {string.Join(", ", ticket)}";
                // Add logic to check if the ticket is a winner
            };
        }

        private int[] GenerateRandomTicket()
        {
            var random = new Random();
            var ticket = new int[6];
            for (int i = 0; i < ticket.Length; i++)
            {
                ticket[i] = random.Next(1, 60); // Assuming lottery numbers range from 1 to 59
            }
            return ticket;
        }
    }
}