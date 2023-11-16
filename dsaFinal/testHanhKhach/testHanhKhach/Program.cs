using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testHanhKhach
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using testHanhKhach.FlightForm;

    namespace FlightForm
    {
        public class HanhKhach
        {
            public string CMND { get; set; }
            public string Ho { get; set; }
            public string Ten { get; set; }
            public string Phai { get; set; }
            public HanhKhach left;
            public HanhKhach right;
            public HanhKhach(string cmnd, string ho, string ten, string phai)
            {
                this.CMND = cmnd;
                this.Ho = ho;
                this.Ten = ten;
                this.Phai = phai;
                this.left = null;
                this.right = null;
            }
            public HanhKhach()
            {
                CMND = null;
                Ho = null;
                Ten = null;
                Phai = null;
                left = null;
                right = null;
            }
        }
        public class DanhSachHanhKhach
        {
            public static HanhKhach root;
            public static List<HanhKhach> HienThiHK = new List<HanhKhach>();
            public DanhSachHanhKhach()
            {
                root = null;
            }
            public static void ThemHK(HanhKhach hk)
            {
                HienThiHK.Add(hk);
                HienThiHK.Sort((i, j) => i.CMND.CompareTo(j.CMND));
                if (root == null)
                {
                    root = hk;
                }

                else
                {
                    HanhKhach nodeRun = root;
                    HanhKhach nodeTruoc = root;
                    while (nodeRun != null)
                    {
                        nodeTruoc = nodeRun;
                        if (hk.CMND.CompareTo(nodeRun.CMND) < 0)
                        {
                            nodeRun = nodeRun.left;
                        }
                        else if (hk.CMND.CompareTo(nodeRun.CMND) > 0)
                        {
                            nodeRun = nodeRun.right;
                        }
                    }

                    if (hk.CMND.CompareTo(nodeTruoc.CMND) > 0)
                    {
                        nodeTruoc.right = hk;
                    }
                    else nodeTruoc.left = hk;
                }
                return;
            }

            public static bool delete(string CMND)
            {
                HanhKhach p = root;
                HanhKhach pp = null;
                while (p != null && p.CMND != CMND)
                {
                    pp = p;
                    if (CMND.CompareTo(p.CMND) < 0)
                        p = p.left;
                    else
                        p = p.right;
                }
                if (p == null)
                    return false;
                if (p.left != null && p.right != null)
                {
                    HanhKhach s = p.left;
                    HanhKhach ps = p;
                    while (s.right != null)
                    {
                        ps = s;
                        s = s.right;
                    }
                    p.CMND = s.CMND;
                    p = s;
                    pp = ps;
                }
                HanhKhach c = null;
                if (p.left != null)
                    c = p.left;
                else
                    c = p.right;
                if (p == root)
                    root = null;
                else
                {
                    if (p == pp.left)
                        pp.left = c;
                    else
                        pp.right = c;
                }
                HienThiHK.Remove(p);
                return true;
            }
            public static HanhKhach search(string cmnd)
            {
                if (!isItExsit(root, cmnd))
                {
                    return null;
                }
                HanhKhach NodeRun = root;
                while (NodeRun != null && (cmnd.CompareTo(NodeRun.CMND) != 0))
                {
                    if (cmnd.CompareTo(NodeRun.CMND) > 0)
                        NodeRun = NodeRun.right;
                    else
                        NodeRun = NodeRun.left;
                }
                return NodeRun;
            }
            public static bool isItExsit(HanhKhach temproot, string cmnd)
            {
                if (temproot != null)
                {
                    if (cmnd.CompareTo(temproot.CMND) == 0)
                        return true;
                    else if (cmnd.CompareTo(temproot.CMND) < 0)
                        return isItExsit(temproot.left, cmnd);
                    else if (cmnd.CompareTo(temproot.CMND) > 0)
                        return isItExsit(temproot.right, cmnd);
                }
                return false;
            }
            public static void EditDataHK(HanhKhach temp, HanhKhach hk)
            {
                temp = hk;
                //DeleteDataList();
                //UpdateDataListInorder(root);
            }
            public static void DeleteDataList()
            {
                if (HienThiHK != null)
                {
                    if (HienThiHK != null)
                    {
                        for (int i = 0; i < HienThiHK.Count; i++)
                            HienThiHK.RemoveAt(i);
                    }
                }

            }
            public static void UpdateDataListInorder(HanhKhach temproot)
            {
                if (temproot != null)
                {
                    UpdateDataListInorder(temproot.left);
                    HienThiHK.Add(temproot);
                    UpdateDataListInorder(temproot.right);
                }
            }
            public static void DocFileHK()
            {
                string path = "..\\data_HK.txt";
                try
                {
                    StreamReader sr = new StreamReader(path);
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] arr = line.Split(';');
                        if (arr.Length == 4)
                        {
                            HanhKhach hk = new HanhKhach(arr[0].Trim(), arr[1].Trim(), arr[2].Trim(), arr[3].Trim());
                            ThemHK(hk);

                        }
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            public static void LuuDanhSachHanhKhachVaoFile()
            {
                using (StreamWriter writer = new StreamWriter("..\\data_HK.txt"))
                {
                    for (int i = 0; i < HienThiHK.Count; i++)
                    {
                        string line = HienThiHK[i].CMND + ";" + HienThiHK[i].Ho + ";" + HienThiHK[i].Ten + ";" + HienThiHK[i].Phai;
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //DanhSachHanhKhach DanhSachHanhKhach = new DanhSachHanhKhach();
            HanhKhach hk = new HanhKhach("123456789", "Nguyen Van", "A", "Nam");
            HanhKhach hk1 = new HanhKhach("987654321", "Le Thi", "B", "Nu");
            HanhKhach hk2 = new HanhKhach("567891234", "Tran Van", "C", "Nam");
            // add some HanhKhach objects to the binary search tree
            DanhSachHanhKhach.ThemHK(hk);
            DanhSachHanhKhach.ThemHK(hk1);
            DanhSachHanhKhach.ThemHK(hk2);

            // search for a HanhKhach object by CMND
            HanhKhach hk3 = DanhSachHanhKhach.search("123456789");
            //HanhKhach hk1 = DanhSachHanhKhach.search(DanhSachHanhKhach.root, "987654321");
            HanhKhach hk4 = DanhSachHanhKhach.search( "567891234");
            HanhKhach hk5 = new HanhKhach("123456789", "Nguyen Van", "A", "Nam");
            
            for(int i = 0; i < DanhSachHanhKhach.HienThiHK.Count; i++)
            {
                Console.WriteLine($"Found HanhKhach with CMND {DanhSachHanhKhach.HienThiHK[i].CMND}: {DanhSachHanhKhach.HienThiHK[i].Ho} {DanhSachHanhKhach.HienThiHK[i].Ten} {DanhSachHanhKhach.HienThiHK[i].Phai}");
            }
            if(!DanhSachHanhKhach.HienThiHK.Contains(hk4))
                Console.WriteLine(DanhSachHanhKhach.HienThiHK.Count);
            if (hk3 != null)
            {
                Console.WriteLine($"Found HanhKhach with CMND {hk3.CMND}: {hk3.Ho} {hk3.Ten} {hk3.Phai}");
            }
            if (hk4 != null)
            {
                Console.WriteLine($"Found HanhKhach with CMND {hk4.CMND}: {hk4.Ho} {hk4.Ten} ({hk4.Phai})");
            }
            else
            {
                Console.WriteLine("HanhKhach not found");
            }
            Console.ReadLine();
        }
    }   
}
