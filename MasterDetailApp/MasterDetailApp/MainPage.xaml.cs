using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpertPB
{
	public partial class MainPage : MasterDetailPage
	{
        Color NavColor = Color.BurlyWood;
        
		public MainPage()
		{
			InitializeComponent();

            Detail = new NavigationPage(new Shell())
            {
                BarBackgroundColor = NavColor
            };
		    IsPresented = true;

		}

        private void BtnShell_clk(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Shell())
            {
                BarBackgroundColor = NavColor
            };
            IsPresented = false;
        }

        private void BtnBottom_clk(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Bottom())
            {
                BarBackgroundColor = NavColor
            };
            IsPresented = false;
        }
    }
}
