﻿using System;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.Store;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using MalClient.Shared.NavArgs;
using MalClient.Shared.Utils;
using MalClient.Shared.Utils.Enums;
using MalClient.Shared.ViewModels;
using MALClient.ViewModels;

#pragma warning disable 4014

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MALClient.UserControls
{ 

    public sealed partial class HamburgerControl : UserControl
    {
        public HamburgerControl()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            if(Settings.EnableHearthAnimation)
                SupportMeStoryboard.Begin();
        }

        private HamburgerControlViewModel ViewModel => (HamburgerControlViewModel) DataContext;


        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            ViewModel.UpdateProfileImg();
            ViewModel.SetActiveButton(Credentials.Authenticated
                ? (Settings.DefaultMenuTab == "anime" ? HamburgerButtons.AnimeList : HamburgerButtons.MangaList)
                : HamburgerButtons.LogIn);

            FeedbackImage.Source = Settings.SelectedTheme == ApplicationTheme.Dark
                ? new BitmapImage(new Uri("ms-appx:///Assets/GitHub-Mark-Light-120px-plus.png"))
                : new BitmapImage(new Uri("ms-appx:///Assets/GitHub-Mark-120px-plus.png"));
        }
    
        private async void Donate(object sender, RoutedEventArgs e)
        {
            try
            {
                var btn = sender as MenuFlyoutItem;
                await CurrentApp.RequestProductPurchaseAsync(btn.Tag as string, false);
                Settings.Donated = true;
            }
            catch (Exception)
            {
                // no donation
            }
        }

        private async void OpenRepo(object sender, RoutedEventArgs e)
        {
            Utilities.TelemetryTrackEvent(TelemetryTrackedEvents.LaunchedFeedback);
            await Launcher.LaunchUriAsync(new Uri("https://github.com/Mordonus/MALClient/issues"));
        }

        private void BtnProfile_OnClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel.PinnedProfiles.Count > 0)
                FlyoutBase.GetAttachedFlyout(BtnProfile).ShowAt(BtnProfile);
        }

        private void PinnedProfilesOnClick(object sender, ItemClickEventArgs e)
        {
            ViewModelLocator.GeneralMain.Navigate(PageIndex.PageProfile,
                new ProfilePageNavigationArgs { TargetUser = e.ClickedItem as string });
        }

        private async void LaunchFeedback(object sender, RoutedEventArgs e)
        {
            //if (Microsoft.Services.Store.Engagement.Feedback.IsSupported)
            //{
            //    Utilities.TelemetryTrackEvent(TelemetryTrackedEvents.LaunchedFeedbackHub);
            //    await Microsoft.Services.Store.Engagement.Feedback.LaunchFeedbackAsync();
            //}
            //else
            //{
            //    var msg = new MessageDialog("Feedback hub is not available on your device, update your OS in order to access it or create an issue on github :)", "Feedback hub unavailable");
            //    await msg.ShowAsync();
            //    OpenRepo(null, null);
            //}
        }
    }
}