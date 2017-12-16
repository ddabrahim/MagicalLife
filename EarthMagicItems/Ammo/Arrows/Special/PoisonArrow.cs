﻿namespace EarthMagicItems.Ammo.Arrows.Special
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EarthWithMagicAPI.API;
    using EarthWithMagicAPI.API.Util;

    /// <summary>
    /// A very basic poison arrow.
    /// </summary>
    public class PoisonArrow : GenericAmmo
    {
        public PoisonArrow()
            : base(new Die(1, 3, 0), "Poison Arrow", new Damage(Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero(), Die.Zero(), Die.Zero(), new Die(1, 8, 0), Die.Zero(), Die.Zero()),
            "EarthMagicDocumentation.ASCII_Art.Items.Ammo.Arrows.PoisonAcidArrow.txt",
            "EarthMagicDocumentation.Items.Ammo.Arrows.PoisonArrow.md", .21)
        {
        }
    }
}
