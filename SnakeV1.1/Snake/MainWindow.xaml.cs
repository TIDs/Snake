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
    public partial class MainWindow : Window
    {
        public static System.Windows.Threading.DispatcherTimer dispTimer = new System.Windows.Threading.DispatcherTimer();

        public delegate void AddToArray();
        public delegate void NeedMove(object sender, EventArgs e);
        public static event NeedMove event_snakeAction;
        public static event AddToArray event_SnakeGrowing;
        
        public static bool need = true;
        public const int SnakeWidth = 20;

        private UInt64 CurrentScore;
        private readonly System.Collections.Generic.LinkedList<Circle> _snakeBody = new LinkedList<Circle>();
        private Direction? _previousDirection = null;
        private SolidColorBrush _colorSnakeBody = new SolidColorBrush(Colors.Black);
        private const ushort SIZE = 50;

        private Key PressedKey;



        public MainWindow()
        {
           
            new Snake();
            InitializeComponent();
            this.ResizeMode = System.Windows.ResizeMode.CanMinimize;
            new GameProperties();
            InitializeGame();
            dispTimer.Tick += Snake_Action;
        }

        public void Move()
        {
            if (GameProperties.GameOver != true)
            {
                Able(false);
                Point next = new Point();
                Circle tmp = new Circle();
                if ((Math.Abs(_snakeBody.First.Value.X - Snake.ApplePos.X) < SnakeWidth) && (Math.Abs(_snakeBody.First.Value.Y - Snake.ApplePos.Y) < SnakeWidth))
                    Eat();
                next.X = _snakeBody.First.Value.X;
                next.Y = _snakeBody.First.Value.Y;

                switch (Snake.SnakeDirection)
                {
                    case Direction.Up:
                        next.Y = _snakeBody.First.Value.Y - 10;
                        break;
                    case Direction.Down:
                        next.Y = _snakeBody.First.Value.Y + 10;
                        break;
                    case Direction.Right:
                        next.X = _snakeBody.First.Value.X + 10;
                        break;
                    case Direction.Left:
                        next.X = _snakeBody.First.Value.X - 10;
                        break;
                    default:
                        break;
                }

                _snakeBody.RemoveLast();
                _snakeBody.AddFirst(new Circle(next));

                //   Detect colission with body
                //if (SnakeBody.Count > 2)

                //for (var Jnode = SnakeBody.Last; Jnode != null; Jnode = Jnode.Previous)
                //{
                //    for (var Inode = SnakeBody.First; Inode != null; Inode = Inode.Next)
                //    {
                //        if (Inode.Value.X == Jnode.Value.X &&
                //           Inode.Value.Y == Jnode.Value.Y)
                //        {
                //            Die();
                //        }
                //    }
                //}
                if (_snakeBody.First.Value.X < 0 || _snakeBody.First.Value.Y < 0 ||
                    _snakeBody.First.Value.X >= gameCanvas.Width || _snakeBody.First.Value.Y >= gameCanvas.Height)
                {
                    Die();
                    _snakeBody.Clear();
                }
            }
            else Able(true);
        }

        public void Die()
        {
            GameProperties.GameOver = true;
            gameMessage.Visibility = Visibility.Visible;
            BitmapImage theImage = new BitmapImage
              (new Uri("game_over.jpg", UriKind.Relative));
            ImageBrush myImageBrush = new ImageBrush(theImage);
            gameMessage.Background = new SolidColorBrush(Colors.Red);
            gameMessage.Background = myImageBrush;

        }

        private void Able(bool able)
        {
            AboutItem.IsEnabled = SettingItemMenu.IsEnabled = able;

        }

        public void Snake_Action(object sender, EventArgs e)
        {
            dispTimer.Start();
            Move();
            RedrawSnakeObj();
        }

        public Point GetPosition(UIElement uiElement)
        {
            return Mouse.GetPosition(uiElement);
        }

        public void InitializeGame()
        {

            dispTimer.Interval = TimeSpan.FromMilliseconds(125.0 / Snake.Speed);

            GameProperties.GameOver = false;
            Snake.SnakeDirection = null;
            CurrentScore = 0;
            _snakeBody.Clear();
            //**@**  Add canvas for snake 
            Window rootWindow = Application.Current.MainWindow as MainWindow;
            gameCanvas.Height = gameCanvas.Width = 600;
            gameMessage.Width = gameCanvas.Width;
            gameMessage.Visibility = Visibility.Hidden;
            gameCanvas.Background = new SolidColorBrush(Colors.Gray);

            //**@

            Circle head = new Circle();    //Draw Start body part
            head.X = 32;
            head.Y = 48;
            _snakeBody.AddFirst(head);
            DrawBodyPart(32, 48, true);

            //**@@** Add function event
            event_snakeAction += Snake_Action;


            DrawApple(false);
        }

        public void DrawBodyPart(int x, int y, bool ItsHead)
        {
            Ellipse ell = new Ellipse();
            ell.Height = ell.Width = SnakeWidth;
            if (ItsHead)
                ell.Fill = Brushes.Green;
            else
                ell.Fill = Brushes.Black;
            Canvas.SetTop(ell, y);
            Canvas.SetLeft(ell, x);
            gameCanvas.Children.Add(ell);

            /*Add new part of body to LinkeList */
            //Snake.
        }

        private void Eat()
        {
            /*@Get new body part for snake*/
            Circle C = new Circle();
            C.X = _snakeBody.Last.Value.X;
            C.Y = _snakeBody.Last.Value.Y;
            /*  @*/
            _snakeBody.AddLast(C);
            CurrentScore += 100;
            Score.Content = "Score:" + CurrentScore;

            DrawApple(false);//Draw and Generate new apple
        }

        public void DrawApple(bool redraw)//need redraw or Generate new APPLE
        {
            Ellipse Ell = new Ellipse();
            Ell.Fill = Brushes.Red;
            Ell.Width = Ell.Height = SnakeWidth;

            if (!redraw)//
            {
                /***@ Get random point for Apple position*/
                Random rnd = new Random();
                int Px = 0, Py = 0;
                Px = rnd.Next(8, (int)gameCanvas.Height - 10);
                Py = rnd.Next(8, (int)gameCanvas.Height - 10);
                /*@***/
                Snake.ApplePos.X = Px;
                Snake.ApplePos.Y = Py;
                Canvas.SetTop(Ell, Py);//Set Apple on the gameCanvas
                Canvas.SetLeft(Ell, Px);
            }
            else
            {
                Canvas.SetTop(Ell, Snake.ApplePos.Y);//Set Apple on the gameCanvas
                Canvas.SetLeft(Ell, Snake.ApplePos.X);
            }
            gameCanvas.Children.Add(Ell);
        }

        public void Draw(Point point)
        {
            Ellipse rect = new Ellipse();
            rect.Height = rect.Width = SnakeWidth;
            rect.Fill = Brushes.Black;
            gameCanvas.Children.Add(rect);
            Canvas.SetTop(rect, point.Y * 10);
            Canvas.SetLeft(rect, point.X * 10);
        }

        public void RedrawSnakeObj()
        {
            gameCanvas.Children.Clear();
            for (var node = _snakeBody.First; node != null; node = node.Next)
            {
                if (node == _snakeBody.First)
                    DrawBodyPart((node.Value.X/*GameProperties.Width*/), (int)(node.Value.Y /*GameProperties.Height*/), true);//it's a head
                else
                    DrawBodyPart((node.Value.X/*GameProperties.Width*/), (int)(node.Value.Y /*GameProperties.Height*/), false);//it's not a head
            }
            //
            DrawApple(true);
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            PressedKey = e.Key;
            switch (e.Key)
            {
                case Key.Up: if (_previousDirection != Direction.Down)//Snake can't go back
                        event_snakeAction(this, new MoveEventArgs(Direction.Up));
                    break;
                case Key.Down: if (_previousDirection != Direction.Up)
                        event_snakeAction(this, new MoveEventArgs(Direction.Down));
                    break;
                case Key.Left: if (_previousDirection != Direction.Right)
                        event_snakeAction(this, new MoveEventArgs(Direction.Left));
                    break;
                case Key.Right: if (_previousDirection != Direction.Left)
                        event_snakeAction(this, new MoveEventArgs(Direction.Right));
                    break;
                default:
                    break;
            }
            _previousDirection = Snake.SnakeDirection;
        }

        private void SettingItemMenu_Click(object sender, RoutedEventArgs e)
        {
            StopGame();
            Settings newSettingWindow = new Settings();
            newSettingWindow.InitializeComponent();
            newSettingWindow.Owner = this;
            newSettingWindow.ShowInTaskbar = false;
            newSettingWindow.Show();

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)//About program,
        {
            MessageBox.Show("\t\tSnake\n\tAuthor : Sergiy Voychyk (TIDs)\n\t", "Author", MessageBoxButton.OK);
        }

        private void StopGame()
        {
            Snake.SnakeDirection = null;
        }

        private void StopStartButton_Click(object sender, RoutedEventArgs e)
        {
            StopGame();
            StopStartButton.Content = "Stop";

        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            gameCanvas.Children.Clear();
            InitializeGame();
        }


    }
}
