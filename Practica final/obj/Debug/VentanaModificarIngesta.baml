   M S B A M L   `   `   `  ����I  EPractica final, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Practica_finalPractica_final  5   	   ,    &Practica_final.VentanaModificarIngesta   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Practica_final     5   	     � Title$  Modificar Ingesta��5   	   $	��450��6#   $	��800��60    � 
ResizeMode$ NoResize=�6<    � Icon$ logo_calorias.png��6R   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6!   $��8��61   ��5      �� 5       �� Color 5      �� 5       �� A$	 220��6     �� R$ 0��6(    �� G$	 122��6.   	 �� B$		 204��66   5       5"      �� 5#   
   $��0��6   $��1��6!   $��8��61   $��2��6B   ��5$      �� 5%       5&      �� 5'      $	 220��6    $ 15��6(   $ 15��6/   $	 15��66   5)      5+      �� 5-   
   $0��*Introduccion de las calorias de la ingesta��6   $��0��6E   $��1��6R   $��2��6b   $��Center=�6v   $��Center=�6�   $��20(�6�   
���z���6�   �� 5.   
   $��Introduccion de la fecha��6   $��0��63   $��0��6@   $��Center=�6P   $��Center=�6m   $��20(�6�   
��� ���6�   �� 5/   
   $��de la ingesta��6   $��0��6(   $��0��65   $��2��6E   $��Center=�6V   $��Center=�6s   $��20(�6�   
��� ���6�   (  "System.Windows.Controls.DatePicker  51   
   -   5        $��	CajaFecha��51      $��2��6&   $��0��63   $��Center=�6C   $	��Top=�6`   6x   &   System.Windows.Controls.Calendar  52   
   -   5        $��
Calendario��52      $��3��6%   $��0��62   $��4��6B   $��Center=�6S   $��Center=�6p   6�   �� 55   
   
���iii�$��1��6    $��1��6-   $��2��6=   	
 �� X1$
 25��6Q   	 �� Y1$ 40��6Y   	 �� X2$	 505��6a   	 �� Y2$ 40��6j   �� 56   
   -   5        $��CajaCaloriasDesayuno��56      $��Calorias desayuno��6.   $��1��6G   $��1��6T   $��2��6d   $��25, 16.5q�6x   $��0q�6�   
���iii�.��6)  ��57      �� 58       59      �� 5:      $ 0��6    $ 15��6&   $ 15��6-   $	 15��64   5<      .��5=   "   5>      �� 5A   
   
���iii�$��2��6    $��1��6-   $��2��6=   $
 25��6Q   $ 40��6Y   $	 505��6a   $ 40��6j   �� 5B   
   -   5        $��CajaCaloriasAperitivo��5B      $��Calorias aperitivo��6/   $��2��6I   $��1��6V   $��2��6f   $��25, 16.5q�6z   $��0q�6�   
���iii�.��6+  ��5C      �� 5D       5E      �� 5F      $ 0��6    $ 15��6&   $ 15��6-   $	 15��64   5H      .��5I   "   5J      �� 5M   
   
���iii�$��3��6    $��1��6-   $��2��6=   $
 25��6Q   $ 40��6Y   $	 505��6a   $ 40��6j   �� 5N   
   -   5        $��CajaCaloriasComida��5N      $��Calorias comida��6,   $��3��6C   $��1��6P   $��2��6`   $��25, 16.5q�6t   $��0q�6�   
���iii�.��6  ��5O      �� 5P       5Q      �� 5R      $ 0��6    $ 15��6&   $ 15��6-   $	 15��64   5T      .��5U   "   5V      �� 5Y   
   
���iii�$��4��6    $��1��6-   $��2��6=   $
 25��6Q   $ 40��6Y   $	 505��6a   $ 40��6j   �� 5Z   
   -   5        $��CajaCaloriasMerienda��5Z      $��Calorias merienda��6.   $��4��6G   $��1��6T   $��2��6d   $��25, 16.5q�6x   $��0q�6�   
���iii�.��6'  ��5[      �� 5\       5]      �� 5^      $ 0��6    $ 15��6&   $ 15��6-   $	 15��64   5`      .��5a   "   5b      �� 5e   
   
���iii�$��5��6    $��1��6-   $��2��6=   $
 25��6Q   $ 40��6Y   $	 505��6a   $ 40��6j   �� 5f   
   -   5        $��CajaCaloriasCena��5f      $��Calorias cena��6*   $��5��6?   $��1��6L   $��2��6\   $��25, 16.5q�6p   $��0q�6�   
���iii�.��6  ��5g      �� 5h       5i      �� 5j      $ 0��6    $ 15��6&   $ 15��6-   $	 15��64   5l      .��5m   "   5n      �� 5q   
   
���iii�$��6��6    $��1��6-   $��2��6=   $
 25��6Q   $ 40��6Y   $	 505��6a   $ 40��6j   �� 5r   
   -   5        $��CajaCaloriasOtros��5r      $��Calorias otros��6+   $��6��6A   $��1��6N   $��2��6^   $��25, 16.5q�6r   $��0q�6�   
���iii�.��6  ��5s      �� 5t       5u      �� 5v      $ 0��6    $ 15��6&   $ 15��6-   $	 15��64   5x      .��5y   "   5z      �� 5}   
   -	   5        $��CancelarIngesta��5}      $��Cancelar��6(   $��7��6;   $��1��6H   $	��120��6X   $��22��6d   
�������$��0q�6�   ��5~      �� 5       5�      �� 5�      $	 255��6    $ 40��6(   $ 40��6/   $	 40��66   5�      5�      �� 5�   
   -
   5        $��AceptarIngesta��5�      $��Aceptar��6'   $��7��69   $��2��6F   $	��120��6V   $��22��6b   
�������$��0q�6�   ��5�      �� 5�       5�      �� 5�      $	 255��6    $ 40��6(   $ 40��6/   $	 40��66   5�      5�      5�      5�      