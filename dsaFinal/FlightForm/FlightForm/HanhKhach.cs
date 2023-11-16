using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FlightForm
{
    public class HanhKhach
    {
        public string CMND;
        public string Ho;
        public string Ten;
        public string Phai;
        public HanhKhach left;
        public HanhKhach right;
        public HanhKhach (string cmnd,string ho,string ten, string phai)
        {
            this.CMND = cmnd.Substring(0, Math.Min(cmnd.Length, Define.MAX_LENGTH_MACB));
            this.CMND = cmnd.Substring(0, Math.Min(cmnd.Length, Define.MAX_LENGTH_MACB));
            this.CMND = cmnd.Substring(0, Math.Min(cmnd.Length, Define.MAX_LENGTH_MACB));
            this.CMND = cmnd.Substring(0, Math.Min(cmnd.Length, Define.MAX_LENGTH_MACB));
            this.left = null;
            this.right = null;
        }
    }
    class BinarySearchTree
    {
        public HanhKhach root;

        public BinarySearchTree()
        {
            root = null;
        }
        public void ThemHK(HanhKhach temproot, string cmnd, string ho, string ten, string phai)
        {
            HanhKhach temp = new HanhKhach(cmnd, ho, ten, phai);

            if (temproot == null)
            {
                root = temp;
            }
            else
            {
                HanhKhach nodeRun = temproot;
                HanhKhach nodeTruoc = temproot;
                while (nodeRun != null)
                {
                    nodeTruoc = nodeRun;
                    if (cmnd.CompareTo(nodeRun.CMND) < 0)
                    {
                        nodeRun = nodeRun.left;
                    }
                    else if (cmnd.CompareTo(nodeRun.CMND) > 0)
                    {
                        nodeRun = nodeRun.right;
                    }
                }

                if (cmnd.CompareTo(nodeTruoc.CMND) > 0)
                {
                    nodeTruoc.right = temp;
                }
                else nodeTruoc.left = temp;
            }
        }
        public HanhKhach search(HanhKhach temproot, string cmnd)
        {
            HanhKhach NodeRun = temproot;
            while (NodeRun != null && (cmnd.CompareTo(NodeRun.CMND) != 0))
            {
                if (cmnd.CompareTo(NodeRun.CMND) > 0)
                    NodeRun = NodeRun.right;
                else
                    NodeRun = NodeRun.left;

            }
            return NodeRun;
        }
        public void EditDataHK(HanhKhach temp, HanhKhach hk)
        {
            temp = hk;
        }
    }
}
