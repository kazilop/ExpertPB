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
	public partial class Shell : ContentPage
	{
	    public static bool CorrectInput = true;
	    private double Tras = 20f; // Расчетная температура
	    private double D = 1000f; // Диаметр обечайки, мм
	    private double s = 10f;    // Толщина стенки, мм
	    private double Fi = 186f;  // Допустимое напряжение
	    private double c1 = 0f;    // прибавка на коррозию, мм
	    private double c2 = 0f;    //Компенсация минусового допуска c2
        private double c3 = 0f;    //Технологическая прибавка c3
	    private double Gamma = 1f; //Коэффициент прочности продольного сварного шва φр

	    private double Pras = 1f;
	    private double k = 0f; // коэф запаса
	    private double Sras = 0f;  // расчетная толщина стенки
	    private double Pdopust =0f;
	    private double REZ = 0f;
	    private double Zapas = 0f;

        public Shell ()
		{
			InitializeComponent ();
		}

        private void BtnRas_clk(object sender, EventArgs e)
        {
            CorrectInput = true;
            Scroll.ScrollToAsync(S_ras, ScrollToPosition.Start, true);
            try
            {
                Pras = Convert.ToDouble(P_ras.Text);

              //  Pras = Convert.ToDouble(P_ras.Text);
                Tras = Convert.ToDouble(T_ras.Text);
                D = Convert.ToDouble(D_obech.Text);
                s = Convert.ToDouble(s_obech.Text);
                Fi = Convert.ToDouble(Fi_dop.Text);
                s = Convert.ToDouble(s_obech.Text);
                c1 = Convert.ToDouble(pribavka.Text);
                Gamma = Convert.ToDouble(Svarnoy.Text);

                Pras = (Pras > 0) ? Pras : 2;
                Tras = (Tras > 0) ? Tras : 20;
                D = (D > 0) ? D : 1000;
                s = (s > 0) ? s : 10;
                Fi = (Fi > 0) ? Fi : 186;
                c1 = (c1 > 0) ? c1 : 0;
                Gamma = (Gamma > 0) ? Gamma : 1;

            }
            catch (Exception t)
            {
                // S_ras.Text = t.ToString();
                CorrectInput = false;
            }

            // Sр = p * D / (2 * [σ] * φр - p)
            if (CorrectInput == true)
            {
                try
                {
                    Sras = Pras * D / (2 * Fi * 1 - Pras);
                    Sras = Math.Round(Sras, 2);
                   // S_ras.Text = Sras.ToString();
                    S_ras.Text = String.Format("{0} мм", Sras);

                    //[p] = 2* [σ] * φр * (s - c) / (D + (s - c) ) = 
                    Pdopust = 2 * Fi * Gamma * (s - c1) / (D + (s - c1));
                    Pdopust = Math.Round(Pdopust, 2);
                    P_dop.Text = String.Format("{0} МПа", Pdopust);



                }
                catch (Exception t)
                {
                    S_ras.Text = t.ToString();
                }

                if (s >= Sras)
                {
                    StackL.BackgroundColor = Color.LightGreen;
                    Rezultat.Text = String.Format("Фактическая толщина стенки больше расчетной. {0} > {1}", s, Sras);
                }

                else
                {
                    StackL.BackgroundColor = Color.Red;
                    Rezultat.Text = String.Format("Фактическая толщина стенки меньше расчетной. {0} < {1}", s, Sras);
                }



                if (Pras < Pdopust)
                {
                    StackDavln.BackgroundColor = Color.LightGreen;
                    RezultatDavlenie.Text =
                        String.Format("Фактическое давление меньше допустимого {0} < {1}", Pras, Pdopust);
                }

                else
                {
                    StackDavln.BackgroundColor = Color.Red;
                    RezultatDavlenie.Text =
                        String.Format("Фактическое давление БОЛЬШЕ допустимого {0} > {1}", Pras, Pdopust);
                }

                ZapasProch.BackgroundColor = Color.LightBlue;
                Zapas = Math.Round(s /Sras,2);
                LabelZapas.Text = String.Format("Коэффициент запаса прочности стенки = {0}", Zapas);

            }
            else
            {
                DisplayAlert("Внимание", "Некоторые значения введены некорректно", "OK");
            }


            //   S_ras.Text = REZ.ToString();

            //Result.Text = (Convert.ToDouble(T_ras.Text) * Convert.ToDouble(P_ras.Text)).ToString();
        }

	    static double Conv2DBL(string s)
	    {
	        double rez = 0f;
	        bool isDbl = false;
            isDbl = Double.TryParse(s,out rez);

            if(isDbl==true)
	        return rez;
            else
            {
                rez = 0;
                CorrectInput = false;
                return rez;
            }

	    }
    }
}