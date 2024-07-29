using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Units.AI
{
    public class NpcSightAbility : NpcAbility
    {
        [SerializeField] float _sightAngle = 120;
        [SerializeField] List<Unit> _unitsInSight;
        [SerializeField] Vector3 _scanOffset;
        
        public List<Unit> unitsInSight => _unitsInSight;
        public override void PerformUpdate(Npc npc)
        {
            _unitsInSight = ScanForUnits(npc);
        }

        public List<Unit> ScanForUnits(Unit unit)
        {
            List<Unit> foundedUnits = new List<Unit>();
            for(float i = -_sightAngle/2; i < _sightAngle/2; i++)
            {
                var found = RaycastAngle(unit, i, true);
                if(found == null) continue;
                if(foundedUnits.Contains(found)) continue;
                foundedUnits.Add(found);
            }

            return foundedUnits;
        }

        public Unit RaycastAngle(Unit unit, float angle, bool debug = false)
        {
            var direction = Quaternion.AngleAxis(angle, unit.transform.up) * unit.transform.forward;
            var origin = unit.transform.position + _scanOffset;
            Ray ray = new Ray(origin, direction);
            if (debug)
            {
                Debug.DrawRay(origin, direction * 10, Color.red,1);
            }

            Physics.Raycast(ray, out RaycastHit raycastHit, 10);
            if (raycastHit.collider != null)
            {
                return raycastHit.collider.transform.GetComponentInParent<Unit>();
            }
            return null;
        }
    }
}
