   M S B A M L   `   `   `  ���� F  Bpilot.SCADA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:pilot.SCADA.Viewspilot.SCADA.Views  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf &     pilot.SCADA.Views.TiledCheckView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:pilot.SCADA.Views     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     .��� .+���   �� CornerRadius$  5��
�������$��5q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ #F2F2F2��   ShadowDepth$ 10Q�   
BlurRadius$	 105Q�   Opacity$	 0.4Q�   	Direction$	 270Q�._�� $	��450��$	��250�� � ColumnDefinitions �� $��90 ��� .+��� $
��Left=�$	��Top=�$��	10,10,0,0q�.+���  �� Orientation$ 
Horizontal=�	 � ToolTip$	 序号��.+��� -   
 ��Name$
 tb_sensorId��$��14(����#3F4C5D���� *SensorModel.ID+�� $	��号��$��14(����#3F4C5D$��0,0,5,0q��� -   $
 tb_sensorName��$��14(�$
��Bold"����#3F4C5D$	 传感器名������ *SensorModel.Name+�� -   $
 tb_sensorType��$��14(�$
��Bold"����#3F4C5D$	 传感器类型������ *SensorModel.Type+�� -   $
 tb_sensorLocation��$��14(�$
��Bold"����#3F4C5D$	 安装位置������ *SensorModel.Location+�� $ 
Horizontal=�$	 是否启用��.+��� $��启用��$��14(����#3F4C5D$��0,0,5,0q��� -    ��Name$ ckb_use��{�.   d� 	IsChecked �� *SensorModel.Use+�� $
��Left=�$��Bottom=�$��	10,0,0,10q�.+��� $ 
Horizontal=�$	��Top=�$
��Left=�$	 阈值报警��.+��� $��20��$��20�����#EDFAF0$  5��._��� $	����$��../Assets/ttf/#iconfont)�
���  ��$��Center=�$��Center=��� -   $
 tb_alarm��$��HH��$��Center=����#7ADA95$��5,0,0,0q��� $ 
Horizontal=�$		 值��.+��� -   $
 tb_sensorValue��$��Right=����#3F4C5D$��12(����� *SensorValue+�� $��Right=����#3F4C5D$��12(����� *SensorModel.Unit+#  LiveCharts.Wpf.CartesianChart  $��10q�$��1��&   LiveCharts.Wpf.Charts.Base.Chart   DisableAnimations . $	 动态曲线��   	Hoverable .     DataTooltip Z�    Series   LiveCharts.Wpf.LineSeries    LiveCharts.Wpf.Series   Stroke �#3Bc8D7   Fill
 ����    PointGeometrySize$ 0Q�   LineSmoothness$ 0Q�   Values �� *Values+   AxisX   LiveCharts.Wpf.Axis     
ShowLabels .     AxisY    .    MinValue$ 0Q�   MaxValue$	 100Q�