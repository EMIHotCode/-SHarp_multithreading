   M S B A M L   `   `   `  ����  WpfApp5    WpfApp5.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��450��5   	   $	��800��6    � DataContext 5	   	   ��  �� RelativeSource �� *Self+.��5
      �� .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Введите число��6    �� Target 5      ��  �� ElementName$ ВводЧисла���� 5      -   5         ��Name$ ВводЧисла��5      $��50��5      �� 5      -   5         ��Name$ ButtonCalculate��5      $��Вычислить��5      5      �� 5      -   5        $ ButtonCancel��5      $��Отмена��5      5      5      �� 5   
   $ 
Horizontal=�6   .+�5      �� $��Факториал��6    5      �� $ FactorialOut���� 5      -   5        $ FactorialOut��5       �� 
IsReadOnly$
 True��5      $	��150��5      ��5      �� *	Factorial+5      � 5      -   5        	 �Name$	 ProgressFactorial��5      
 � Minimum$
 0Q�5       $	��300��5"       � Maximum 5!      �� $ ВводЧисла�� �� Path$
 Text�5"      5#      �� 5%   
   $ 
Horizontal=�6   .+�5&      �� $��
Сумма��6    5'      �� $ SumOut���� 5(      -   5        $ SumOut��5(      $	��150��5*      $
 True��5+      ��5)      �� *Sum+5+      � 5,      -   5        $	 ProgressSum��5,      $
 0Q�5-      $	��300��5/       5.      �� $ ВводЧисла��$
 Text�5/      50      51      52      