using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProgramSnake
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {

        public Settings()
        {
            InitializeComponent();
            SnakeSpeed.Value = Snake.Speed;
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ApplySettingButton_Click(object sender, RoutedEventArgs e)
        {
            Snake.Speed = (int)SnakeSpeed.Value;
            this.Close();
        }

        private void SnakeSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }




    }
}
