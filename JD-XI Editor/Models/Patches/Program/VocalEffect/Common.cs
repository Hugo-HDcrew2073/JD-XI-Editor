﻿using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.Program.VocalEffect;

namespace JD_XI_Editor.Models.Patches.Program.VocalEffect
{
    internal class Common : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Common
        /// </summary>
        public Common()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            Level = 127;
            Panorama = 0;
            DelaySendLevel = 0;
            ReverbSendLevel = 0;
            OutputAssign = OutputAssign.Delay;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Common c)
            {
                Level = c.Level;
                Panorama = c.Panorama;
                DelaySendLevel = c.DelaySendLevel;
                ReverbSendLevel = c.ReverbSendLevel;
                OutputAssign = c.OutputAssign;
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

            Level = data[0];
            Panorama = data[1] - 64;
            DelaySendLevel = data[2];
            ReverbSendLevel = data[3];
            OutputAssign = (OutputAssign) data[4];
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Level,
                (byte) (Panorama + 64),
                (byte) DelaySendLevel,
                (byte) ReverbSendLevel,
                (byte) OutputAssign
            };
        }

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 5;

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     Panorama
        /// </summary>
        public int Panorama { get; set; }

        /// <summary>
        ///     Delay Send Level
        /// </summary>
        public int DelaySendLevel { get; set; }

        /// <summary>
        ///     Reverb Send Level
        /// </summary>
        public int ReverbSendLevel { get; set; }

        /// <summary>
        ///     Output Assign
        /// </summary>
        public OutputAssign OutputAssign { get; set; }

        #endregion
    }
}