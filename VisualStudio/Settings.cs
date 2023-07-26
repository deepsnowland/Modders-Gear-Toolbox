using ModSettings;

namespace GearToolbox
{
    internal class Settings : JsonModSettings
    {
        internal static Settings instance = new Settings();

        
        [Section("Tools")]

        [Name("Disable Tape roll")]
        [Description("Disable tape roll spawns. Needs game restart.")]
        public bool noTape = false;

        [Section("Man-Made Materials")]

        [Name("Disable Battery")]
        [Description("Disable battery spawns. Needs game restart.")]
        public bool noBattery = false;

        [Name("Disable Ceramic Shards")]
        [Description("Disable ceramic shards spawns. Needs game restart.")]
        public bool noCeramic = false;

        [Name("Disable Scrap Paper")]
        [Description("Disable scrap paper spawns. Needs game restart.")]
        public bool noPaper = false;

        [Name("Disable Electronic Parts")]
        [Description("Disable electronic parts spawns. Needs game restart.")]
        public bool noElectronics = false;

        [Name("Disable Glass Shards")]
        [Description("Disable glass shards spawns. Needs game restart.")]
        public bool noGlass = false;

        [Name("Disable Gun Parts")]
        [Description("Disable gun parts spawns. Needs game restart.")]
        public bool noGunParts = false;

        [Name("Disable Nuts and Bolts")]
        [Description("Disable nuts and bolts spawns. Needs game restart.")]
        public bool noNNB = false;

        [Name("Disable Plastic Waste")]
        [Description("Disable plastic waste spawns. Needs game restart.")]
        public bool noPlastic = false;

        [Name("Disable String Bundle")]
        [Description("Disable string bundle spawns. Needs game restart.")]
        public bool noString = false;

        [Name("Disable Tarp sheet")]
        [Description("Disable tarp sheet spawns. Needs game restart.")]
        public bool noTarp = false;

        [Section("Harvestables")]

        [Name("Disable Broken Rifle")]
        [Description("Disable broken rifle spawns. Yields scrap metal, fir wood and gun parts. Needs game restart.")]
        public bool noRifle = false;

        [Name("Disable Nuts and Bolts Box")]
        [Description("Disable nuts and bolts box spawns. Yields scrap paper and nuts and bolts. Needs game restart.")]
        public bool noNNBB = false;

        [Section("Natural Materials")]

        [Name("Flint Chance")]
        [Description("Tweaks the chance of flint spawn. Flint is part of the stone spawners. Default 5%")]
        [Slider(0f, 20f, 201)]
        public float flintChance = 5f;

        [Name("Rock Chance")]
        [Description("Tweaks the chance of rock spawn. Rock is part of the stone spawners. Default 20%")]
        [Slider(0f, 30f, 301)]
        public float rockChance = 20f;

        [Section("Functionalities")]

        [Name("Disable Bone Fragments from Harvest")]
        [Description("Disable bone fragments loot when harvesting meat.")]
        public bool noBones = false;

        [Name("Disable Replenish Sewing Kits")]
        [Description("Disable replenishing sewing kits with string.")]
        public bool noReplenish = false;

        [Name("Disable Dismantling Guns")]
        [Description("Disable function to dismantle guns.")]
        public bool noDismantle = false;
    }
}
