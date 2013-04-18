using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace MyInkPresenter
{
    /// <summary>
    /// 颜色单选按钮
    /// </summary>
    public partial class ColorRadioButton : RadioButton
    {
        //依赖属性:颜色选择器选中的颜色       
        public static readonly DependencyProperty CheckedColorProperty;
        static ColorRadioButton()
        {
            //注册依赖属性
           CheckedColorProperty =  DependencyProperty.Register("CheckedColor", typeof(Color), typeof(ColorRadioButton),new PropertyMetadata(OnCheckedColorChanged));
        }
        //依赖属性设置器（使其能在xaml中使用）
        public Color CheckColor
        {
            set { SetValue(CheckedColorProperty, value); }
            get { return (Color)GetValue(CheckedColorProperty); }
        }
        //依赖属性Changed事件
        private static void OnCheckedColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //根据选中颜色更改背景色
            SolidColorBrush lBrush = new SolidColorBrush((Color)e.NewValue);
            ColorRadioButton colorRadioButton = sender as ColorRadioButton;
            colorRadioButton.Background = lBrush;
        }
        public ColorRadioButton()
        {
            InitializeComponent();
        }
    }
}
