   M S B A M L   `   `   `  ����C  ?ToursApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ToursAppToursApp  5   	       ToursApp.ToursPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ToursApp     5   	   -   5          � Title$  	ToursPage��5   	   $��593.438��6   $��1223.281��6,    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�6�    � WindowStyle$
 None=�6�   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
DGridTours��5
         AutoGenerateColumns .     
IsReadOnly . $��0,30,-0.2,60q�6U      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Название тура��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 100 6V   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6<   �� *Name+6d   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Изображение��6)      CellTemplate 5      �� 5      .R�5      �� $	��400��6$   $��UniformToFill=�60   ��5   "   �� 5   &    �� Path$ ImagePreview�6.    �� TargetNullValue 5   *   ��5   .   Resources/placeholder.png��6U   5   '   5      5      5        5      $) #Количество билетов��6%   $	 * 6a   
 6A   �� *TicketCount+6m     5      $ Описание тура��6%   $	 * 6]   
 6<   �� *Description+6i     5       $ Цена��6%   $	 * 6N   
 63   �� *Price+6Z     5!      $ Актуален��6%   $	 * 6U   
 67   �� *
IsActual+6a   5$      �� 5%   
   -   5         ��Name$ btnBack��5%      $��
Назад��6#   $
��Left=�63   $��845,548,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 5&   
   -   5        $ 	BtnDelete��5&      $��Удалить��6$   $
��Left=�66   $��939,548,0,0q�6Q   $	��Top=�6f   $��75��6~   6�   �� 5'   
   -   5        $ 	BtnChange��5'      $��Изменить��6$   $
��Left=�67   $��1035,548,0,0q�6R   $	��Top=�6h   $��75��6�   6�   �� 5(   
   -   5        $ BtnAdd��5(      $��Добавить��6!   $
��Left=�64   $��1130,548,0,0q�6O   $	��Top=�6e   $��75��6}   6�   �� 5)   
   -   5         ��Name$ 
TBoxSearch��5)      $
��Left=�6H   $��30��6c   $��53,0,0,0q�6o    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $
��1170��6�   �� 5*   
   $��Поиск:��6   $
��Left=�6!   $��0,-1,0,0q�6<   $	��Top=�6N   $��31��6f   $��78��6r   5,      5-      