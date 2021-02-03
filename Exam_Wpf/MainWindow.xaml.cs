using System;
using System.Windows;
using System.Windows.Controls;


namespace Exam_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Animated animatedWindow = new Animated();
            animatedWindow.Owner = this;
            animatedWindow.Show();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Canvas canvasWindow = new Canvas();
            canvasWindow.Owner = this;
            canvasWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Schedule scheduleWindow = new Schedule();
            scheduleWindow.Owner = this;
            scheduleWindow.Show();
        }
    }
}
