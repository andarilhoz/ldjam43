using DefaultNamespace;
using Injection;
using UniRx;
using UnityEngine;
using _Scripts.Core.Usecase;
using _Scripts.Dataprovider;
using _Scripts.Models;
using _Scripts.Monobehaviours;


public class AppContext : MonoBehaviour, IInjectable
{
    private static Injector Injector = new Injector();
    public PlayerStatus PlayerStatus = new PlayerStatus();
    public GameConfig GameConfig;

    private FetchDialogoDataProvider FetchDialogoDataProvider = new FetchDialogoDataProvider();
    public static void Inject(object script)
    {
        Injector.Inject(script);
    }

    private void Awake()
    {

        Injector.Bind<GameConfig>(GameConfig);
        Injector.Bind<PlayerStatus>(PlayerStatus);
        Injector.Bind<AppContext>(this);
        Injector.Bind<ImageProvider>(new ImageProvider());
        Injector.Bind<FetchDialogoDataProvider>(FetchDialogoDataProvider);
        Injector.Bind<GetDialogoUseCase>(new GetDialogoUseCase());
        Injector.PostBindings();
    }

    private void Start()
    {
        FetchDialogoDataProvider.Initialize();
    }
}
