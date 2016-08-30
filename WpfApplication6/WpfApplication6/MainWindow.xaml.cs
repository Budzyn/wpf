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

namespace WpfApp1
{
    public partial class Window1 : Window
    {

        const int i = 10;
        List<double[]> dataList = new List<double[]>();
        DrawingGroup drawingGroup = new DrawingGroup();



        public class CustomComboboxItem
        {
            public string NewItemName { get; set; }
            public string NewItemComment { get; set; }
        }

        public Window1()
        {
            InitializeComponent();
            comboBox1.Items.Add(new CustomComboboxItem { NewItemName = "9", NewItemComment = "9" });
            comboBox1.Items.Add(new CustomComboboxItem { NewItemName = "12", NewItemComment = "12" });
            comboBox1.Items.Add(new CustomComboboxItem { NewItemName = "14", NewItemComment = "14" });


            DataFill();
            Execute(); 

            image1.Source = new DrawingImage(drawingGroup);
        }

        void DataFill()
        {
            Random rnd = new Random();
            double[] graph = new double[i+1];


             for (int a = 0; a < graph.Length; a++)
             {
                 double dd=rnd.Next(10);
                 graph[a]=dd;
             }


            dataList.Add(graph);
        }


        void Execute()
        {
            BackgroundFun();    
            GridFun();          
            GraphFun();          
            MarkerFun();       
        }

        private void BackgroundFun()
        {
            GeometryDrawing geometryDrawing = new GeometryDrawing();

            RectangleGeometry rectGeometry = new RectangleGeometry();
            rectGeometry.Rect = new Rect(0, 0, 1, 1);
            geometryDrawing.Geometry = rectGeometry;

            geometryDrawing.Pen = new Pen(Brushes.Black, 0.005);
            geometryDrawing.Brush = Brushes.Beige;

            drawingGroup.Children.Add(geometryDrawing);
        }

        private void GridFun()
        {
            GeometryGroup geometryGroup = new GeometryGroup();


            for (int i = 1; i < 10; i++)
            {
                LineGeometry line = new LineGeometry(new Point(1.0, i * 0.1),
                    new Point(0.1, i * 0.1));
                geometryGroup.Children.Add(line);
            }
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = geometryGroup;

            geometryDrawing.Pen = new Pen(Brushes.Gray, 0.003);
            double[] dashes = { 1, 1, 1, 1, 1 };
            geometryDrawing.Pen.DashStyle = new DashStyle(dashes, .1);

            geometryDrawing.Brush = Brushes.Beige;

            drawingGroup.Children.Add(geometryDrawing);
        }

        private void GraphFun()
        {
            GeometryGroup geometryGroup = new GeometryGroup();
            for (int i = 0; i < dataList[0].Length - 1; i++)
            {
                LineGeometry line = new LineGeometry(
                    new Point((double)i / (double)i,
                        .5 - (dataList[0][i] / 2.0)),
                    new Point((double)(i + 1) / (double)i,
                        .5 - (dataList[0][i + 1] / 2.0)));
                geometryGroup.Children.Add(line);
            }

            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = geometryGroup;


            geometryDrawing.Pen = new Pen(Brushes.Blue, 0.005);

            drawingGroup.Children.Add(geometryDrawing);
        }

       
        private void MarkerFun()
        {
            GeometryGroup geometryGroup = new GeometryGroup();
            for (int i = 0; i <= 10; i++)
            {
                FormattedText formattedText = new FormattedText(
                String.Format("{0,7:F}", 0 *i+i),
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

            geometryDrawing.Brush = Brushes.LightGray;
            geometryDrawing.Pen = new Pen(Brushes.Gray, 0.003);

            drawingGroup.Children.Add(geometryDrawing);
        }

 
    }
}