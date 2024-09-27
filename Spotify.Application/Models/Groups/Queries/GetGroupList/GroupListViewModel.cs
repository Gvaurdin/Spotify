using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Spotify.Application.Models.Groups.Queries.GetGroupList
{
    public class GroupListViewModel
    {
        public required IList<GroupLookUpDTO> Groups { get; set; }
    }
}
