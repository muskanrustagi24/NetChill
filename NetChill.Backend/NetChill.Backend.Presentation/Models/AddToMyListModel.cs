using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetChill.Backend.Presentation.Models
{
    public class AddToMyListModel
    {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
    }
}