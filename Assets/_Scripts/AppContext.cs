using Injection;
using UnityEngine;

namespace Monobehaviours
{
    public class AppContext : MonoBehaviour
    {
        private static Injector Injector = new Injector();


        public static void Inject(object script)
        {
            Injector.Inject(script);
        }

        private void Awake()
        {
        }
    }
}