using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Ink;

namespace MyInkPresenter
{
    public partial class MainPage : PhoneApplicationPage
    {
        //单个墨迹笔画
        private Stroke  currentStroke = null ;
        //收集墨迹的画板
        private RectangleGeometry rgBoard = null;
        private Color currentColor = Colors.Red ;
        StylusPointCollection myPointCollection = null;
        public MainPage()
        {
            InitializeComponent();
            InitPresenterComponent();
        }

        /// <summary>
        /// 初始化绘图板相关
        /// </summary>
        private void InitPresenterComponent()
        {
            rgBoard = new RectangleGeometry();
            rgBoard.Rect = new Rect(0, 0, myInkPresenter.ActualWidth, myInkPresenter.ActualHeight);
            myInkPresenter.Clip = rgBoard;

        }

        private void myInkPresenter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //捕获鼠标焦点
            myInkPresenter.CaptureMouse();
            myPointCollection = new StylusPointCollection();
            myPointCollection.Add(e.StylusDevice.GetStylusPoints(myInkPresenter)); 
            currentStroke = new Stroke(myPointCollection);
            //设置画笔属性
            currentStroke.DrawingAttributes.Color = currentColor;
            currentStroke.DrawingAttributes.Height = sliderThickness.Value;
            currentStroke.DrawingAttributes.Width = sliderThickness.Value;
            myInkPresenter.Strokes.Add(currentStroke);
        }

        private void myInkPresenter_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentStroke != null)
            {
                currentStroke.StylusPoints.Add(e.StylusDevice.GetStylusPoints(myInkPresenter));
            }

        }

        private void myInkPresenter_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            currentStroke = null; 
        }

        private void myInkPresenter_LostMouseCapture(object sender, MouseEventArgs e)
        {
            currentStroke = null; 
        }




        /// <summary>
        /// 颜色选择单选按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clrRBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (strokeDemo != null)
            {
                //获取选中颜色
                ColorRadioButton clrRBtn = (ColorRadioButton)sender;
                currentColor = clrRBtn.CheckColor;
                //更改画笔颜色
                SolidColorBrush lBrush = new SolidColorBrush(currentColor);
                strokeDemo.Fill = lBrush;
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            clrRBtn_Checked(this.green, new RoutedEventArgs());
        }


    }
}