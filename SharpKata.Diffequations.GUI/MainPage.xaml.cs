using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409
using Windows.UI.Xaml.Shapes;

namespace SharpKata.Diffequations.GUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            DrawLine(0, 100, 0, 200);
            DrawLine(new Vector2(100, 100), new Vector2(200, 200));
        }

        public void DrawLine(Vector2 start, Vector2 stop)
        {
            DrawLine((int)start.X, (int)stop.X, (int)start.Y, (int)stop.Y);
        }

        public void DrawLine(int x0, int x1, int y0, int y1)
        {
            var line = new Windows.UI.Xaml.Shapes.Line
            {
                X1 = x0,
                X2 = x1,
                Y1 = y0,
                Y2 = y1,
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 3
            };
            canvas.Children.Add(line);
        }
    }
}
