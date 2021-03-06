﻿using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;

namespace JD_XI_Editor.Models.Patches.Analog
{
    internal class LfoModControl : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of LfoModControl
        /// </summary>
        public LfoModControl()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            PitchModControl = 16;
            FilterModControl = 0;
            AmpModControl = 0;
            RateModControl = 18;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is LfoModControl modControl)
            {
                PitchModControl = modControl.PitchModControl;
                FilterModControl = modControl.FilterModControl;
                AmpModControl = modControl.AmpModControl;
                RateModControl = modControl.RateModControl;
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public void CopyFrom(byte[] data)
        {
            if (data.Length != DumpLength)
            {
                throw new InvalidDumpSizeException(DumpLength, data.Length);
            }

            PitchModControl = data[0] - 64;
            FilterModControl = data[1] - 64;
            AmpModControl = data[2] - 64;
            RateModControl = data[3] - 64;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) (PitchModControl + 64),
                (byte) (FilterModControl + 64),
                (byte) (AmpModControl + 64),
                (byte) (RateModControl + 64),
                (byte) 0x00,    // Reserve
                (byte) 0x00,    // Reserve
                (byte) 0x00,    // Reserve
                (byte) 0x00     // Reserve
            };
        }

        #region Properties

        public int DumpLength { get; } = 8;

        /// <summary>
        ///     Pitch modulation control
        /// </summary>
        public int PitchModControl { get; set; }

        /// <summary>
        ///     Filter modulation control
        /// </summary>
        public int FilterModControl { get; set; }

        /// <summary>
        ///     Amplifier modulation control
        /// </summary>
        public int AmpModControl { get; set; }

        /// <summary>
        ///     Rate modulation control
        /// </summary>
        public int RateModControl { get; set; }

        #endregion
    }
}