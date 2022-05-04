using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSW_lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            RGBController controller = new RGBController();
            RGB purple = new RGB(167, 60, 228);
            RGB light_blue = new RGB(0, 108, 255);

            controller.Initialize();

            Console.Write("Initialize: ");
            controller.Show();
            Console.Write('\n');

            Console.WriteLine("Purple: " + purple.ToString());
            Console.WriteLine("Lightblue: " + light_blue.ToString());

            Console.Write("Mixed: ");
            RGB mixed = controller.MixColors(purple, light_blue);
            controller.Show();
            Console.Write(" from RGBcontroller class's method show.\n");

            Console.WriteLine("Mixed: " + mixed.ToString() + " from RGB class's method ToString.");

            Console.ReadKey();
        }
    }
    class RGB
    {
        private int r_value;
        private int g_value;
        private int b_value;

        public int R_value { get => r_value; set => r_value = (value > 255) ? 255 : (value < 0) ? 0 : value; }
        public int G_value { get => g_value; set => g_value = (value > 255) ? 255 : (value < 0) ? 0 : value; }
        public int B_value { get => b_value; set => b_value = (value > 255) ? 255 : (value < 0) ? 0 : value; }

        public RGB()
        {
            r_value = 0;
            g_value = 0;
            b_value = 0;
        }
        public RGB(int red, int green, int blue)
        {
            R_value = red;
            G_value = green;
            B_value = blue;
        }
        public override string ToString() => "[" + R_value.ToString() + ", " + G_value.ToString() + ", " + B_value.ToString() + "]";
    }

    class RGBController
    {
        private RGB color;

        public void Initialize() => color = new RGB();

        public void Show() => Console.Write(color.ToString());

        public RGB MixColors(RGB first_color, RGB second_color)
        {
            color.R_value = (first_color.R_value + second_color.R_value);
            color.G_value = (first_color.G_value + second_color.G_value);
            color.B_value = (first_color.B_value + second_color.G_value);

            return color;
        }
    }
}
