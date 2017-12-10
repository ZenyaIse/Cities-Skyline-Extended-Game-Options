﻿using ICities;
using ColossalFramework;

namespace ExtendedGameOptions
{
    public class OilAndOreResource : ResourceExtensionBase
    {
        public override void OnAfterResourcesModified(int x, int z, NaturalResource type, int amount)
        {
            if (amount >= 0) return;

            ExtendedGameOptionsSerializable o = Singleton<ExtendedGameOptionsManager>.instance.values;

            if (type == NaturalResource.Oil)
            {
                amount = amount * (10 - o.OilDepletionRate) / 10;
            }
            else if (type == NaturalResource.Ore)
            {
                amount = amount * (10 - o.OreDepletionRate) / 10;
            }

            if (amount != 0 && (type == NaturalResource.Oil || type == NaturalResource.Ore))
            {
                resourceManager.SetResource(x, z, type, (byte)(resourceManager.GetResource(x, z, type) - amount), false);
            }
        }
    }
}
