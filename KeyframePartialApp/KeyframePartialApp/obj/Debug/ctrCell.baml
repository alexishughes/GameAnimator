   M S B A M L   `   `   `  ����M  IKeyframePartialApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:KeyframePartialAppKeyframePartialApp  5           KeyframePartialApp.ctrCell   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:KeyframePartialApp     5        � 	Resources  5
         MakeKeyCell �� Text  UnMakeKeyCell��%b   &	        &	 &     �� 5   
   $ Make KeyCell��6.   �� 5   
   $ UnMake KeyCell��60   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6�     5   
   -   5        # [ 5      6�   .��5      �� -   5         ��Name$ bdrBackground��5      $��14��6'   $��24��62    � ContextMenu 5   
   �� 5      -   5         ��Name$ 	cmKeyCell��5      .@�5      m�   
imgKeyIcon m� Icon# [ 6    m� Command# [  6>   	 m� CommandTarget	 6e   �� 
 �� Path$
 PlacementTarget� �� RelativeSource �� *FindAncestor+ �� AncestorType" ��5      m� 5      # [ 6   	 6D   �� $
 PlacementTarget� �� *FindAncestor+" ��5      5      5      5       