using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlipView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var sampleData = new FlipView.SampleDataSource();
            FlipView4.ItemsSource = sampleData.Items;
            ContextControl.ItemsSource = sampleData.Items;
            ContextControl.SelectionChanged += ContextControl_SelectionChanged;
        }

        void ContextControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Make sure that the navigation buttons are updated by forcing focus to the FlipView
            FlipView4.Focus(Windows.UI.Xaml.FocusState.Pointer);
        }

        private void show_hide(object sender, RoutedEventArgs e)
        {
            //if (dates.Projection == PlaneProjection.GlobalOffsetYProperty)
            if (textBlock.Visibility == Visibility.Visible)
            {
                show_dates.Begin();
            }

            else if (textBlock.Visibility==Visibility.Collapsed)
            {
                hide_dates.Begin();
            }
            //
        }

        private void dates_sc(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = sender as ListView;
           
            if (Control.Visibility == Visibility.Visible)
            { 
                //wide screen 
            }

            else
            {
                //narrow screen
                dates.Visibility = Visibility.Collapsed;
                Control.Visibility = Visibility.Visible;
                Control.Margin = new Thickness(0);
                expand_dates.Visibility = Visibility.Visible;
            }
            
        }

        private void expand_d(object sender, RoutedEventArgs e)
        {
            dates.Visibility = Visibility.Visible;
            Control.Visibility = Visibility.Collapsed;
        }
    }
    }

