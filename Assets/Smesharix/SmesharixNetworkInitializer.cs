using ME.BECS.Network;

namespace Smesharix {
    
    public class SmesharixNetworkInitializer : NetworkWorldInitializer 
    {
        public static SmesharixNetworkInitializer Instance;
        
        public static NetworkModule NetworkModule => Instance.networkModule;
        
        protected override void Awake() 
        {
            Instance = this;
            base.Awake();
        }

        protected override void DoWorldAwake()
        {
            world.parent = Instance.world;
            base.DoWorldAwake();
        }
    }
    
}