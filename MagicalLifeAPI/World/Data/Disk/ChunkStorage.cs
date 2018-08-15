﻿using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Networking.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World.Data.Disk
{
    /// <summary>
    /// Knows how to load and save chunks from every dimension in the world.
    /// </summary>
    public class ChunkStorage
    {

        public ChunkStorage(string saveName)
        {

        }

        /// <summary>
        /// Saves a chunk to disk.
        /// </summary>
        /// <param name="chunk">The chunk to save.</param>
        /// <param name="dimensionID">The ID of the dimension the chunk belongs to.</param>
        public void SaveChunk(Chunk chunk, Guid dimensionID)
        {
            bool dimensionExists = WorldStorage.DimensionPaths.TryGetValue(dimensionID, out string path);

            if (!dimensionExists)
            {
                throw new DirectoryNotFoundException("Dimension save folder does not exist!");
            }

            using (FileStream fs = File.Create(path + chunk.ChunkLocation.ToString() + ".chunk"))
            {
                string serialized = Convert.ToBase64String(ProtoUtil.Serialize<Chunk>(chunk));

                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteAsync(serialized);
                }
            }
        }

        /// <summary>
        /// Loads a chunk from disk.
        /// </summary>
        /// <param name="chunkX">The x position of the chunk within the dimension.</param>
        /// <param name="chunkY">The y position of the chunk within the dimension.</param>
        /// <param name="dimensionID">The ID of the dimension that the chunk belongs to.</param>
        /// <returns></returns>
        public Chunk LoadChunk(int chunkX, int chunkY, Guid dimensionID)
        {
            return this.LoadChunk(new Point2D(chunkX, chunkY), dimensionID);
        }

        /// <summary>
        /// Loads a chunk from disk.
        /// </summary>
        /// <param name="chunkX">The x position of the chunk within the dimension.</param>
        /// <param name="chunkY">The y position of the chunk within the dimension.</param>
        /// <param name="dimensionID">The ID of the dimension that the chunk belongs to.</param>
        /// <returns></returns>
        public Chunk LoadChunk(Point2D chunkLocation, Guid dimensionID)
        {
            bool dimensionExists = WorldStorage.DimensionPaths.TryGetValue(dimensionID, out string path);

            if (!dimensionExists)
            {
                throw new DirectoryNotFoundException("Dimension save folder does not exist!");
            }

            using (StreamReader sr = new StreamReader(path + chunkLocation.ToString() + ".chunk"))
            {
                Task<string> serialized = sr.ReadToEndAsync();
                return ProtoUtil.Deserialize<Chunk>(serialized.Result);
            }
        }
    }
}