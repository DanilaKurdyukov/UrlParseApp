   M S B A M L   `   `   `  ����F  BUrlParseApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:UrlParseAppUrlParseApp  5   	       UrlParseApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:UrlParseApp     5   	     � Title$4  .Подсчет количества тегов��5   	   $	��500��6*   $	��800��6:   $
��1000��6J   $
��1200��6Z   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgAllUrls��5         AutoGenerateColumns .     CanUserAddRows .  $��1��6Y   $��10q�6i      RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      ��  �� Property � �� �� Value
 �����63   	 �� Triggers	 5      �� 5      
 �� Binding
 6&   �� *ColorRecord+ �� Value	 Green6F   .a�5      ��  � ��
 � � �6;   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Значение URL��6!   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
UrlValue+  5      $% Количество тегов��6%    6?   �� *	CountTagA+5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� -   5         ��Name$ btnLoadData��5      $!��Загрузить файл��6D   �� 5       -   5        $ btnGetCount��5       $��Посчитать��6D   �� 5!      -   5        $ 	btnCancel��5!      $��Отмена��6@   �� 5"      -   5         ��Name$ tbCount��5"      $��10 10 10 10q�6)   $��16(�6>   � 5#      -   5         �Name$ pbCountProgress��5#      $	��300��63   $��10q�6?   $��30��6K    � Minimum$ 0Q�6W    � Maximum$ 3Q�6c    � Value$ 0Q�6o   5$      5%      5&      