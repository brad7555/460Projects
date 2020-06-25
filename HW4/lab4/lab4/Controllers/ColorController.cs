using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Drawing; 

namespace lab4.Controllers
{
    public class ColorController : Controller
    {
        // GET: Color
        [HttpGet]
        public ActionResult Index1()
          
        {
           ViewBag.Color1= Request["color1"];
            ViewBag.Color2 = Request["Color2"];
           
            return View();
        }

        [HttpPost]
        public ActionResult Index1(string color1, string color2, int? Numcol)
        {
           
            
            if (color1 == null || color2 == null || Numcol == 0)
            {
                return View();

            }
            else
            {
               
                List<EndC> Listcolors = new List<EndC>();
                Listcolors.Add(new EndC { Col = color1 });
                Color Start = ColorTranslator.FromHtml(color1);
                Color End = ColorTranslator.FromHtml(color2);

                ColorToHSV(Start, out double startH, out double startS, out double startV);
                ColorToHSV(End, out double endH, out double endS, out double endV);

                for (int i = 1; i < Numcol; i++)
                {
                    double dh = (endH - startH) / (Numcol.Value - 1);
                    double newH = startH + (i * dh);

                    double dS = (endS - startS) / (Numcol.Value - 1);
                    double newS = startS + (i * dS);

                    double dV = (endV - startV) / (Numcol.Value - 1);
                    double newV = startV + (i * dV);

                    Color colorConversion = ColorFromHSV(newH, newS, newV);
                    string htmlColor = ColorTranslator.ToHtml(colorConversion);

                    Listcolors.Add(new EndC { Col = htmlColor });

                    Start = ColorTranslator.FromHtml(htmlColor);

                    ColorToHSV(Start, out newH, out newS, out newV);

                }

                ViewBag.List = Listcolors;
                return View();
            }


            void ColorToHSV(Color color, out double hue, out double saturation, out double value)
            {
                int max = Math.Max(color.R, Math.Max(color.G, color.B));
                int min = Math.Min(color.R, Math.Min(color.G, color.B));

                hue = color.GetHue();
                saturation = (max == 0) ? 0 : 1d - (1d * min / max);
                value = max / 255d;
            }
            Color ColorFromHSV(double hue, double saturation, double value)
            {
                int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
                double f = hue / 60 - Math.Floor(hue / 60);

                value = value * 255;
                int v = Convert.ToInt32(value);
                int p = Convert.ToInt32(value * (1 - saturation));
                int q = Convert.ToInt32(value * (1 - f * saturation));
                int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

                if (hi == 0)
                    return Color.FromArgb(255, v, t, p);
                else if (hi == 1)
                    return Color.FromArgb(255, q, v, p);
                else if (hi == 2)
                    return Color.FromArgb(255, p, v, t);
                else if (hi == 3)
                    return Color.FromArgb(255, p, q, v);
                else if (hi == 4)
                    return Color.FromArgb(255, t, p, v);
                else
                    return Color.FromArgb(255, v, p, q);
            }

            
        }

        

        public struct EndC { 
        public string Col { get; set; }
        }
    }
}