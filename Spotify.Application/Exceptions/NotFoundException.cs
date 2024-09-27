using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Exceptions
{
    public class NotFoundException(string name, object key) : Exception($"Entity {name} ({key}) not found")
    {

    }
}
