   M S B A M L   `   `   `  ����C  ?ToursApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ToursAppToursApp  5   	       ToursApp.HotelsPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ToursApp     5   	   -   5          � Title$  
HotelsPage��5   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ NoResize=�6Z    � WindowStyle$
 None=�6p   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DGridHotels��5
         AutoGenerateColumns .     
IsReadOnly . $��0,30,0,37.6q�6W      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$! Название отеля��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 100 6W   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6=   �� *Name+6e     5      $% Количество звезд��6%   $	 * 6a   
 6?   �� *CountOfStars+6m     5      $ Страна��6%   $	 * 6W   
 65   �� *Country.Name+6c   5      �� 5   
   -   5         ��Name$ BtnAdd��5      $��Добавить��6!   $
��Left=�64   $��358,419,0,0q�6O   $	��Top=�6d   $��97��6|   $��23��6�   6�   �� 5   
   -   5        $ 	BtnDelete��5      $��Удалить��6$   $
��Left=�66   $��470,419,0,0q�6Q   $	��Top=�6f   $��97��6~   $��23��6�   6�   �� 5   
   -   5        $ 	BtnChange��5      $��Изменить��6$   $
��Left=�67   $��582,419,0,0q�6R   $	��Top=�6g   $��97��6   $��23��6�   6�   �� 5   
   -   5        $ BtnBack��5      $��
Назад��6"   $
��Left=�62   $��693,419,0,0q�6M   $	��Top=�6b   $��97��6z   $��23��6�   6�   �� 5   
   $��Поиск:��6   $
��Left=�6!   $��10,0,0,0q�6<   $	��Top=�6N   $��30��6f   $��48��6r   �� 5   
   -   5         ��Name$ 
TBoxSearch��5   4   $
��Left=�6H   $��30��6c   $��63,0,0,0q�6o    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��737��6�   5      5      