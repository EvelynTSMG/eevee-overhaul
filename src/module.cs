using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

using Fahrenheit.CoreLib;

namespace Fahrenheit.Modules.EeveeOverhaul;

public sealed record EeveeOverhaulModuleConfig : FhModuleConfig {
    [JsonConstructor]
    public EeveeOverhaulModuleConfig(string configName,
                               bool   configEnabled) : base(configName, configEnabled) {
    }

    public override bool TrySpawnModule([NotNullWhen(true)] out FhModule? fm) {
        fm = new EeveeOverhaulModule(this);
        return fm.ModuleState == FhModuleState.InitSuccess;
    }
}

public class EeveeOverhaulModule : FhModule {
    private readonly EeveeOverhaulModuleConfig  _module_config;

    public EeveeOverhaulModule(EeveeOverhaulModuleConfig moduleConfig) : base(moduleConfig) {
        _module_config = moduleConfig;

        _moduleState   = FhModuleState.InitSuccess;
    }
}
