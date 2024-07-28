using Reckless.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.Entities
{
    public interface IPickupable
    {
        void Pickup(Unit unit);
    }
}
