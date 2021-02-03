using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Exam_Wpf
{
    /// <summary>
    /// Interaction logic for Animated.xaml
    /// </summary>
    public partial class Animated : Window
    {
        public Animated()
        {
            InitializeComponent();
        }
        private void BtnClck4_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation aHeight1 = new DoubleAnimation();
            aHeight1.From = button1.ActualHeight;
            aHeight1.To = 160;
            aHeight1.Duration = TimeSpan.FromSeconds(5);
            aHeight1.AutoReverse = true;

            DoubleAnimation aHeight2 = new DoubleAnimation();
            aHeight2.From = button2.ActualHeight;
            aHeight2.To = 160;
            aHeight2.Duration = TimeSpan.FromSeconds(5);
            aHeight2.AutoReverse = true;

            DoubleAnimation aHeight3 = new DoubleAnimation();
            aHeight3.From = button3.ActualHeight;
            aHeight3.To = 160;
            aHeight3.Duration = TimeSpan.FromSeconds(4.5);
            aHeight3.AutoReverse = true;

            DoubleAnimation aHeight4 = new DoubleAnimation();
            aHeight4.From = button4.ActualHeight;
            aHeight4.To = 160;
            aHeight4.Duration = TimeSpan.FromSeconds(4);
            aHeight4.AutoReverse = true;

            DoubleAnimation aHeight5 = new DoubleAnimation();
            aHeight5.From = button5.ActualHeight;
            aHeight5.To = 160;
            aHeight5.Duration = TimeSpan.FromSeconds(3.5);
            aHeight5.AutoReverse = true;

            DoubleAnimation aHeight6 = new DoubleAnimation();
            aHeight6.From = button6.ActualHeight;
            aHeight6.To = 160;
            aHeight6.Duration = TimeSpan.FromSeconds(3);
            aHeight6.AutoReverse = true;

            DoubleAnimation aHeight7 = new DoubleAnimation();
            aHeight7.From = button7.ActualHeight;
            aHeight7.To = 160;
            aHeight7.Duration = TimeSpan.FromSeconds(2.5);
            aHeight7.AutoReverse = true;

            DoubleAnimation aHeight8 = new DoubleAnimation();
            aHeight8.From = button8.ActualHeight;
            aHeight8.To = 160;
            aHeight8.Duration = TimeSpan.FromSeconds(2);
            aHeight8.AutoReverse = true;

            DoubleAnimation aHeight9 = new DoubleAnimation();
            aHeight9.From = button9.ActualHeight;
            aHeight9.To = 160;
            aHeight9.Duration = TimeSpan.FromSeconds(1.5);
            aHeight9.AutoReverse = true;

            DoubleAnimation aHeight10 = new DoubleAnimation();
            aHeight10.From = button10.ActualHeight;
            aHeight10.To = 160;
            aHeight10.Duration = TimeSpan.FromSeconds(1);
            aHeight10.AutoReverse = true;

            button1.BeginAnimation(Button.HeightProperty, aHeight1);
            button2.BeginAnimation(Button.HeightProperty, aHeight2);
            button3.BeginAnimation(Button.HeightProperty, aHeight3);
            button4.BeginAnimation(Button.HeightProperty, aHeight4);
            button5.BeginAnimation(Button.HeightProperty, aHeight5);
            button6.BeginAnimation(Button.HeightProperty, aHeight6);
            button7.BeginAnimation(Button.HeightProperty, aHeight7);
            button8.BeginAnimation(Button.HeightProperty, aHeight8);
            button9.BeginAnimation(Button.HeightProperty, aHeight9);
            button10.BeginAnimation(Button.HeightProperty, aHeight10);


        }

        private void BtnClick5_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = Label1.Opacity;
            animation.To = 0.01;
            //animation.RepeatBehavior = RepeatBehavior.Forever;
            animation.Duration = new Duration(TimeSpan.FromSeconds(6));
            animation.AutoReverse = true;
            Label1.BeginAnimation(OpacityProperty, animation);

                      
        }
      
    }
}
