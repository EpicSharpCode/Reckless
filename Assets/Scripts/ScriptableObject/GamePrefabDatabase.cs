using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Entities
{
    [CreateAssetMenu(fileName = "GamePrefabDatabase", menuName = "Reckless/Game Prefab Database")]
    public class GamePrefabDatabase : ScriptableObject
    {
        [SerializeField] HitPopup _hitPopup;

        public HitPopup hitPopupPrefab => _hitPopup;
    }
}