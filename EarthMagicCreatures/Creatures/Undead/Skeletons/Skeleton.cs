﻿using EarthWithMagicAPI.API.Creature;
using EarthWithMagicAPI.API.Interfaces.Items;
using EarthWithMagicAPI.API.Stuff;
using System;

namespace EarthMagicCreatures.Creatures.Undead.Skeletons
{
    /// <summary>
    /// A undead but weak creature.
    /// </summary>
    public class Skeleton : ICreature
    {
        public Skeleton(CreatureAttributes attributes, CreatureAbilities abilities) : base(attributes, abilities, null, null, null)
        {
        }

        public override void EquipItem(IItem item)
        {
            throw new NotImplementedException();
        }

        public override bool IsHostile()
        {
            return true;
        }

        public override void OnCreatureDied(ICreature dead)
        {
        }

        public override void OnCreatureHealed(ICreature healer)
        {
        }

        public override void OnDealDamage()
        {
        }

        public override void OnItemUnequipped(IItem item)
        {
        }
    }
}