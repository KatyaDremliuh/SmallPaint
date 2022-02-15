using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SmallPaint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Brush Color { get; set; }
        public bool IsDraw { get; private set; }
        public double Thickness { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            IsDraw = false;
            Thickness = 1;
            Color = Brushes.Red;

            rbRed.IsChecked = true; // по умолчанию
        }

        private void btnClear_Click(object sender, RoutedEventArgs e) // очистка холста
        {
            gCanva.Children.Clear();
        }
        
        private void rbGreen_Checked(object sender, RoutedEventArgs e)
        {
            Color = Brushes.Green; // установить цвет пера
            currentColor.Fill = Color; // поставить этот цвет в кружочек
        }

        private void rbYellow_Checked(object sender, RoutedEventArgs e)
        {
            Color = Brushes.Yellow;
            currentColor.Fill = Color;
        }

        private void rbBlue_Checked(object sender, RoutedEventArgs e)
        {
            Color = Brushes.Blue;
            currentColor.Fill = Color;
        }

        private void rbRed_Checked(object sender, RoutedEventArgs e)
        {
            Color = Brushes.Red;
            currentColor.Fill = Color;
        }

        private void rbWhite_Checked(object sender, RoutedEventArgs e)
        {
            Color = Brushes.White;
            currentColor.Fill = Color;
        }

        private void rbBlack_Checked(object sender, RoutedEventArgs e)
        {
            Color = Brushes.Black;
            currentColor.Fill = Color;
        }

        private void sliderSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Thickness = sliderSize.Value; // установить толщину пера

            ((Slider)sender).SelectionEnd=e.NewValue; // изменять выделение слайдера
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IsDraw = true; // опустить перо
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsDraw = false; // поднять перо
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDraw) // если перо опущено
            {
                // проверяем находится ли мышка внутри пределов холста
                if ((e.GetPosition(gCanva).X < 0) || (e.GetPosition(gCanva).X > gCanva.Width))
                {
                    return;
                }
                if ((e.GetPosition(gCanva).Y < 0) || (e.GetPosition(gCanva).Y > gCanva.Height))
                {
                    return;
                }

                // если в пределах холста, то рисуем точку (эллипс)
                Ellipse O = new Ellipse();
                O.Width = Thickness; // установить толщину 
                O.Height = Thickness;
                O.Fill = Color; // текущий цвет
                O.Margin = 
                    new Thickness(e.GetPosition(gCanva).X - Thickness / 2, 
                        e.GetPosition(gCanva).Y - Thickness / 2, 0, 0); // центр под указателем мышки поставить

                gCanva.Children.Add(O); // добавить на холст
            }
        }


    }
}
