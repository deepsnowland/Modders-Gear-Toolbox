using GearToolbox;
using MelonLoader;

namespace ModNamespace;
internal sealed class Implementations : MelonMod
{
	public override void OnInitializeMelon()
	{
		ToolboxUtils.LaunchGearToolbox();
    }
}
