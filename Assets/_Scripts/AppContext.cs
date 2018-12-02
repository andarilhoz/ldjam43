using DefaultNamespace;
using Injection;
using UniRx;
using UnityEngine;
using _Scripts.Dataprovider;
using _Scripts.Models;
using _Scripts.Monobehaviours;


public class AppContext : MonoBehaviour, IInjectable
{
    private static Injector Injector = new Injector();
    public PlayerStatus PlayerStatus = new PlayerStatus();
    public GameConfig GameConfig;

    public static void Inject(object script)
    {
        Injector.Inject(script);
    }

    private void Awake()
    {

        Injector.Bind<GameConfig>(GameConfig);
        Injector.Bind<PlayerStatus>(PlayerStatus);
        Injector.Bind<AppContext>(this);
        Injector.Bind<FetchDialogoDataProvider>(new FetchDialogoDataProvider());
        Injector.PostBindings();
    }
}
