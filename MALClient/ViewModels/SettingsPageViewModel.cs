﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace MALClient.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public ObservableCollection<Tuple<AnimeListDisplayModes, string>> DisplayModes { get; } = new ObservableCollection<Tuple<AnimeListDisplayModes, string>>
        {
            new Tuple<AnimeListDisplayModes, string>(AnimeListDisplayModes.PivotPages, "Pages"), new Tuple<AnimeListDisplayModes, string>(AnimeListDisplayModes.IndefiniteList, "List"), new Tuple<AnimeListDisplayModes, string>(AnimeListDisplayModes.IndefiniteGrid, "Grid")
        };

        public Tuple<AnimeListDisplayModes, string> SelectedDefaultViewForWatching
        {
            get { return DisplayModes[(int)Settings.WatchingDisplayMode]; }
            set { Settings.WatchingDisplayMode = value.Item1; }
        }
        public Tuple<AnimeListDisplayModes, string> SelectedDefaultViewForCompleted
        {
            get { return DisplayModes[(int)Settings.CompletedDisplayMode]; }
            set { Settings.CompletedDisplayMode = value.Item1; }
        }
        public Tuple<AnimeListDisplayModes, string> SelectedDefaultViewForOnHold
        {
            get { return DisplayModes[(int)Settings.OnHoldDisplayMode]; }
            set { Settings.OnHoldDisplayMode = value.Item1; }
        }
        public Tuple<AnimeListDisplayModes, string> SelectedDefaultViewForDropped
        {
            get { return DisplayModes[(int)Settings.DroppedDisplayMode]; }
            set { Settings.DroppedDisplayMode = value.Item1; }
        }
        public Tuple<AnimeListDisplayModes, string> SelectedDefaultViewForPlanned
        {
            get { return DisplayModes[(int)Settings.PlannedDisplayMode]; }
            set { Settings.PlannedDisplayMode = value.Item1; }
        }
        public Tuple<AnimeListDisplayModes, string> SelectedDefaultViewForAll
        {
            get { return DisplayModes[(int)Settings.AllDisplayMode]; }
            set { Settings.AllDisplayMode = value.Item1; }
        }

        public bool LockDisplayMode
        {
            get { return Settings.LockDisplayMode; }
            set { Settings.LockDisplayMode = value; }
        }
    }
}