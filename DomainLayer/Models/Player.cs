using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models
{
    public class player
    {
        public string Rank { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty; 
        public string Country { get; set; }=string.Empty;
        public string Rating { get; set; }= string.Empty;   
    }
}
