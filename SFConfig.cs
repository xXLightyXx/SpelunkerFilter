using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace SpelunkerFilter
{
	public partial class SFConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		public static SFConfig Instance => ModContent.GetInstance<SFConfig>();

		[DefaultValue(true)]
		public bool ApplyToMetalDetector { get; set; }

		[ReloadRequired]
		[DefaultValue(false)]
		public bool RemoveSparklingDust { get; set; }

		[Header("CustomFilter")]
		[BackgroundColor(220, 220, 220)]
		public List<TileDefinition> CustomWhitelist { get; set; } = new List<TileDefinition>();

		[BackgroundColor(30, 30, 30)]
		public List<TileDefinition> CustomBlacklist { get; set; } = new List<TileDefinition>();

		[Header("PresetFilterGroupToggles")]
		[BackgroundColor(30, 30, 200)]
		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(true)]
		public bool ToggleGems
		{
			get => Amethyst;
			set
			{
				Amethyst = value;
				Sapphire = value;
				Ruby = value;
				Emerald = value;
				Topaz = value;
				Diamond = value;
				AmberStoneBlock = value;
				ExposedGems = value;
			}
		}

		[BackgroundColor(30, 30, 200)]
		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(true)]
		public bool TogglePreHMMetalOres
		{
			get => Copper;
			set
			{
				Copper = value;
				Tin = value;
				Iron = value;
				Lead = value;
				Silver = value;
				Tungsten = value;
				Gold = value;
				Platinum = value;
			}
		}

		[BackgroundColor(30, 30, 200)]
		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(true)]
		public bool ToggleHMMetalOres
		{
			get => Cobalt;
			set
			{
				Cobalt = value;
				Palladium = value;
				Mythril = value;
				Orichalcum = value;
				Adamantite = value;
				Titanium = value;
			}
		}
	}
}
