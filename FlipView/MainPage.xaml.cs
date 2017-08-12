using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FlipView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
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
    }

    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class SampleDataCommon : SDKTemplate.Common.BindableBase
    {
        private static Uri _baseUri = new Uri("ms-appx:///");

        public SampleDataCommon(String title, String type, String picture)
        {
            this._title = title;
            this._type = type;
            this._picture = picture;
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }

        private string _type = string.Empty;
        public string Type
        {
            get { return this._type; }
            set { this.SetProperty(ref this._type, value); }
        }

        private Uri _image = null;
        private String _picture = null;
        public Uri Image
        {
            get
            {
                return new Uri(SampleDataCommon._baseUri, this._picture);
            }

            set
            {
                this._picture = null;
                this.SetProperty(ref this._image, value);
            }
        }
    }

    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class SampleDataItem : SampleDataCommon
    {
        public SampleDataItem(String title, String type, String picture)
            : base(title, type, picture)
        {
        }

    }

    public class Pass
    {
        public Pass(string organasation, string gate, string seat, string origin, string origin_short, string dest, string dest_short, string flight_num, string board_time, string clas, string date, string passenger, String logo, String barcode)
        {

        }

        public string Organasation { get; set; }
        public string Gate { get; set; }
        public string Seat { get; set; }
        public string Origin { get; set; }
        public string Origin_Short { get; set; }
        public string Dest { get; set; }
        public string Dest_Short { get; set; }
        public string Flight_Num { get; set; }
        public string Board_Time { get; set; }
        public string Clas { get; set; }
        public string Date { get; set; }
        public string Passenger { get; set; }
    }

    /// <summary>
    /// Creates a collection of groups and items with hard-coded content.
    /// </summary>
    public sealed class SampleDataSource
    {
        private ObservableCollection<object> _items = new ObservableCollection<object>();
        public ObservableCollection<object> Items
        {
            get { return this._items; }
        }

        public SampleDataSource()
        {
            Items.Add(new Pass("hi!", null,null,null,null,null,null,null,null,null,null,null,null,null));
            
            Items.Add(new SampleDataItem("Cliff",
                    "item",
                    "Assets/Cliff.jpg"
                    ));
            Items.Add(new SampleDataItem("Grapes",
                    "item",
                    "Assets/Grapes.jpg"
                    ));
            Items.Add(new SampleDataItem("Osaka castel",
                   "item",
                   "Assets/594203.jpg"
                   ));
            Items.Add(new SampleDataItem("Rainier",
                    "item",
                    "Assets/Rainier.jpg"
                    ));
            Items.Add(new SampleDataItem("Sunset",
                    "item",
                    "Assets/Sunset.jpg"
                    ));
            Items.Add(new SampleDataItem("Sunset",
                    "item",
                    "Assets/Sunset2.jpg"
                    ));
            Items.Add(new SampleDataItem("Valley",
                    "item",
                    "Assets/Valley.jpg"
                    ));
                    
        }
    }
}

namespace SDKTemplate.Common
{
    /// <summary>
    /// Implementation of <see cref="INotifyPropertyChanged"/> to simplify models.
    /// </summary>
    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class BindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Multicast event for property change notifications.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Checks if a property already matches a desired value.  Sets the property and
        /// notifies listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">Name of the property used to notify listeners.  This
        /// value is optional and can be provided automatically when invoked from compilers that
        /// support CallerMemberName.</param>
        /// <returns>True if the value was changed, false if the existing value matched the
        /// desired value.</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property used to notify listeners.  This
        /// value is optional and can be provided automatically when invoked from compilers
        /// that support <see cref="CallerMemberNameAttribute"/>.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
