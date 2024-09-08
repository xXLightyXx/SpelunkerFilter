using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System.Collections.Generic;
using System.Linq;
using Terraria.Localization;
using System;

namespace SpelunkerFilter
{
	public class SpelunkerFilter : Mod
	{
        public const string presetFilterTooltipKey = $"Mods.{nameof(SpelunkerFilter)}.Configs.{nameof(SFConfig)}.DefaultFilterTooltip";

        public static Dictionary<int, Func<bool>> tileToDefaultFilterToggle;

        public override void Load()
        {
            Language.GetOrRegister(presetFilterTooltipKey);
        }

        public override void PostSetupContent()
        {
            //GenerateLogOutput();

            tileToDefaultFilterToggle = new()
            {
                //paste result of dictDefinition here
                { TileID.Pots, () => SFConfig.Instance.Pots },
                { TileID.DesertFossil, () => SFConfig.Instance.DesertFossil },
                { TileID.FossilOre, () => SFConfig.Instance.FossilOre },
                { TileID.Copper, () => SFConfig.Instance.Copper },
                { TileID.Tin, () => SFConfig.Instance.Tin },
                { TileID.Iron, () => SFConfig.Instance.Iron },
                { TileID.Lead, () => SFConfig.Instance.Lead },
                { TileID.Silver, () => SFConfig.Instance.Silver },
                { TileID.Tungsten, () => SFConfig.Instance.Tungsten },
                { TileID.Gold, () => SFConfig.Instance.Gold },
                { TileID.Platinum, () => SFConfig.Instance.Platinum },
                { TileID.Meteorite, () => SFConfig.Instance.Meteorite },
                { TileID.Containers, () => SFConfig.Instance.Containers },
                { TileID.FakeContainers, () => SFConfig.Instance.FakeContainers },
                { TileID.Containers2, () => SFConfig.Instance.Containers2 },
                { TileID.FakeContainers2, () => SFConfig.Instance.FakeContainers2 },
                { TileID.Heart, () => SFConfig.Instance.Heart },
                { TileID.ManaCrystal, () => SFConfig.Instance.ManaCrystal },
                { TileID.Cobalt, () => SFConfig.Instance.Cobalt },
                { TileID.Palladium, () => SFConfig.Instance.Palladium },
                { TileID.Mythril, () => SFConfig.Instance.Mythril },
                { TileID.Orichalcum, () => SFConfig.Instance.Orichalcum },
                { TileID.Adamantite, () => SFConfig.Instance.Adamantite },
                { TileID.Titanium, () => SFConfig.Instance.Titanium },
                { TileID.Chlorophyte, () => SFConfig.Instance.Chlorophyte },
                { TileID.DyePlants, () => SFConfig.Instance.DyePlants },
                { TileID.LifeFruit, () => SFConfig.Instance.LifeFruit },
                { TileID.Sapphire, () => SFConfig.Instance.Sapphire },
                { TileID.Ruby, () => SFConfig.Instance.Ruby },
                { TileID.Emerald, () => SFConfig.Instance.Emerald },
                { TileID.Topaz, () => SFConfig.Instance.Topaz },
                { TileID.Amethyst, () => SFConfig.Instance.Amethyst },
                { TileID.Diamond, () => SFConfig.Instance.Diamond },
                { TileID.MatureHerbs, () => SFConfig.Instance.MatureHerbs },
                { TileID.BloomingHerbs, () => SFConfig.Instance.BloomingHerbs },
                { TileID.Statues, () => SFConfig.Instance.Statues },
                { TileID.ExposedGems, () => SFConfig.Instance.ExposedGems },
                { TileID.Painting3X3, () => SFConfig.Instance.Painting3X3 },
                { TileID.Painting6X4, () => SFConfig.Instance.Painting6X4 },
                { TileID.Painting2X3, () => SFConfig.Instance.Painting2X3 },
                { TileID.Painting3X2, () => SFConfig.Instance.Painting3X2 },
                { TileID.AlphabetStatues, () => SFConfig.Instance.AlphabetStatues },
                { TileID.MushroomStatue, () => SFConfig.Instance.MushroomStatue },
                { TileID.CatBast, () => SFConfig.Instance.CatBast },
                { TileID.BoulderStatue, () => SFConfig.Instance.BoulderStatue },
                { TileID.AmberStoneBlock, () => SFConfig.Instance.AmberStoneBlock },
            };
        }

        //Ghetto Source Generator
        private void GenerateLogOutput()
        {
            List<int> types = new();
            //Vanilla only
            for (int i = 0; i < TileID.Count; i++)
            {
                if (!Main.tileSpelunker[i])
                {
                    continue;
                }
                types.Add(i);
            }

            //Things with no priority at the end
            types = types.OrderBy(i => Main.tileOreFinderPriority[i] > 0 ? Main.tileOreFinderPriority[i] : short.MaxValue).ToList();

            string configOutput = "\n[Header(\"PresetFilter\")]\n";
            string dictDefinition = "\n";
            foreach (var type in types)
            {
                string name = TileID.Search.GetName(type);
                configOutput += $"[DefaultValue(true)]\n[TooltipKey(\"$\" + SpelunkerFilter.presetFilterTooltipKey)]\npublic bool {name} " + "{ get; set; }\n\n";
                dictDefinition += "{ " + $"TileID.{name}, () => SFConfig.Instance.{name}" + " },\n";
            }

            Logger.Info(configOutput);
            Logger.Info(dictDefinition);
        }
    }
}
