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
    public static unsafe class GraphGraphSmesharix_FeaturesGraphAwake {
        // BURST ENABLE OPEN
        [BURST] private static void InnerMethodOnAwake_0_1001_SystemsCodeGenerator_Burst(uint dt, in World world, ref Unity.Jobs.JobHandle dependsOn, System.IntPtr* systems, safe_ptr<Unity.Jobs.JobHandle> dependencies
        ) {
            SystemContext systemContext = default;
            {
                systemContext = SystemContext.Create(dt, in world, dependencies[1]);
                ((ME.BECS.Players.PlayersSystem*)systems[3])->OnAwake(ref systemContext);
                dependencies[2] = Batches.Apply(systemContext.dependsOn, world.state);
            }
            // BURST ENABLE CLOSE
        }
        // BURST DISABLE OPEN
        private static void InnerMethodOnAwake_3_1001_SystemsCodeGenerator_NotBurst(uint dt, in World world, ref Unity.Jobs.JobHandle dependsOn, System.IntPtr* systems, safe_ptr<Unity.Jobs.JobHandle> dependencies
        ) {
            SystemContext systemContext = default;
            {
                systemContext = SystemContext.Create(dt, in world, dependencies[2]);
                ((Smesharix.Systems.ExampleSystem*)systems[4])->OnAwake(ref systemContext);
                dependencies[3] = Batches.Apply(systemContext.dependsOn, world.state);
            }
            dependencies[4] = dependencies[3];
            dependencies[6] = dependencies[4];
            dependencies[7] = dependencies[6];
            // BURST DISABLE CLOSE
        }
        // BURST ENABLE OPEN
        [BURST] private static void InnerMethodOnAwake_6_1001_SystemsCodeGenerator_Burst(uint dt, in World world, ref Unity.Jobs.JobHandle dependsOn, System.IntPtr* systems, safe_ptr<Unity.Jobs.JobHandle> dependencies
        ) {
            SystemContext systemContext = default;
            {
                systemContext = SystemContext.Create(dt, in world, dependencies[7]);
                ((ME.BECS.Transforms.TransformWorldMatrixUpdateSystem*)systems[1])->OnAwake(ref systemContext);
                dependencies[8] = Batches.Apply(systemContext.dependsOn, world.state);
            }
            dependencies[5] = dependencies[8];
            dependsOn = dependencies[5];
        }
        [AOT.MonoPInvokeCallback(typeof(SystemsStatic.OnAwake))]
        public static void GraphOnAwake_1001_SystemsCodeGenerator(uint dt, ref World world, ref Unity.Jobs.JobHandle dependsOn) {
            // Smesharix-FeaturesGraph
            var systems = (System.IntPtr*)GraphGraphSmesharix_FeaturesGraphInitialize.graphNodes1001_SystemsCodeGenerator.GetUnsafePtr();
            var dependencies = _makeArray<Unity.Jobs.JobHandle>(9, Constants.ALLOCATOR_TEMP, false);
            dependencies[1] = dependsOn;
            // BURST ENABLE CLOSE
            InnerMethodOnAwake_0_1001_SystemsCodeGenerator_Burst(dt, in world, ref dependsOn,  systems, dependencies
            
            );
            
            InnerMethodOnAwake_3_1001_SystemsCodeGenerator_NotBurst(dt, in world, ref dependsOn,  systems, dependencies
            
            );
            
            InnerMethodOnAwake_6_1001_SystemsCodeGenerator_Burst(dt, in world, ref dependsOn,  systems, dependencies
            
            );
            
            dependsOn = dependencies[5];
            // Dependencies scheme:
            // * dependsOn                        => dep1001_0_0         START                            [ SKIPPED ]
            // * Batches.Apply                    :  dep1001_0_0 => dep1001_3_0                           [  SYNC   ]
            // * dep1001_3_0                      => dep1001_3_0         ME.BECS.Players.PlayersSystem    [  BURST  ]
            // * Batches.Apply                    :  dep1001_3_0 => dep1001_4_0                           [  SYNC   ]
            // * dep1001_4_0                      => dep1001_4_0         Smesharix.Systems.ExampleSystem  [NOT BURST]
            // * dep1001_4_0                      => dep30_2_0           START                            [ SKIPPED ]
            // * dep30_2_0                        => dep30_4_0           ME.BECS.DestroyWithTicksSystem   [NOT BURST] - Method ME.BECS.IAwake was not found. Node skipped.
            // * dep30_4_0                        => dep30_0_0           ME.BECS.DestroyWithLifetimeSy... [NOT BURST] - Method ME.BECS.IAwake was not found. Node skipped.
            // * Batches.Apply                    :  dep30_0_0 => dep30_1_0                               [  SYNC   ]
            // * dep30_1_0                        => dep30_1_0           ME.BECS.Transforms.TransformW... [  BURST  ]
            // * EXIT dep1001_2_0 = dep30_1_0;
            // * EXIT dependsOn = dep1001_2_0;
            // * dependencies[5]                  => dependsOn       
        }
    }
     
}
