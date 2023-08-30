using Fabrizio.Player;

namespace Fabrizio.Spawnables
{
    public interface IPlayerInjector
    {
        public void InjectPlayerBehaviour(PlayerBehaviour player);
    }
}