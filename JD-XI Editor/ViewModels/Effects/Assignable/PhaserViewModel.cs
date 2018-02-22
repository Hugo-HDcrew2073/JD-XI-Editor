﻿using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Effects.Phaser;
using JD_XI_Editor.Models.Patches.Program.Effects.Effect2;

namespace JD_XI_Editor.ViewModels.Effects.Assignable
{
    internal class PhaserViewModel : Screen
    {
        /// <summary>
        ///     Phaser parameters
        /// </summary>
        public PhaserParameters PhaserParameters { get; }

        /// <summary>
        ///     Is Rate Mode Selected
        /// </summary>
        public bool IsRateModeSelected => PhaserParameters.Mode == Mode.Rate;

        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of PhaserViewModel
        /// </summary>
        public PhaserViewModel(PhaserParameters parameters)
        {
            PhaserParameters = parameters;

            PhaserParameters.PropertyChanged += (sender, args) =>
            {
                NotifyOfPropertyChange(nameof(IsRateModeSelected));
            };
        }
    }
}