using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetailApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Bottom : ContentPage
	{
		public Bottom ()
		{
			InitializeComponent ();

            Picker_typeDN.Items.Add("Эллиптическое днище");
		    Picker_typeDN.Items.Add("Полусферическое днище");
            Picker_typeDN.Items.Add("Торосферическое днище");
		    Picker_typeDN.Items.Add("Плоское днище");

		    Picker_typeDN.SelectedIndexChanged += picker_Selected;


            if (Picker_typeDN.SelectedIndex == 1)
		    {
		        Ellipse();
		    }

        }

        private void picker_Selected(object sender, EventArgs e)
        {
            if (Picker_typeDN.SelectedIndex == 0)
            {
                Ellipse();
            }

            if (Picker_typeDN.SelectedIndex == 1)
            {
                PoluEllipse();
            }


        }

        public void Ellipse()
        {
            PoluEllipse_DN.IsVisible = false;
            PoluEllipse_DN.IsEnabled = false;
	        Ellipse_DN.IsEnabled = true;
            Ellipse_DN.IsVisible = true;
	        
	    }

	    public void PoluEllipse()
	    {
	        PoluEllipse_DN.IsVisible = true;
	        PoluEllipse_DN.IsEnabled = true;
            Ellipse_DN.IsEnabled = false;
	        Ellipse_DN.IsVisible = false;

	    }


    }
}