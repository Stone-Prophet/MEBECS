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
    public static unsafe class GraphGraphSmesharix_FeaturesGraphUpdate {
        // BURST DISABLE OPEN
        private static void InnerMethodOnUpdate_0_1001_SystemsCodeGenerator_NotBurst(uint dt, in World world, ref Unity.Jobs.JobHandle dependsOn, System.IntPtr* systems, safe_ptr<Unity.Jobs.JobHandle> dependencies
        ) {
            SystemContext systemContext = default;
            {
                systemContext = SystemContext.Create(dt, in world, dependencies[2]);
                ((Smesharix.Systems.ExampleSystem*)systems[4])->OnUpdate(ref systemContext);
                dependencies[3] = Batches.Apply(systemContext.dependsOn, world.state);
            }
            dependencies[4] = dependencies[3];
            // BURST DISABLE CLOSE
        }
        // BURST ENABLE OPEN
        [BURST] private static void InnerMethodOnUpdate_3_1001_SystemsCodeGenerator_Burst(uint dt, in World world, ref Unity.Jobs.JobHandle dependsOn, System.IntPtr* systems, safe_ptr<Unity.Jobs.JobHandle> dependencies
        ) {
            SystemContext systemContext = default;
            {
                systemContext = SystemContext.Create(dt, in world, dependencies[4]);
                ((ME.BECS.DestroyWithTicksSystem*)systems[2])->OnUpdate(ref systemContext);
                dependencies[6] = Batches.Apply(systemContext.dependsOn, world.state);
            }
            {
                systemContext = SystemContext.Create(dt, in world, dependencies[6]);
                ((ME.BECS.DestroyWithLifetimeSystem*)systems[0])->OnUpdate(ref systemContext);
                dependencies[7] = Batches.Apply(systemContext.dependsOn, world.state);
            }
            {
                systemContext = SystemContext.Create(dt, in world, dependencies[7]);
                ((ME.BECS.Transforms.TransformWorldMatrixUpdateSystem*)systems[1])->OnUpdate(ref systemContext);
                dependencies[8] = Batches.Apply(systemContext.dependsOn, world.state);
            }
            dependencies[5] = dependencies[8];
            dependsOn = dependencies[5];
        }
        [AOT.MonoPInvokeCallback(typeof(SystemsStatic.OnUpdate))]
        public static void GraphOnUpdate_1001_SystemsCodeGenerator(uint dt, ref World world, ref Unity.Jobs.JobHandle dependsOn) {
            // Smesharix-FeaturesGraph
            var systems = (System.IntPtr*)GraphGraphSmesharix_FeaturesGraphInitialize.graphNodes1001_SystemsCodeGenerator.GetUnsafePtr();
            var dependencies = _makeArray<Unity.Jobs.JobHandle>(9, Constants.ALLOCATOR_TEMP, false);
            dependencies[1] = dependsOn;
            dependencies[2] = dependencies[1];
            // BURST ENABLE CLOSE
            InnerMethodOnUpdate_0_1001_SystemsCodeGenerator_NotBurst(dt, in world, ref dependsOn,  systems, dependencies
            
            );
            
            InnerMethodOnUpdate_3_1001_SystemsCodeGenerator_Burst(dt, in world, ref dependsOn,  systems, dependencies
            
            );
            
            dependsOn = dependencies[5];
            // Dependencies scheme:
            // * dependsOn                        => dep1001_0_0         START                            [ SKIPPED ]
            // * dep1001_0_0                      => dep1001_3_0         ME.BECS.Players.PlayersSystem    [NOT BURST] - Method ME.BECS.IUpdate was not found. Node skipped.
            // * Batches.Apply                    :  dep1001_3_0 => dep1001_4_0                           [  SYNC   ]
            // * dep1001_4_0                      => dep1001_4_0         Smesharix.Systems.ExampleSystem  [NOT BURST]
            // * dep1001_4_0                      => dep30_2_0           START                            [ SKIPPED ]
            // * Batches.Apply                    :  dep30_2_0 => dep30_4_0                               [  SYNC   ]
            // * dep30_4_0                        => dep30_4_0           ME.BECS.DestroyWithTicksSystem   [  BURST  ]
            // * Batches.Apply                    :  dep30_4_0 => dep30_0_0                               [  SYNC   ]
            // * dep30_0_0                        => dep30_0_0           ME.BECS.DestroyWithLifetimeSy... [  BURST  ]
            // * Batches.Apply                    :  dep30_0_0 => dep30_1_0                               [  SYNC   ]
            // * dep30_1_0                        => dep30_1_0           ME.BECS.Transforms.TransformW... [  BURST  ]
            // * EXIT dep1001_2_0 = dep30_1_0;
            // * EXIT dependsOn = dep1001_2_0;
            // * dependencies[5]                  => dependsOn       
        }
    }
     
}
