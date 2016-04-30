using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media.Media3D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



namespace IKBoneDll
{
    public class IKBone
    {
        public string strName; 
        // human readable name for Bone
        public IKBone bonParent; public bool booIsOrigin; 
        // Bone has one parent for hierachical modelling. if it is the Origin it knows about this.
        public List<IKBone> lstBonChildren; 
        // Bone's children are listed - they must be instantiated first.
        public List<IKBone> lstBonSecondaryParents; 
        // in the case of a loop (like holding a guitar with two hands) extra parents may be available for solving Physics etc - future methods.
        public Matrix3D m3dRelToParentAtCaptureInverse; 
        // this inverse is used to normalize all sub models (in the Capture space) to a verical J vector rooted at the origin. as inverses are expensive it is only calculated on main matrix's update.
        private Matrix3D _m3dRelToParentAtCapturePose;    
        // this matrix will typically be a translation to the point of connection and a rotation (and/or) reflection of the axes for the new frame.                                    
        // taking the convention of Theta/Psi = rotaion about J axis in the sense K->I and Thi rotaion about K axis in the sense I->J.                                     
        // Note if axes are different handed the rotaion should come out in the opposite direction as m3rel to parent will be applied on top of 
        public Matrix3D m3dRelToParentAtTPose
        {
            get { return _m3dRelToParentAtCapturePose; }
            set
            {
                _m3dRelToParentAtCapturePose = value;
                if (value.HasInverse)
                {
                    m3dRelToParentAtTPoseInverse = value;
                    m3dRelToParentAtTPoseInverse.Invert();
                }
                else
                {
                    throw new System.Exception("Matrix Has No Inverse");
                }
            }
        }

        
        public double dblTheta; 
        public double dblThi; 
        public double dblPsi; 
        public void AddChild(ref IKBone bonChildToAdd)
        {
            bonChildToAdd.bonParent = this;
            lstBonChildren.Add(bonChildToAdd);
        }
        public Matrix3D m3dTransformFromTPose()
        {
            Matrix3D thisTransform = Matrix3D.Identity;
            thisTransform = Matrix3D.Multiply(
                new Matrix3D(
                    System.Math.Cos(dblPsi), 0, System.Math.Sin(dblPsi), 0,
                    0, 1, 0, 0,
                    -System.Math.Sin(dblPsi), 0, System.Math.Cos(dblPsi), 0,
                    0, 0, 0, 1
                ),
                thisTransform
            );
            thisTransform = Matrix3D.Multiply(
                new Matrix3D(
                    System.Math.Cos(dblThi), System.Math.Sin(dblThi), 0, 0,
                    -System.Math.Sin(dblThi), System.Math.Cos(dblThi), 0, 0,
                    0, 0, 1, 0,
                    0, 0, 0, 1
                ),
                thisTransform
             );
            thisTransform = Matrix3D.Multiply(
                new Matrix3D(
                    System.Math.Cos(dblTheta), 0, System.Math.Sin(dblTheta), 0,
                    0, 1, 0, 0,
                    -System.Math.Sin(dblTheta), 0, System.Math.Cos(dblTheta), 0,
                    0, 0, 0, 1
                ),
                thisTransform
                );
            return thisTransform;
        }

        public string EmitToCSharp(string strBoneName)
        {
            string strOutput = "";
            strOutput += @"
        "+
        strBoneName + @" = new IKBone(
            {
                strName = """ + strName+@""",
                m3dRelToParentAtCapturePose = new Matrix3D
                ("+
                m3dRelToParentAtCapturePose.ToString()+
                @"),
                dblTheta = "+dblTheta.ToString() + @",
                dblThi = "+dblThi.ToString() + @",
                dblPsi = "+dblPsi.ToString() + @",

            };
        ";



            return strOutput;
        }


    }
}
