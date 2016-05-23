using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyframePartialApp.Timeline
{
    /// <summary>
    /// The timeline is an abstract concept for placing keyframe (which I am calling cells as actual timimg will be arbitrary)
    /// For Now all variables are public with get/set accessors.
    /// </summary>
    class Timeline
    {
        // The lenght in seconds of the keyframe to be rendered as a control on screen.
        public float flLengthInSeconds { get; set; }
        // the cells per second rate. Again this can be changed for more detailled editiing but for any actual keyframe cell you can change the exact time it should be aligned to.
        public float flCellsPerSecond { get; set; }
    }
    /// <summary>
    /// The cell class will be a general class for a cell with a boolean indicating if the cell is a keyframe.
    /// I plan to store only the keyframes in the timeline object but render a timeline control with all the frames numbered.
    /// but I am going to want to render a bunch of them as a flash style animation and at the left edge of each cell I plan to re render the image whilst scrubbing through.
    /// this will make for a speedy selection tool but could cause headaches for the keyframes that have been moved.
    /// for now all cell
    /// </summary>
    /// 
    public class Cell : INotifyPropertyChanged
    {
        // ascertains whether the current cell is a key cell.
        private bool _isKeyCell;
        public bool isKeyCell { get { return _isKeyCell; } set { _isKeyCell = value; NotifyPropertyChanged("isKeyCell"); } }
        // this indicates the time value of the cell. For normal frams it will be set arbitrarily when the Timeline is quantised for key frames it will be the exct moment.
        // For now I am going to keep keyframes to the quantised time.
        public float flTime { get; set; }
        // when scrubbing I am only going to render from the left edge of the cell. 
        public float flLeftEdgeTime { get; }
        // Once the cell knows it's owner and it's position on that tween it is in a state that it can send a correct bunch of polygons to the model. In the Case of Keyframe the left edge will be classed as the
        // Owner.
        public Tween twCellOwnerTween;
        // renders a small square which can be stacked.
        public ctrCell printCtrCell()
        {
            ctrCell ctrCellToPrint = new ctrCell(this);
            return ctrCellToPrint;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public Cell()
        {
            PropertyChanged += Cell_PropertyChanged;
        }

        private void Cell_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }
    }



    public class Tween
    {
        public Cell kcBeginning;
        public Cell kcEnding;
    }
}
