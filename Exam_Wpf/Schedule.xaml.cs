using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Globalization;


namespace Exam_Wpf
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : Window
    {
        //
        // Поля
        //
        const int countDot = 30;// Количество отрезков
        // Список для хранения данных
        List<double[]> dataList = new List<double[]>();
        // Или можно DoubleCollection data = new DoubleCollection();
        // Контейнер слоев рисунков
        DrawingGroup drawingGroup = new DrawingGroup();


        public Schedule()
        {
            InitializeComponent();

            DataFill();// Заполнение списка данными
            Execute(); // Заполнение слоев

            // Отображение на экране
            image1.Source = new DrawingImage(drawingGroup);

        }
        // Генерация точек графиков
        void DataFill()
        {
            double[] sin = new double[countDot + 1];
            double[] cos = new double[countDot + 1];

            for (int i = 0; i < sin.Length; i++)
            {
                double angle = Math.PI * 2 / countDot * i;
                sin[i] = Math.Sin(angle);
                cos[i] = Math.Cos(angle);
            }

            dataList.Add(sin);
            dataList.Add(cos);
        }
        // Послойное формирование рисунка в Z-последовательности
        void Execute()
        {
            BackgroundFun();    // Фон
            GridFun();          // Мелкая сетка
            SinFun();           // Строим синус линией
            CosFun();           // Строим косинус точками
            MarkerFun();        // Надписи
        }

        // Фон
        private void BackgroundFun()
        {
            // Создаем объект для описания геометрической фигуры
            GeometryDrawing geometryDrawing = new GeometryDrawing();

            // Описываем и сохраняем геометрию квадрата
            RectangleGeometry rectGeometry = new RectangleGeometry();
            rectGeometry.Rect = new Rect(0, 0, 1, 1);
            geometryDrawing.Geometry = rectGeometry;

            // Настраиваем перо и кисть
            geometryDrawing.Pen = new Pen(Brushes.Magenta, 0.005);// Перо рамки
            geometryDrawing.Brush = Brushes.SeaShell;// Кисть закраски

            // Добавляем готовый слой в контейнер отображения
            drawingGroup.Children.Add(geometryDrawing);
        }
        // Горизонтальная сетка
        private void GridFun()
        {
            // Создаем коллекцию для описания геометрических фигур
            GeometryGroup geometryGroup = new GeometryGroup();

            // Создаем и добавляем в коллекцию десять параллельных линий 
            for (int i = 1; i < 10; i++)
            {
                LineGeometry line = new LineGeometry(new Point(1.0, i * 0.1),
                    new Point(-0.1, i * 0.1));
                geometryGroup.Children.Add(line);
            }

            // Сохраняем описание геометрии
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = geometryGroup;

            // Настраиваем перо
            geometryDrawing.Pen = new Pen(Brushes.Gray, 0.003);
            double[] dashes = { 1, 1, 1, 1, 1 };// Образец штриха
            geometryDrawing.Pen.DashStyle = new DashStyle(dashes, -.1);

            // Настраиваем кисть 
            //geometryDrawing.Brush = Brushes.Beige;

            // Добавляем готовый слой в контейнер отображения
            drawingGroup.Children.Add(geometryDrawing);
        }
        // Строим синус линией
        private void SinFun()
        {
            // Строим описание синусоиды
            GeometryGroup geometryGroup = new GeometryGroup();
            for (int i = 0; i < dataList[0].Length - 1; i++)
            {
                LineGeometry line = new LineGeometry(
                    new Point((double)i / (double)countDot,
                        .5 - (dataList[0][i] / 2.0)),
                    new Point((double)(i + 1) / (double)countDot,
                        .5 - (dataList[0][i + 1] / 2.0)));
                geometryGroup.Children.Add(line);
            }

            // Сохраняем описание геометрии
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = geometryGroup;

            // Настраиваем перо
            geometryDrawing.Pen = new Pen(Brushes.Blue, 0.005);

            // Добавляем готовый слой в контейнер отображения
            drawingGroup.Children.Add(geometryDrawing);
        }
        // Строим косинус точками
        private void CosFun()
        {
            // Строим описание косинусоиды
            GeometryGroup geometryGroup = new GeometryGroup();
            for (int i = 0; i < dataList[1].Length; i++)
            {
                EllipseGeometry ellips = new EllipseGeometry(
                    new Point((double)i / (double)countDot,
                    .5 - (dataList[1][i] / 2.0)), 0.01, 0.01);
                geometryGroup.Children.Add(ellips);
            }

            // Сохраняем описание геометрии
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = geometryGroup;

            // Настраиваем перо
            geometryDrawing.Pen = new Pen(Brushes.Lime, 0.006);

            // Добавляем готовый слой в контейнер отображения
            drawingGroup.Children.Add(geometryDrawing);
        }

        // Надписи
        private void MarkerFun()
        {
            GeometryGroup geometryGroup = new GeometryGroup();
            for (int i = 0; i <= 10; i++)
            {
                FormattedText formattedText = new FormattedText(
                String.Format("{0,7:F}", 1 - i * 0.2),
                CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                new Typeface("Verdana"),
                0.05,
                Brushes.Black);

                formattedText.SetFontWeight(FontWeights.Bold);

                Geometry geometry = formattedText.BuildGeometry(new Point(-0.2, i * 0.1 - 0.03));
                geometryGroup.Children.Add(geometry);
            }

            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = geometryGroup;

            geometryDrawing.Brush = Brushes.DeepSkyBlue;
            geometryDrawing.Pen = new Pen(Brushes.Gray, 0.003);

            drawingGroup.Children.Add(geometryDrawing);
        }
    }
}


    

