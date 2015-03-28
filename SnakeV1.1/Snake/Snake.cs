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

    public class MoveEventArgs : EventArgs
    {
        public readonly Direction? msg;
        public MoveEventArgs(Direction? message)
        {
            Snake.SnakeDirection = msg = message;
        }
    }


    class Snake
    {

        public static Circle ApplePos = new Circle();
        public Snake() { Speed = 5; }
        public static Direction? SnakeDirection;
        public static int Speed { get; set; }
    }
}
