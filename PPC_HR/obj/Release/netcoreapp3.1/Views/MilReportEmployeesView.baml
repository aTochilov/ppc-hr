   M S B A M L   `   `   `  ���� A  =PPC_HR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PPC_HR.ViewsPPC_HR.Views  )    #PPC_HR.Views.MilReportEmployeesView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:PPC_HR.Views     .���   � RowDefinitions  �� $��60 ��� $��* �.+��� -    ��Name$ PrintButton��$��0��$��1��$��Right=�$	��Top=�   CircleButton#���   $��0,5,25,5q�����  �� ImageSource$ /Views/print.png�� j� Stretch$ Uniform=�&   System.Windows.Controls.DataGrid  -     Name$ 
GridReport��$��1��   AutoGenerateColumns$ False�� � 	Resources   wordWrapStyle �� 
TargetType �� Property	 �� Value��%a   &	       �� " ��.���  � ��$
	 Wrap=���  � ��$	 Segoe UI)���  � ��$	 16(�.@�=  7System.Windows.Controls.Primitives.DataGridColumnHeader  
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 35    Header$ 	№
п/п��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *idx+  $
 200*    ElementStyle# [ $6 0Прізвище, ім'я, по-батькові�� �� *
personInfo+  $
 150* # [ $# Дата народження�� �� *	birthDate+  $
 200* # [ $% Військове звання�� �� *	milRank+  $
 200* # [ $` ZАдреса реєстрації місця проживання
(перебування)�� �� *emplAddress+  $
 200* # [ $ Посада�� �� *
position+