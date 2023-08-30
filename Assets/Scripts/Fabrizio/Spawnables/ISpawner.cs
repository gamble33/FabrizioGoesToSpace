using Fabrizio.Spawning;

namespace Fabrizio.Spawnables
{
    public interface ISpawner
    {
        public void InjectSpawnBehaviour(SpawnBehaviour spawnBehaviour);
    }
}