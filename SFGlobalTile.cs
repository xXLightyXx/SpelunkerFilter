using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace SpelunkerFilter
{
	public class SFGlobalTile : GlobalTile
	{
        public override bool? IsTileSpelunkable(int i, int j, int type)
        {
            var def = new TileDefinition(type);
            if (SFConfig.Instance.CustomWhitelist.Contains(def))
            {
                return true;
            }

            if (SFConfig.Instance.CustomBlacklist.Contains(def))
            {
                return false;
            }

            if (SpelunkerFilter.tileToDefaultFilterToggle.TryGetValue(type, out var toggle) && !toggle())
            {
                return false;
            }

            return base.IsTileSpelunkable(i, j, type);
        }
    }
}