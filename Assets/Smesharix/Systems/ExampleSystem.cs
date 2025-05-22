using ME.BECS;
using ME.BECS.Players;

namespace Smesharix.Systems
{
  public struct ExampleSystem: IAwake, IStart, IUpdate, IDestroy
  {
    public Config Config;
    public float Delay;
    
    private SystemLink<PlayersSystem> _playerSystemLink;

    public void OnAwake(ref SystemContext context)
    {
      var playerSystem = context.world.GetSystem<PlayersSystem>();
      _playerSystemLink = context.world.GetSystemLink<PlayersSystem>();

      var activePlayer = _playerSystemLink.Value.GetActivePlayer();
    }

    public void OnStart(ref SystemContext context)
    {
    }

    public void OnUpdate(ref SystemContext context)
    {
    }

    public void OnDestroy(ref SystemContext context)
    {
      
    }
  }
}