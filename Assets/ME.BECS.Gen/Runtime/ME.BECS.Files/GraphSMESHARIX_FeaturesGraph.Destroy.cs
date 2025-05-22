namespace ME.BECS {
    using BURST = Unity.Burst.BurstCompileAttribute;
    using Unity.Collections;
    using Unity.Collections.LowLevel.Unsafe;
    using UnityEngine.Scripting;
    using Unity.Burst;
    using Unity.Jobs.LowLevel.Unsafe;
    using ME.BECS.Jobs;
    using static Cuts;
    using s = System.Collections.Generic;
    public static unsafe class GraphGraphSmesharix_FeaturesGraphDestroy {
        // BURST DISABLE OPEN
        private static void InnerMethodOnDestroy_0_1001_SystemsCodeGenerator_NotBurst(uint dt, in World world, ref Unity.Jobs.JobHandle dependsOn, System.IntPtr* systems, safe_ptr<Unity.Jobs.JobHandle> dependencies
        ) {
            SystemContext systemContext = default;
            {
                systemContext = SystemContext.Create(dt, in world, dependencies[2]);
                ((Smesharix.Systems.ExampleSystem*)systems[4])->OnDestroy(ref systemContext);
                dependencies[3] = Batches.Apply(systemContext.dependsOn, world.state);
            }
            dependencies[4] = dependencies[3];
            dependencies[6] = dependencies[4];
            dependencies[7] = dependencies[6];
            dependencies[8] = dependencies[7];
            dependencies[5] = dependencies[8];
            dependsOn = dependencies[5];
        }
        [AOT.MonoPInvokeCallback(typeof(SystemsStatic.OnDestroy))]
        public static void GraphOnDestroy_1001_SystemsCodeGenerator(uint dt, ref World world, ref Unity.Jobs.JobHandle dependsOn) {
            // Smesharix-FeaturesGraph
            var systems = (System.IntPtr*)GraphGraphSmesharix_FeaturesGraphInitialize.graphNodes1001_SystemsCodeGenerator.GetUnsafePtr();
            var dependencies = _makeArray<Unity.Jobs.JobHandle>(9, Constants.ALLOCATOR_TEMP, false);
            dependencies[1] = dependsOn;
            dependencies[2] = dependencies[1];
            // BURST DISABLE CLOSE
            InnerMethodOnDestroy_0_1001_SystemsCodeGenerator_NotBurst(dt, in world, ref dependsOn,  systems, dependencies
            
            );
            
            dependsOn = dependencies[5];
            // Dependencies scheme:
            // * dependsOn                        => dep1001_0_0         START                            [ SKIPPED ]
            // * dep1001_0_0                      => dep1001_3_0         ME.BECS.Players.PlayersSystem    [NOT BURST] - Method ME.BECS.IDestroy was not found. Node skipped.
            // * Batches.Apply                    :  dep1001_3_0 => dep1001_4_0                           [  SYNC   ]
            // * dep1001_4_0                      => dep1001_4_0         Smesharix.Systems.ExampleSystem  [NOT BURST]
            // * dep1001_4_0                      => dep30_2_0           START                            [ SKIPPED ]
            // * dep30_2_0                        => dep30_4_0           ME.BECS.DestroyWithTicksSystem   [NOT BURST] - Method ME.BECS.IDestroy was not found. Node skipped.
            // * dep30_4_0                        => dep30_0_0           ME.BECS.DestroyWithLifetimeSy... [NOT BURST] - Method ME.BECS.IDestroy was not found. Node skipped.
            // * dep30_0_0                        => dep30_1_0           ME.BECS.Transforms.TransformW... [NOT BURST] - Method ME.BECS.IDestroy was not found. Node skipped.
            // * EXIT dep1001_2_0 = dep30_1_0;
            // * EXIT dependsOn = dep1001_2_0;
            // * dependencies[5]                  => dependsOn       
        }
    }
     
}
