﻿using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Universal;
using Microsoft.Xna.Framework;
using ProtoBuf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Data
{
    /// <summary>
    /// Holds a section of the world.
    /// </summary>
    [ProtoContract(IgnoreListHandling = true)]
    public class Chunk : Unique, IEnumerable<Tile>
    {
        [ProtoMember(1)]
        public List<Living> Creatures;

        [ProtoMember(2)]
        public ProtoArray<Tile> Tiles;

        [ProtoMember(3)]
        public Point ChunkLocation;

        /// <summary>
        /// The ID of what biome this chunk is generated by.
        /// </summary>
        [ProtoMember(4)]
        public string BiomeID;

        /// <summary>
        /// The width of this chunk in tiles.
        /// </summary>
        public static int Width = 15;

        /// <summary>
        /// The height of this chunk in tiles.
        /// </summary>
        public static int Height = 15;


        public Chunk(List<Living> creatures, ProtoArray<Tile> tiles, Point location, string biomeID) : base()
        {
            this.Creatures = creatures;
            this.Tiles = tiles;
            this.ChunkLocation = location;
            this.BiomeID = biomeID;
        }

        /// <summary>
        /// Returns the creature in the specified location.
        /// </summary>
        /// <param name="point">The location to search.</param>
        /// <param name="living"></param>
        /// <returns>Returns whether or not a creature was found in the specified location.</returns>
        public bool GetCreature(Point point, out Living living)
        {
            living = null;

            foreach (Living item in this.Creatures)
            {
                if (item.MapLocation == point)
                {
                    living = item;
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<Tile> GetEnumerator()
        {
            foreach (Tile item in this.Tiles)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
