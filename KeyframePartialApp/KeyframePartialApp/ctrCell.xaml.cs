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
                bdrBackground.Fill = (ImageBrush)Application.Current.Resources["ibKeyCell"];
            }
            else
            {
                bdrBackground.Fill = (ImageBrush)Application.Current.Resources["ibCell"];
            }
        }

        private void MakeKeyCell_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _cell.isKeyCell = true;
        }

        private void CommandBinding_MakeKeyCell_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!_cell.isKeyCell) e.CanExecute = true;
        }

        private void CommandBinding_UnMakeKeyCell_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (_cell.isKeyCell) e.CanExecute = true;
        }

        private void UnMakeKeyCell_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _cell.isKeyCell = false;
        }

    }
}
