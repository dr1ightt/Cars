using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.Domain.Enums
{
    public enum Model : byte
    {
        Sedan = 1,
        Hetchback,
        Sport,
        MiniVan,
        PickUp,
        Cupe

    }

    public enum Type : byte
    {
        Benzin = 1,
        Dizel,
        Hybride,
        Gas
    }
}
