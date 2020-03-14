using AlienRace;
using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Verse;

namespace TimeLords
{
    public class ExtendedTraitEntry
    {
        public TraitDef def = null;
        public int degree = 0;
        public float Chance = 1f;
        public bool replaceIfFull = true;
    }
    // Token: 0x02000241 RID: 577
    public class CompProperties_TimeLord : CompProperties
    {
        // Token: 0x06000FEE RID: 4078 RVA: 0x0005AFE0 File Offset: 0x000591E0
        public CompProperties_TimeLord()
        {
            this.compClass = typeof(Comp_TimeLord);
        }

    }
    // Token: 0x02000242 RID: 578
    public class Comp_TimeLord : ThingComp
    {
        public int TimesRegenerated = 0;
        public CompProperties_TimeLord Props
        {
            get
            {
                return (CompProperties_TimeLord)this.props;
            }
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref this.TimesRegenerated, "TimesRegenerated", 0);
        }
    }
}
