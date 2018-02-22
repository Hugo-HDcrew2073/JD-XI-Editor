﻿using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Analog
{
    internal class Patch : PropertyChangedBase, IPatch
    {
        /// <inheritdoc />
        /// <summary>
        /// Creates new instance of AnalogPatch
        /// </summary>
        public Patch()
        {
            Name = "Init Tone";            
            Lfo = new Lfo();
            Oscillator = new Oscillator();            
            Filter = new Filter();
            Amplifier = new Amplifier();
            Common = new Common();
            LfoModControl = new LfoModControl();

            Lfo.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Lfo));
            Oscillator.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Oscillator));
            Filter.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Filter));
            Amplifier.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Amplifier));
            Common.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Common));
            LfoModControl.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(LfoModControl));
        }

        /// <inheritdoc />
        public void Reset()
        {
            Name = "Init Tone"; 
            Lfo.Reset();
            Oscillator.Reset();
            Filter.Reset();
            Amplifier.Reset();
            Common.Reset();
            LfoModControl.Reset();
        }

        /// <summary>
        /// Get patch byte data
        /// </summary>
        /// <returns></returns>
        public byte[] GetBytes()
        {
            var bytes = new List<byte>();

            var nameBytes = Encoding.ASCII.GetBytes(Name.Length > 12 ? Name.Substring(0, 12) : Name);
            bytes.AddRange(nameBytes);
            bytes.AddRange(ByteUtils.RepeatReserve(12 - nameBytes.Length, 0x20));

            bytes.Add(0x00);

            bytes.AddRange(Lfo.GetBytes());
            bytes.AddRange(Oscillator.GetBytes());
            bytes.AddRange(Filter.GetBytes());
            bytes.AddRange(Amplifier.GetBytes());
            bytes.AddRange(Common.GetBytes());
            bytes.AddRange(LfoModControl.GetBytes());

            bytes.AddRange(ByteUtils.RepeatReserve(4));

            return bytes.ToArray();
        }

        #region Fields

        /// <summary>
        ///     Patch name
        /// </summary>
        private string _name;

        /// <summary>
        ///     LFO
        /// </summary>
        private Lfo _lfo;

        /// <summary>
        ///     Oscillator
        /// </summary>
        private Oscillator _oscillator;

        /// <summary>
        ///     Filter (Low Pass)
        /// </summary>
        private Filter _filter;

        /// <summary>
        ///     Amplifier
        /// </summary>
        private Amplifier _amplifier;

        /// <summary>
        ///     Common
        /// </summary>
        private Common _common;

        /// <summary>
        ///     Lfo Mod Control
        /// </summary>
        private LfoModControl _lfoModControl;

        #endregion

        #region Properies
        
        /// <summary>
        ///     Patch name
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyOfPropertyChange(nameof(Name));
                }
            }
        }

        /// <summary>
        ///     LFO
        /// </summary>
        public Lfo Lfo
        {
            get => _lfo;
            set
            {
                if (value != _lfo)
                {
                    _lfo = value;
                    NotifyOfPropertyChange(nameof(Lfo));
                }
            }
        }

        /// <summary>
        ///     Oscillator
        /// </summary>
        public Oscillator Oscillator
        {
            get => _oscillator;
            set
            {
                if (value != _oscillator)
                {
                    _oscillator = value;
                    NotifyOfPropertyChange(nameof(Oscillator));
                }
            }
        }

        /// <summary>
        ///     Filter (Low Pass)
        /// </summary>
        public Filter Filter
        {
            get => _filter;
            set
            {
                if (value != _filter)
                {
                    _filter = value;
                    NotifyOfPropertyChange(nameof(Filter));
                }
            }
        }

        /// <summary>
        ///     Amplifier
        /// </summary>
        public Amplifier Amplifier
        {
            get => _amplifier;
            set
            {
                if (value != _amplifier)
                {
                    _amplifier = value;
                    NotifyOfPropertyChange(nameof(Amplifier));
                }
            }
        }

        /// <summary>
        ///     Common
        /// </summary>
        public Common Common
        {
            get => _common;
            set
            {
                if (value != _common)
                {
                    _common = value;
                    NotifyOfPropertyChange(nameof(Common));
                }
            }
        }

        /// <summary>
        ///     Lfo Mod Control
        /// </summary>
        public LfoModControl LfoModControl
        {
            get => _lfoModControl;
            set
            {
                if (value != _lfoModControl)
                {
                    _lfoModControl = value;
                    NotifyOfPropertyChange(nameof(LfoModControl));
                }
            }
        }

        #endregion
    }
}