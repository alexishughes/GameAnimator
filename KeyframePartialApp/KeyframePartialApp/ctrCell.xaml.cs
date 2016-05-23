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
    /// Interaction logic for ctrCell.xaml
    /// </summary>
    public partial class ctrCell : UserControl
    {
        private Cell _cell;

        public ctrCell(Cell cell)
        {
            _cell = cell;
            InitializeComponent();
            //bdrBackground.Background = new SolidColorBrush(Color.FromArgb(255, 255, 128, 0));
            _cell.PropertyChanged += _cell_PropertyChanged;
            UpdateKeyCellImage();
        }

        private void _cell_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "isKeyCell") UpdateKeyCellImage();
        }

        public void UpdateKeyCellImage()
        {
            if (_cell.isKeyCell)
            {
                rctIcon.Fill = (ImageBrush)Application.Current.Resources["ibKeycell"];
            }
            else
            {
                rctIcon.Fill = null;
            }
        }

        private void MakeKeyCell_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _cell.isKeyCell = true;
      
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!_cell.isKeyCell) e.CanExecute = true;
        }
    }
}
