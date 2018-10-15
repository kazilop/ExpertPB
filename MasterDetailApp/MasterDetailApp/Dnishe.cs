using System;
using System.Text.RegularExpressions;

namespace MasterDetailApp
{
    public class Dnishe
    {
        public int TypeDn { set; get; }                      // тип днища
        public double P_davlen_Raschet { set; get; }         // давление расчетное
        public double T_Raschet { set; get; }                // температура расчетное
        public double Diametr { set; get; }                 // диаметр
        public double s_stenki { set; get; }                // толщина стенки
        public double H_dn { set; get; }                    // высота
        public int TypeSteel { set; get; }                  // тип стали
        public double Dop_Napr { set; get; }                // допустимое напряжение
        public double Pribavki { set; get; }                // сумма прибавок на коррозию
        public double Koeff_svarka { set; get; }            // Коэффициент прочности сварного шва
        public  double Radius_Kriv { set; get; }
        public double S_Raschet { set; get; }
        public double P_Dopust { set; get; }


        public void SetType(int typ)
        {
            if (typ == 0)
            {
                H_dn = Diametr / 4;
            }

            if (typ == 1)
            {
                H_dn = Diametr / 2;
            }
        }

        public void SetRadius()
        {
            if (Diametr > 0)
            {
                Radius_Kriv = Diametr * Diametr / (4 * H_dn);
            }
        }

        public void SetS()
        {
            S_Raschet = P_davlen_Raschet * Radius_Kriv / (2 * Dop_Napr * Koeff_svarka - P_davlen_Raschet / 2) + Pribavki;
            S_Raschet = Math.Round(S_Raschet, 2);
        }

        public void SetP()
        {
            P_Dopust = 2 * (s_stenki - Pribavki) * Koeff_svarka * Dop_Napr / (Diametr + (s_stenki - Pribavki) / 2);
            P_Dopust = Math.Round(P_Dopust, 2);
        }

    }
}