using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reckless.UI
{
    public abstract class RL_UI_Screen : MonoBehaviour
    {
        [field:SerializeField] public string ScreenName { get; private set; }
    }
}
