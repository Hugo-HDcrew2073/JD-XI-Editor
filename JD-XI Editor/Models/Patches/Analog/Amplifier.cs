﻿using Caliburn.Micro;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Analog
{
    internal class Amplifier : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Amplifier
        /// </summary>
        public Amplifier()
        {
            Level = 127;
            LevelKeyfollow = 0;
            LevelVelSensitivity = 0;
            Envelope = new Adsr(0, 0, 127, 0);

            Envelope.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Envelope));
        }

        /// <inheritdoc />
        public void Reset()
        {
            Level = 127;
            LevelKeyfollow = 0;
            LevelVelSensitivity = 0;
            Envelope.Set(0, 0, 127, 0);
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Level,
                (byte) (LevelKeyfollow / 10 + 64),
                (byte) (LevelVelSensitivity + 64),
                (byte) Envelope.Attack,
                (byte) Envelope.Decay,
                (byte) Envelope.Sustain,
                (byte) Envelope.Release
            };
        }

        #region Fields

        /// <summary>
        ///     Level
        /// </summary>
        private int _level;

        /// <summary>
        ///     Level keyfollow
        /// </summary>
        private int _levelKeyfollow;

        /// <summary>
        ///     Level velocity sensitivity
        /// </summary>
        private int _levelVelSensitivity;

        #endregion

        #region Properties

        /// <summary>
        ///     Level
        /// </summary>
        public int Level
        {
            get => _level;
            set
            {
                if (value != _level)
                {
                    _level = value;
                    NotifyOfPropertyChange(nameof(Level));
                }
            }
        }

        /// <summary>
        ///     Level keyfollow
        /// </summary>
        public int LevelKeyfollow
        {
            get => _levelKeyfollow;
            set
            {
                if (value != _levelKeyfollow)
                {
                    _levelKeyfollow = value;
                    NotifyOfPropertyChange(nameof(LevelKeyfollow));
                }
            }
        }

        /// <summary>
        ///     Level velocity sensitivity
        /// </summary>
        public int LevelVelSensitivity
        {
            get => _levelVelSensitivity;
            set
            {
                if (value != _levelVelSensitivity)
                {
                    _levelVelSensitivity = value;
                    NotifyOfPropertyChange(nameof(LevelVelSensitivity));
                }
            }
        }

        /// <summary>
        ///     Envelope
        /// </summary>
        public Adsr Envelope { get; }

        #endregion
    }
}