   M S B A M L   `   `   `  ????D  @SupplyApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SupplyApp	SupplyApp  5          SupplyApp.SupplyPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:SupplyApp     5      -   5          N? Title$  
SupplyPage??5	       N? 
Background
 ???d?.??5      ?  ? RowDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??40 ?6   ?? 5      $??30 ?6   .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DGSupply??5         AutoGenerateColumns .     
IsReadOnly . 
???????   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Товар??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6U   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 64   ?? *Product.Name+6a     5      $ Дата закупки??6%   $ * 6[   	 6;   ?? *Date_Supply+6g   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 auto 6)   
   CellTemplate
 5      ?? 5      .R?5      ??  ??Name$ 	BtnSupply??6%   -   5        $??Перейти??5   8   
????iA?$??18(?6z    J? Effect 5   "   3  -System.Windows.Media.Effects.DropShadowEffect  5   &   5      5      5       5"      ?? 5#   
   -   5        $	 Add??5#      $??ДОБАВИТЬ??6   $
??Left=?61   $	??Top=?6L   $	??150??6v   $??30??6?   $??1??6?   $??16(?6?   
???????
????iA?$
??Bold"?6?   $??10,0,0,0q?6?    5$        5%      5'      ?? 5(   
   -   5        $	 Del??5(      $??УДАЛИТЬ??6   $??Right=?60   $	??Top=?6L   $??1??6w   
???????$??16(?6?   $??30??6?   $	??150??6?   
????iA?$
??Bold"?6?   $??0,0,10,0q?6?    5)        5*      5,      (  "System.Windows.Controls.DatePicker  5.   
   -   5          Name$ DPSearch??5.      $??16(?6'   $??2??65   $	??500??6B   $??Center=?6N   $??Center=?6k    ? ToolTip$4 .Выберите дату для поиска.??6?   ?? 5/   
   -   5        $ 	BtnSearch??5/      $??
НАЙТИ??6$   $??2??64   $	??100??6A   
???????$??Right=?6`   $??0,0,10,0q?6?   $??16(?6?   
????iA?$
??Bold"?6?   50      51      