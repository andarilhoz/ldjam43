using Injection;
using UniRx;

namespace _Scripts.Models
{
    [System.Serializable]
    public struct PlayerStatus : IInjectable
    {
        public IntReactiveProperty Dinheiro;
        public IntReactiveProperty Amor;
        public IntReactiveProperty Saude;

        public PlayerStatus(IntReactiveProperty dinheiro, IntReactiveProperty amor, IntReactiveProperty saude) : this()
        {
            Dinheiro = dinheiro;
            Amor = amor;
            Saude = saude;
        }
    }
}