using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace timeclock_mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            
            //var status = Application.Current.Properties["status"]
            //Application.Current.Properties["Status"] = !status
            DisplayAlert("Success!", String.Format("Time is currently: {0}", DateTime.Now), "OK");
        }
    }
}
