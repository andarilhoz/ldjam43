using Injection;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "LDJam43/GameConfig", order = 1)]
    public class GameConfig : ScriptableObject, IInjectable
    {
        public string UrlData;
        public string UrlArt;
    }
}