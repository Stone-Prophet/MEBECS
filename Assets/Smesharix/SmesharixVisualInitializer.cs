using ME.BECS;
using Smesharix;

public class SmesharixVisualInitializer : WorldInitializer
{
  public static SmesharixVisualInitializer Instance;
        
  protected override void Awake() 
  {
    Instance = this;
    base.Awake();
  }

  protected override void DoWorldAwake()
  {
    world.parent = SmesharixNetworkInitializer.Instance.world;
    base.DoWorldAwake();
  }
}

