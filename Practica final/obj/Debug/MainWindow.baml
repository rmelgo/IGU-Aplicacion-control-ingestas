   M S B A M L   `   `   `  ����I  EPractica final, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9&clr-namespace:Practica_final;assembly=Practica_final  5   	       Practica_final.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   APractica_final&clr-namespace:Practica_final;assembly=     5   	     � Title$  Control de calorias��5   	   $	��570��6%   $
��1000��62   $	��500��6?   $	��285��6N    � Icon$ logo_calorias.png��6^   .��5
      � -   5         �Name$ elGrid��5
       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $	��10* �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��30 �6   .+�5   
   �� $��0��6   $��0��6$   $��2��61   ��5      �� 5       �� Color 5      �� 5       �� A$	 220��6     �� R$ 26��6(    �� G$ 32��6/   	 �� B$	 40��66   5      5      �� 5!   
   $��1��6   $��0��6$   $��2��61   $��4��6B   ��5"      �� 5#       5$      �� 5%      $	 220��6    $ 49��6(   $ 66��6/   $	 82��66   5'      5)      �� 5+   
   $��0��6   $��0��6"   $��2��62   .+�5,      �� -   5        $��image1��5,   #   $��0, 15q�6   $��UniformToFill=�61   $	��120��6I   $��logo_calorias.png��6U   �� 5.      
 �� Orientation$
 
Horizontal=�6   .+�5/      �� $��50��6   $��7��6(   ��50      �� 51       52      �� 53   "   $	 220��6(   $ 0��60   $ 80��66   $		 200��6=   55      57      �� 59      -   5        $��BotonIngesta��59      $��Añadir ingesta��6-   $	��200��6F   $��50��6R   $
��0, 2q�6^   $
��Left=�6l   $��0��6�   $��0q�6�   
�������$��Calibri)�6�   $��16(�6�   ��5:      �� 5;       5<      �� 5=      $ 0��6$   $ 80��6*   $	 0��61   5?      5A      5B      �� 5D      $
 
Horizontal=�6   .+�5E      �� $��50��6   $��7��6(   ��5F      �� 5G       5H      �� 5I   "   $	 220��6(   $ 0��60   $ 80��66   $		 200��6=   5K      5M      �� 5O      -   5        $��Ver detalle ingesta��5O      $	��200��67   $��50��6C   $��0��6O   $
��0, 2q�6_   $
��Left=�6m   $��0q�6�   
�������$��Calibri)�6�   $��16(�6�   ��5P      �� 5Q       5R      �� 5S   "   $ 0��6(   $ 80��6.   $	 0��65   5U      5W      5X      �� 5Z      $
 
Horizontal=�6   .+�5[      �� $��50��6   $��7��6(   ��5\      �� 5]       5^      �� 5_   "   $	 220��6(   $ 0��60   $ 80��66   $		 200��6=   5a      5c      �� 5e      -   5        $��Cargar datos��5e      $	��200��60   $��50��6<   $��0��6H   $
��0, 2q�6X   $
��Left=�6f   $��0q�6�   
�������$��Calibri)�6�   $��16(�6�   ��5f      �� 5g       5h      �� 5i   "   $ 0��6(   $ 80��6.   $	 0��65   5k      5m      5n      �� 5p      $
 
Horizontal=�6   .+�5q      �� $��50��6   $��7��6(   ��5r      �� 5s       5t      �� 5u   "   $	 220��6(   $ 0��60   $ 80��66   $		 200��6=   5w      5y      �� 5{      -   5        $��Guardar datos��5{      $	��200��61   $��50��6=   $��0��6I   $
��0, 2q�6Y   $
��Left=�6g   $��0q�6�   
�������$��Calibri)�6�   $��16(�6�   ��5|      �� 5}       5~      �� 5   "   $ 0��6(   $ 80��6.   $	 0��65   5�      5�      5�      �� 5�      $
 
Horizontal=�6   .+�5�      �� $��50��6   $��7��6(   ��5�      �� 5�       5�      �� 5�   "   $	 220��6(   $ 0��60   $ 80��66   $		 200��6=   5�      5�      �� 5�      -   5        $
��HTML��5�      $	��200��6(   $��50��64   $��0��6@   $
��0, 2q�6P   $
��Left=�6^   $��0q�6y   
�������$��Calibri)�6�   $��16(�6�   ��5�      �� 5�       5�      �� 5�   "   $ 0��6(   $ 80��6.   $	 0��65   5�      5�      5�      �� 5�      $
 
Horizontal=�6   .+�5�      �� -   5        $��RectaguloVolverPrincipal��5�      $��50��6<   $��7��6H   $y�Hidden=�6R   ��5�      �� 5�       5�      �� 5�   "   $	 220��6(   $ 0��60   $ 80��66   $		 200��6=   5�      5�      �� 5�      -	   5        $!��BotonVolverGraficoPrincipal��5�      $!��Volver al grafico principal��6<   $
��0, 2q�6b   $	��200��6p   $��50��6|   $��0q�6�   $��0��6�   $
��Left=�6�   
�������$��Calibri)�6�   $��16(�6�   $y�Hidden=�6'  ��5�      �� 5�       5�      �� 5�      $ 0��6$   $ 80��6*   $	 0��61   5�      5�      5�      �� 5�      $
 
Horizontal=�6   .+�5�      �� -
   5        $��RectaguloGraficoSectores��5�      $��50��6<   $��7��6H   $y�Hidden=�6R   ��5�      �� 5�       5�      �� 5�   "   $	 220��6(   $ 0��60   $ 80��66   $		 200��6=   5�      5�      �� 5�      -   5        $��BotonVerGraficoSectores��5�      $ ��Ver el grafico de sectores��68   $
��0, 2q�6]   $	��200��6k   $��50��6w   $��0q�6�   $��0��6�   $
��Left=�6�   
�������$��Calibri)�6�   $��16(�6�   $y�Hidden=�6  ��5�      �� 5�       5�      �� 5�   "   $ 0��6(   $ 80��6.   $	 0��65   5�      5�      5�      5�      �� 5�   
   -   5        $��Boton_derecha��5�      $��>��6&   $��3��62   $��20��6B   $��20��6N   {�.  6u   �� 5�   
   -   5        $��Boton_izquierda��5�      $��<��6(   $��2��67   $��20��6G   $��20��6S   {�.  6|   �� 5�   
   -   5         ��Name$ lienzoGrafico��5�      $��30, 0, 30, 20q�6(   $��1��6?   $��1��6O   $��4��6\   
�������5�      5�      5�      