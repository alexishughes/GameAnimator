using KeyframePartialApp.Timeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeyframePartialApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IKSkeleton_SimpleBiped thisIKBiped = new IKSkeleton_SimpleBiped();

            grdMain.Children.Add(thisIKBiped.RenderManipulator());

            //ctlTimeline thisCtlTimeline = new ctlTimeline();
            //grdMain.Children.Add(thisCtlTimeline);
            //Cell[] thisCells = new Cell[100];
            //for (int i = 0; i < 100; i++)
            //{

            //    thisCells[i] = new Cell();
            //    if ((i % 10) == 5)
            //    {
            //        thisCells[i].isKeyCell = true;
            //    }
            //    thisCtlTimeline.stpTimeline.Children.Add(thisCells[i].printCtrCell());


            //}



        }
    }
}
