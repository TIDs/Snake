using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgramSnake
{
    public class Circle
    {

        public int X { get; set; }
        public int Y { get; set; }
        public Circle()
        {
            X = 0;
            Y = 0;
        }

        public Circle(Point val)
        {
            X = (int)val.X;
            Y = (int)val.Y;
        }
        //public Circle(int p1, int p2)
        //{
        //    X = p1;
        //    Y = p2;
        //}
    }
}
