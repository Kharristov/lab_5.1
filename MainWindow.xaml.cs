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

namespace lab_5._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        private bool isDrawing;
        private Point lastPoint;
        private Color selectedColor;
        private double brushSize;
        public MainWindow()
        {
            InitializeComponent();
            InitializeEvents();
            selectedColor = Colors.Black; 
            brushSize = BrushSizeSlider.Value; 
        }
        private void InitializeEvents()
        {
            DrawingCanvas.MouseDown += DrawingCanvas_MouseDown;
            DrawingCanvas.MouseMove += DrawingCanvas_MouseMove;
            DrawingCanvas.MouseUp += DrawingCanvas_MouseUp;
            ColorComboBox.SelectionChanged += ColorComboBox_SelectionChanged;
            BrushSizeSlider.ValueChanged += BrushSizeSlider_ValueChanged;
        }

        private void ColorComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (ColorComboBox.SelectedIndex)
            {
                case 0: selectedColor = Colors.Black; break;
                case 1: selectedColor = Colors.Red; break;
                case 2: selectedColor = Colors.Green; break;
                case 3: selectedColor = Colors.Blue; break;
                case 4: selectedColor = Colors.Yellow; break;
            }
        }

        private void BrushSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            brushSize = e.NewValue;
        }

        private void DrawingCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DrawMode.IsChecked == true)
            {
                isDrawing = true;
                lastPoint = e.GetPosition(DrawingCanvas);
            }
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Point currentPoint = e.GetPosition(DrawingCanvas);
                Line line = new Line
                {
                    Stroke = new SolidColorBrush(selectedColor),
                    StrokeThickness = brushSize,
                    X1 = lastPoint.X,
                    Y1 = lastPoint.Y,
                    X2 = currentPoint.X,
                    Y2 = currentPoint.Y
                };
                DrawingCanvas.Children.Add(line);
                lastPoint = currentPoint;
            }
        }

        private void DrawingCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false;
            }
        }
    }
}