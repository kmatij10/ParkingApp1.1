using System;
using System.Text.Json.Serialization;
using Protests.Data.Entities;

namespace Protests.Data.Models
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