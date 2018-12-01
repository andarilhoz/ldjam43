using Injection;
using UniRx;

namespace _Scripts.Models
{
    [System.Serializable]
    public struct PlayerStatus : IInjectable
    {
        public IntReactiveProperty First;
        public IntReactiveProperty Second;
        public IntReactiveProperty Third;

        public PlayerStatus(IntReactiveProperty first, IntReactiveProperty second, IntReactiveProperty third) : this()
        {
            First = first;
            Second = second;
            Third = third;
        }
    }
}