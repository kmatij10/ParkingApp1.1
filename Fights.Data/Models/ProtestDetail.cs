using System;
using System.Text.Json.Serialization;
using Fights.Data.Entities;

namespace Fights.Data.Models
{
    public class ProtestDetail : Protest
    {
        public int StartsInDays {
            get {
                return (int)Math.Floor((this.StartsAt - DateTime.Now).TotalDays);
            }
        }
    }
}