using RimWorld;
using System;
using Verse;

namespace TimeLords
{
	// Token: 0x02000005 RID: 5
	public class DeathActionWorker_TimeLord : DeathActionWorker
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000020B4 File Offset: 0x000002B4
		public override void PawnDied(Corpse corpse)
		{
			float value = (float)corpse.InnerPawn.ageTracker.AgeBiologicalYears;
			float value2 = (float)corpse.InnerPawn.ageTracker.AgeChronologicalYears;
			Name name = corpse.InnerPawn.Name;
			Pawn_PlayerSettings playerSettings = corpse.InnerPawn.playerSettings;
			Pawn_TrainingTracker training = corpse.InnerPawn.training;
			Pawn_HealthTracker health = corpse.InnerPawn.health;
			Pawn_RecordsTracker records = corpse.InnerPawn.records;
			Pawn_RelationsTracker relations = corpse.InnerPawn.relations;
			Pawn_SkillTracker skills = corpse.InnerPawn.skills;
			Faction faction = corpse.InnerPawn.Faction;
			Comp_TimeLord timeLord = corpse.InnerPawn.TryGetComp<Comp_TimeLord>();
			if (timeLord!=null)
			{
				if (timeLord.TimesRegenerated<12)
				{
					timeLord.TimesRegenerated++;
					Pawn pawn = PawnGenerator.GeneratePawn(new PawnGenerationRequest(corpse.InnerPawn.kindDef, faction, PawnGenerationContext.NonPlayer, -1, false, false, false, false, true, false, 0f, false, false, false, false, false, false, false, false, 0, null, 1, null, null, null));
					GenSpawn.Spawn(pawn, corpse.Position, corpse.Map, Rot4.Random);
					pawn.Name = name;
					pawn.relations = relations;
					pawn.training = training;
					pawn.records = records;
					pawn.skills = skills;
					pawn.playerSettings = playerSettings;
					corpse.Destroy(0);
				}
			}

		}
	}
}
