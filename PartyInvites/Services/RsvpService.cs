using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Services
{
    // Use Dependency Injection, static class ok for now
    public static class RsvpService
    {
        private static List<GuestResponse> responses = new List<GuestResponse>();

        public static List<GuestResponse> Responses
        {
            get
            {
                return responses;
            }
        }

        public static void AddResponse(GuestResponse response)
        {
            responses.Add(response);
        }
    }
}
