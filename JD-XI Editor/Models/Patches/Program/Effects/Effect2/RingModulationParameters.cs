﻿using System.Collections.Generic;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect2
{
    internal class RingModulationParameters : EffectParameters
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Ring Modulation Parameters
        /// </summary>
        public RingModulationParameters()
        {
            Reset();
        }

        /// <inheritdoc />
        public sealed override void Reset()
        {
            Frequency = 60;
            Sensitivity = 80;
            DryWetBalance = 50;
            Level = 127;
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4Packets(Frequency));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Sensitivity));
            bytes.AddRange(ByteUtils.NumberTo4Packets(DryWetBalance));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Level));
            bytes.AddRange(ByteUtils.Repeat4PacketsReserve(28));

            return bytes.ToArray();
        }

        #region Properties

        /// <summary>
        ///     Frequency
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        ///     Sensitivity
        /// </summary>
        public int Sensitivity { get; set; }

        /// <summary>
        ///     Dry/Wet Balance
        /// </summary>
        public int DryWetBalance { get; set; }

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        #endregion
    }
}