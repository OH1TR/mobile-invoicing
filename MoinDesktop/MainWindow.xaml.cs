using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MoinClasses;
using MoinClasses.Tables;
using System.ServiceModel;

namespace MoinDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /*
                Log.WriteLine("Stuff");
                var binding = new WebServices20.BindingExtenions.ClearUsernameBinding();
                binding.SetMessageVersion(System.ServiceModel.Channels.MessageVersion.Soap12WSAddressing10);                  
                var ServiceendPoint = new EndpointAddress(new Uri("http://localhost:2795"));
                */
                MoinWSRef.MoinWSClient c = new MoinWSRef.MoinWSClient();
                c.Endpoint.EndpointBehaviors.Add(new CustomEndpointBehavior());
                /*
                c.ClientCredentials.UserName.UserName = "admin";
                c.ClientCredentials.UserName.Password = "123";
                */
               
                //Customers cu = c.GetCurrentCustomer();
                MoinClasses.Tables.Users u = c.GetUsers("75cb1a81-8994-4a93-a3d6-be0d832ee365"); //cu.ID);
            }
            catch(Exception ex)
            {
                Log.Exception(ex);
            }
        }
    }
}
