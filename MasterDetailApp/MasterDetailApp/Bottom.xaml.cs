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
	    Dnishe DnEll = new Dnishe()
	    {
	        TypeDn = 0,
	        P_davlen_Raschet = 1f,
	        T_Raschet = 20f,
	        Diametr = 1000f,
	        s_stenki = 10f,
	        Dop_Napr = 154f,
	        Pribavki = 1.5f,
	        Koeff_svarka = 1
	    };


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

	    private void EllipseCLK(object sender, EventArgs e)
	    {
	        DnEll.SetType(0);
	        DnEll.SetRadius();
	        DnEll.SetS();
	        DnEll.SetP();

	        EllText.Text = String.Format("{0} МПа", DnEll.P_Dopust);
	        EllText2.Text = String.Format("{0} мм", DnEll.S_Raschet);
        }



        public void PoluEllipse()
	    {
	        PoluEllipse_DN.IsVisible = true;
	        PoluEllipse_DN.IsEnabled = true;
            Ellipse_DN.IsEnabled = false;
	        Ellipse_DN.IsVisible = false;
	        DnEll.TypeDn = 1;

        }


    }
}