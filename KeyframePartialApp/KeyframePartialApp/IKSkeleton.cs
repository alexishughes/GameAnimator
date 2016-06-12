using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace KeyframePartialApp
{
    class IKSkeleton
    {
        public StackPanel RenderManipulator()
        {
            StackPanel spSkeleton = new StackPanel();
            spSkeleton.Children.Add(new Label { Content = "Hello World" });
            FieldInfo[] finBones = this.GetType().GetFields();
            foreach (FieldInfo finThisBone in finBones)
            {
                StackPanel spThisBone = new StackPanel();

                spSkeleton.Children.Add(new Label { Content = finThisBone.Name });
                IKBone ikbThisBone = (IKBone)finThisBone.GetValue(this);


                StackPanel spThisBoneFields = new StackPanel();
                spSkeleton.Children.Add(spThisBone);
                if (!ikbThisBone.isOrigin) spThisBone.Children.Add(new Label { Content = "Parent:" + ikbThisBone.ikbParent.strName });
                spThisBone.Children.Add(new Label{ Content = "Theta:" + ikbThisBone.dblTheta });
                spThisBone.Children.Add(new Label{ Content = "Thi:" + ikbThisBone.dblThi });
                spThisBone.Children.Add(new Label{ Content = "Psi:" + ikbThisBone.dblPsi });
            }

            return spSkeleton;
        }

    }

    class IKSkeleton_SimpleBiped : IKSkeleton
    {
        public IKBone ikbWaist;
        public IKBone ikbTorso;
        public IKBone ikbHead;
        public IKBone ikbLeftUpperArm;
        public IKBone ikbLeftLowerArm;
        public IKBone ikbRightUpperArm;
        public IKBone ikbRightLowerArm;
        public IKBone ikbLeftUpperLeg;
        public IKBone ikbLeftLowerLeg;
        public IKBone ikbLeftFoot;
        public IKBone ikbRightUpperLeg;
        public IKBone ikbRightLowerLeg;
        public IKBone ikbRightFoot;

        public IKSkeleton_SimpleBiped()
        {
            ikbWaist = new IKBone();
            ikbWaist.strName = "Waist";
            ikbWaist.isOrigin = true;
            ikbWaist.ikbParent = null;
            ikbWaist.blnTheta = false;
            ikbWaist.blnThi = false;
            ikbWaist.blnPsi = false;

            ikbTorso = new IKBone();
            ikbTorso.strName = "Torso";
            ikbTorso.isOrigin = false;
            ikbTorso.ikbParent = ikbWaist;
            ikbTorso.blnTheta = false;
            ikbTorso.blnThi = null;
            ikbTorso.blnPsi = null;

            ikbHead = new IKBone();
            ikbHead.strName = "head";
            ikbHead.isOrigin = false;
            ikbHead.ikbParent = ikbTorso;
            ikbTorso.blnTheta = false;
            ikbTorso.blnThi = null;
            ikbTorso.blnPsi = null;

            ikbRightUpperArm = new IKBone();
            ikbRightUpperArm.strName = "RightUpperArm";
            ikbRightUpperArm.isOrigin = false;
            ikbRightUpperArm.ikbParent = ikbTorso;
            ikbRightUpperArm.blnTheta = true;
            ikbRightUpperArm.blnThi = false;
            ikbRightUpperArm.blnPsi = true;

            ikbRightLowerArm = new IKBone();
            ikbRightLowerArm.strName = "RightLowerArm";
            ikbRightLowerArm.isOrigin = false;
            ikbRightLowerArm.ikbParent = ikbRightUpperArm;
            ikbRightLowerArm.blnTheta = null;
            ikbRightLowerArm.blnThi = false;
            ikbRightLowerArm.blnPsi = true;

            ikbLeftUpperArm = new IKBone();
            ikbLeftUpperArm.strName = "LeftUpperArm";
            ikbLeftUpperArm.isOrigin = false;
            ikbLeftUpperArm.ikbParent = ikbTorso;
            ikbLeftUpperArm.blnTheta = false;
            ikbLeftUpperArm.blnThi = false;
            ikbLeftUpperArm.blnPsi = false;

            ikbLeftLowerArm = new IKBone();
            ikbLeftLowerArm.strName = "LeftLowerArm";
            ikbLeftLowerArm.isOrigin = false;
            ikbLeftLowerArm.ikbParent = ikbLeftUpperArm;
            ikbLeftLowerArm.blnTheta = null;
            ikbLeftLowerArm.blnThi = false;
            ikbLeftLowerArm.blnPsi = false;

            ikbRightUpperLeg = new IKBone();
            ikbRightUpperLeg.strName = "RightUpperLeg";
            ikbRightUpperLeg.isOrigin = false;
            ikbRightUpperLeg.ikbParent = ikbTorso;
            ikbRightUpperLeg.blnTheta = true;
            ikbRightUpperLeg.blnThi = false;
            ikbRightUpperLeg.blnPsi = true;

            ikbRightLowerLeg = new IKBone();
            ikbRightLowerLeg.strName = "RightLowerLee";
            ikbRightLowerLeg.isOrigin = false;
            ikbRightLowerLeg.ikbParent = ikbRightUpperArm;
            ikbRightLowerLeg.blnTheta = null;
            ikbRightLowerLeg.blnThi = false;
            ikbRightLowerLeg.blnPsi = true;

            ikbRightFoot = new IKBone();
            ikbRightFoot.strName = "RightFoot";
            ikbRightFoot.isOrigin = false;
            ikbRightFoot.ikbParent = ikbRightLowerLeg;
            ikbRightFoot.blnTheta = true;
            ikbRightFoot.blnThi = false;
            ikbRightFoot.blnThi = true;

            ikbLeftUpperLeg = new IKBone();
            ikbLeftUpperLeg.strName = "LeftUpperLeg";
            ikbLeftUpperLeg.isOrigin = false;
            ikbLeftUpperLeg.ikbParent = ikbTorso;
            ikbLeftUpperLeg.blnTheta = false;
            ikbLeftUpperLeg.blnThi = false;
            ikbLeftUpperLeg.blnPsi = false;

            ikbLeftLowerLeg = new IKBone();
            ikbLeftLowerLeg.strName = "LeftLowerLeg";
            ikbLeftLowerLeg.isOrigin = false;
            ikbLeftLowerLeg.ikbParent = ikbLeftUpperLeg;
            ikbLeftLowerLeg.blnTheta = null;
            ikbLeftLowerLeg.blnThi = false;
            ikbLeftLowerLeg.blnPsi = false;

            ikbLeftFoot = new IKBone();
            ikbLeftFoot.strName = "LeftFoot";
            ikbLeftFoot.isOrigin = false;
            ikbLeftFoot.ikbParent = ikbLeftLowerLeg;
            ikbLeftFoot.blnTheta = true;
            ikbLeftFoot.blnThi = false;
            ikbLeftFoot.blnThi = true;


        }
    }

    class IKBone
    {
        public string strName;
        public bool isOrigin;
        public IKBone ikbParent;
        public Matrix3D m3dPosition;
        public Matrix3D _m3dPostionAtTPose;
        public double dblTheta; public bool? blnTheta;
        public double dblThi; public bool? blnThi;
        public double dblPsi; public bool? blnPsi;
        public double dblThetaDot;
        public double dblThiDot;
        public double dblPsiDot;   
    }
}
