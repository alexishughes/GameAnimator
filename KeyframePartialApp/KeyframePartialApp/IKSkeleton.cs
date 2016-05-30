using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace KeyframePartialApp
{
    class IKSkeleton
    {

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
            ikbWaist.isOrigin = true;
            ikbWaist.ikbParent = null;
            ikbWaist.blnTheta = false;
            ikbWaist.blnThi = false;
            ikbWaist.blnPsi = false;

            ikbTorso = new IKBone();
            ikbTorso.isOrigin = false;
            ikbTorso.ikbParent = ikbWaist;
            ikbTorso.blnTheta = false;
            ikbTorso.blnThi = null;
            ikbTorso.blnPsi = null;

            ikbHead = new IKBone();
            ikbHead.isOrigin = false;
            ikbHead.ikbParent = ikbTorso;
            ikbTorso.blnTheta = false;
            ikbTorso.blnThi = null;
            ikbTorso.blnPsi = null;

            ikbRightUpperArm = new IKBone();
            ikbRightUpperArm.isOrigin = false;
            ikbRightUpperArm.ikbParent = ikbTorso;
            ikbRightUpperArm.blnTheta = true;
            ikbRightUpperArm.blnThi = false;
            ikbRightUpperArm.blnPsi = true;

            ikbRightLowerArm = new IKBone();
            ikbRightLowerArm.isOrigin = false;
            ikbRightLowerArm.ikbParent = ikbRightUpperArm;
            ikbRightLowerArm.blnTheta = null;
            ikbRightLowerArm.blnThi = false;
            ikbRightLowerArm.blnPsi = true;

            ikbLeftUpperArm = new IKBone();
            ikbLeftUpperArm.isOrigin = false;
            ikbLeftUpperArm.ikbParent = ikbTorso;
            ikbLeftUpperArm.blnTheta = false;
            ikbLeftUpperArm.blnThi = false;
            ikbLeftUpperArm.blnPsi = false;

            ikbLeftLowerArm = new IKBone();
            ikbLeftLowerArm.isOrigin = false;
            ikbLeftLowerArm.ikbParent = ikbLeftUpperArm;
            ikbLeftLowerArm.blnTheta = null;
            ikbLeftLowerArm.blnThi = false;
            ikbLeftLowerArm.blnPsi = false;

            ikbRightUpperLeg = new IKBone();
            ikbRightUpperLeg.isOrigin = false;
            ikbRightUpperLeg.ikbParent = ikbTorso;
            ikbRightUpperLeg.blnTheta = true;
            ikbRightUpperLeg.blnThi = false;
            ikbRightUpperLeg.blnPsi = true;

            ikbRightLowerLeg = new IKBone();
            ikbRightLowerLeg.isOrigin = false;
            ikbRightLowerLeg.ikbParent = ikbRightUpperArm;
            ikbRightLowerLeg.blnTheta = null;
            ikbRightLowerLeg.blnThi = false;
            ikbRightLowerLeg.blnPsi = true;

            ikbRightFoot = new IKBone();
            ikbRightFoot.isOrigin = false;
            ikbRightFoot.ikbParent = ikbRightLowerLeg;
            ikbRightFoot.blnTheta = true;
            ikbRightFoot.blnThi = false;
            ikbRightFoot.blnThi = true;

            ikbLeftUpperLeg = new IKBone();
            ikbLeftUpperLeg.isOrigin = false;
            ikbLeftUpperLeg.ikbParent = ikbTorso;
            ikbLeftUpperLeg.blnTheta = false;
            ikbLeftUpperLeg.blnThi = false;
            ikbLeftUpperLeg.blnPsi = false;

            ikbLeftLowerLeg = new IKBone();
            ikbLeftLowerLeg.isOrigin = false;
            ikbLeftLowerLeg.ikbParent = ikbLeftUpperLeg;
            ikbLeftLowerLeg.blnTheta = null;
            ikbLeftLowerLeg.blnThi = false;
            ikbLeftLowerLeg.blnPsi = false;

            ikbLeftFoot = new IKBone();
            ikbLeftFoot.isOrigin = false;
            ikbLeftFoot.ikbParent = ikbLeftLowerLeg;
            ikbLeftFoot.blnTheta = true;
            ikbLeftFoot.blnThi = false;
            ikbLeftFoot.blnThi = true;


        }
    }

    class IKBone
    {
        public bool isOrigin;
        public IKBone ikbParent;
        public Matrix3D m3dPosition;
        public Matrix3D _m3dPostionAtTPose;
        public double dblTheta; public bool? blnTheta;
        public double dblThi; public bool? blnThi;
        public double dblPsi; public bool? blnPsi;





    }
}
