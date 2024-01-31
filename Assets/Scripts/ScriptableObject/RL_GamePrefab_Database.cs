using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Reckless.Entities
{
    [CreateAssetMenu(fileName = "GamePrefabDatabase", menuName = "Reckless/Game Prefab Database")]
    public class RL_GamePrefab_Database : ScriptableObject
    {
        [FormerlySerializedAs("hitBoxPopup")]
        [SerializeField] RL_HitPopup hitPopup;

        public RL_HitPopup HitPopupPrefab => hitPopup;
    }
}