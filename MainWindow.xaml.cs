/* Elliott McArthur
 * May 27, 2019
 * Quadratic Challenge
 * Program olves quadratic equation and shows on graph
 */
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace U5Quadratic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int a;
        int b;
        int c;
        bool Vertex = false;

        public MainWindow()
        {
            InitializeComponent();
            Line line = new Line();
            line.StrokeThickness = 0.5;
            line.Stroke = Brushes.Black;
            line.X1 = 320;
            line.X2 = 320;
            line.Y1 = 50;
            line.Y2 = 450;
            canvas.Children.Add(line);


            Line line2 = new Line();
            line2.StrokeThickness = 0.5;
            line2.Stroke = Brushes.Black;
            line2.X1 = 120;
            line2.X2 = 520;
            line2.Y1 = 250;
            line2.Y2 = 250;
            canvas.Children.Add(line2);

            for (int i = 0; i < 41; i++)
            {
                Rectangle tick1 = new Rectangle();
                tick1.Height = 10;
                tick1.Width = 1;
                tick1.Fill = Brushes.Black;
                Canvas.SetLeft(tick1, 120 + i * 10);
                Canvas.SetTop(tick1, 245);
                canvas.Children.Add(tick1);

              
                Rectangle tick2 = new Rectangle();
                tick2.Height = 1;
                tick2.Width = 10;
                tick2.Fill = Brushes.Black;
                Canvas.SetLeft(tick2, 315);
                Canvas.SetTop(tick2, 50 + i * 10);
                canvas.Children.Add(tick2);

            }
        }

        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.RemoveRange(89, 6002);
            a = Convert.ToInt32(TextboxA.Text);
            b = Convert.ToInt32(TextboxB.Text);
            c = Convert.ToInt32(TextboxC.Text);

            double XVertex = (b * (-1) / (2 * a));
            double Zeros = (b * b) - (4 * a * c);
            double Delta = ((-b + Math.Sqrt(Zeros)) / (2 * a));
            double YVertex = (Math.Sqrt(Zeros) / (-4 * a));

            if (Convert.ToDouble(Zeros) < 0)
            {
    
                Vertex = true;
            }
            else if (Convert.ToDouble(Zeros) == 0)
            {
                lblOutput.Content = (Math.Round(Delta, 3)).ToString();
                Vertex = true;
            }
            else
            {
                lblOutput.Content = (" X1=" + Math.Round(Delta, 3)).ToString() + "\n X2=" + (Math.Round(Delta, 3));
                Vertex = true;
            }
            for (int i = -3000; i < 3000; i++)
            {
                createPoint(i);
            }
            if (Vertex == true)
            {
                lblOutput.Content += "\n Vertex: " + XVertex + ", " + YVertex;
            }
        }
        public void createPoint(int p)
        {
            Ellipse ellipsex = new Ellipse();
            ellipsex.Width = 2;
            ellipsex.Height = 2;
            ellipsex.Fill = Brushes.Black;
            Canvas.SetLeft(ellipsex, (p * 0.005) * 10 + 325);
            Canvas.SetTop(ellipsex, (250 - (((p * 0.005 * p * 0.005) * a + p * 0.005 * b + c) * 10)));
            canvas.Children.Add(ellipsex);


        }
    }
}
