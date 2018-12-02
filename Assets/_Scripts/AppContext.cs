using Injection;
using UniRx;
using UnityEngine;
using _Scripts.Models;
using _Scripts.Monobehaviours;


public class AppContext : MonoBehaviour
{
    private static Injector Injector = new Injector();
    public PlayerStatus PlayerStatus = new PlayerStatus();

    public static void Inject(object script)
    {
        Injector.Inject(script);
    }

    private void Awake()
    {

        Injector.Bind<PlayerStatus>(PlayerStatus);
        
        
    }
}
