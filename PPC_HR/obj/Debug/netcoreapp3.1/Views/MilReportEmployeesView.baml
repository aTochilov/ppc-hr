   M S B A M L   `   `   `  ����A  =PPC_HR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PPC_HR.ViewsPPC_HR.Views  5      )    #PPC_HR.Views.MilReportEmployeesView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:PPC_HR.Views     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $��60 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ PrintButton��5      $��0��6   $��1��63   $��Right=�6C   $	��Top=�6_      CircleButton#���   6w   $��0,5,25,5q�5      ��5      �� 5       �� ImageSource$ /Views/print.png��6    j� Stretch$ Uniform=�6<   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
GridReport��5       $��1��6      AutoGenerateColumns$ False��64    � 	Resources 5        wordWrapStyle �� 
TargetType �� Property	 �� Value��%�   &	       �� 5      " ��6.   .�5      ��  � ��$
	 Wrap=�65   �� 5       � ��$	 Segoe UI)�63   �� 5       � ��$	 16(�61   5      5      .@�5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader  
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 35 6=      Header$ 	№
п/п��6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *idx+6H     5      $
 200* 6D      ElementStyle# [ 6Q   $6 0Прізвище, ім'я, по-батькові��6    6%   �� *
personInfo+6     5      $
 150* 6C   # [ 6P   $# Дата народження��6~    6%   �� *	birthDate+6~     5       $
 200* 6A   # [ 6N   $% Військове звання��6|    6%   �� *	milRank+6|     5!      $
 200* 6E   # [ 6R   $` ZАдреса реєстрації місця проживання
(перебування)��6�    6%   �� *emplAddress+6�     5"      $
 200* 6B   # [ 6O   $ Посада��6}    6%   �� *
position+6}   5$      5&      5'      