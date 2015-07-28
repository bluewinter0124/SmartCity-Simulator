using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartTrafficSimulator.SystemObject;
using SmartTrafficSimulator.SystemObject;
using System.Drawing.Drawing2D;
using SmartTrafficSimulator.SystemManagers;


namespace SmartTrafficSimulator
{
    public partial class MapEditor : Form
    {
        public static List<MapEditorRoad> roadList = new List<MapEditorRoad>();
        public static List<MapEditorIntersection> intersectionList = new List<MapEditorIntersection>();
        Bitmap mapImage;
        string mapFilePath = "";
        int roadIDCount = 0;    //計算roadID的數量, 用於create和delete Road時使用
        int intersectionIDCount = 0;
        int roadOfIntersectionAmount = 0;
        int roadPathOrder = 0;
        int roadConnectionAmount = 0;
        bool isAddingNode = false;
        bool isCreatingConnection = false;
        bool isCreatingRoadOfIntersection = false;

        public MapEditor()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.splitContainer_MapEditor.Panel2.AutoScroll = true;

            roadList = new List<MapEditorRoad>();
            intersectionList = new List<MapEditorIntersection>();
            CheckMapConfigLoadded();
        }

        public class MapEditorRoad
        {
            public int roadID;
            public string roadName;
            public List<int> roadPathID;
            public List<Point> roadNode;
            public List<int> connectedRoadIDList;
            public int configNo = 0;           //先預設0

            public MapEditorRoad(int roadID)
            {
                this.roadID = roadID;
                this.roadName = roadID + "_name";
                roadPathID = new List<int>();
                roadNode = new List<Point>();
                connectedRoadIDList = new List<int>();
            }

            public void AddRoadPathID(int pathID)
            {
                roadPathID.Add(pathID);
            }

            public void AddRoadNode(Point node)
            {
                roadNode.Add(node);
            }

            public void AddConnectRoad(int roadID)
            {
                connectedRoadIDList.Add(roadID);
            }

            public void SetRoadOrder(int order)
            {
                this.configNo = order;
            }
        }

        public class MapEditorIntersection
        {
            public int intersectionID;
            public string intersectionName = "default";
            public List<MapEditorRoad> composedRoads;

            public MapEditorIntersection(int intersectionID)
            {
                this.intersectionID = intersectionID;
                composedRoads = new List<MapEditorRoad>();
            }

            public void AddRoadListOfIntersection(MapEditorRoad road)
            {
                composedRoads.Add(road);
            }
        }

        private void CheckMapConfigLoadded()
        {
            if (Simulator.mapFileReaded)
            {
                mapFilePath = Simulator.mapPicturePath;
                mapImage = new Bitmap(mapFilePath);
                LoadRoadInfoToStruct();
                DisplayRoadBasicInfo();
                DisplayIntersectionID();
            }
            else
            {
                OpenFileDialog openMapImage = new OpenFileDialog();
                openMapImage.Filter = "Map Image(*.jpg, *.png, *.bmp, *.gif)|*.jpg; *.png; *.bmp; *.gif";
                openMapImage.Title = "Select a Map Image";

                if (openMapImage.ShowDialog() == DialogResult.OK)
                {
                    mapFilePath = openMapImage.FileName;
                    mapImage = new Bitmap(mapFilePath);
                }
            }
            this.splitContainer_MapEditor.Panel2.BackgroundImage = mapImage;
        }

        private void LoadRoadInfoToStruct()
        {
            for (int i = 0; i < Simulator.RoadManager.GetRoadList().Count; i++)
            {
                MapEditorRoad editorRoad = new MapEditorRoad(i);
                for (int j = 0; j < Simulator.RoadManager.GetRoadByID(i).roadNodeList.Count; j++)
                {
                    editorRoad.AddRoadPathID(j);
                    editorRoad.AddRoadNode(Simulator.RoadManager.GetRoadByID(i).roadNodeList[j]);
                    editorRoad.SetRoadOrder(Simulator.RoadManager.GetRoadByID(i).phaseNo);
                }
                for (int j = 0; j < Simulator.RoadManager.GetRoadByID(i).connectedRoadIDList.Count; j++)
                {
                    editorRoad.AddConnectRoad(Simulator.RoadManager.GetRoadByID(i).connectedRoadIDList[j]);
                }
                roadList.Add(editorRoad);
            }
            for (int i = 0; i < Simulator.IntersectionManager.GetNumberOfIntersections(); i++)
            {
                MapEditorIntersection editorIntersection = new MapEditorIntersection(i);
                for (int j = 0; j < Simulator.IntersectionManager.GetIntersectionByID(i).roadList.Count; j++)
                {
                    for (int k = 0; k < Simulator.RoadManager.GetRoadList().Count; k++)
                    {
                        if (Simulator.IntersectionManager.GetIntersectionByID(i).roadList[j].roadID
                            == roadList[k].roadID)
                        {
                            editorIntersection.AddRoadListOfIntersection(roadList[k]);
                            break;
                        }
                    }
                }
                intersectionList.Add(editorIntersection);
            }
        }

        private void DisplayRoadBasicInfo()
        {
            this.dataGridView_RoadBasicInfo.Rows.Clear();   //把整個rows清空做refresh
            roadIDCount = roadList.Count;
            for (int i = 0; i < roadIDCount; i++)
            {
                this.dataGridView_RoadBasicInfo.Rows.Add();
                this.dataGridView_RoadBasicInfo.Rows[i].Cells[0].Value = roadList[i].roadID;
                this.dataGridView_RoadBasicInfo.Rows[i].Cells[1].Value = roadList[i].roadName;
            }
        }

        private void DisplayOrderOfPath()
        {
            this.dataGridView_OrderOfPath.Rows.Clear();
            int selectedIndex = dataGridView_RoadBasicInfo.CurrentCell.RowIndex;
            roadPathOrder = roadList[selectedIndex].roadPathID.Count;
            for (int i = 0; i < roadPathOrder; i++)
            {
                this.dataGridView_OrderOfPath.Rows.Add();
                this.dataGridView_OrderOfPath.Rows[i].Cells[0].Value = roadList[selectedIndex].roadPathID[i];
                this.dataGridView_OrderOfPath.Rows[i].Cells[1].Value = roadList[selectedIndex].roadNode[i];
            }
        }

        private void DisplayRoadConnection()
        {
            this.dataGridView_RoadConnection.Rows.Clear();
            int selectedIndex = dataGridView_RoadBasicInfo.CurrentCell.RowIndex;
            roadConnectionAmount = roadList[selectedIndex].connectedRoadIDList.Count;
            for (int i = 0; i < roadConnectionAmount; i++)
            {
                this.dataGridView_RoadConnection.Rows.Add();
                this.dataGridView_RoadConnection.Rows[i].Cells[0].Value = roadList[selectedIndex].connectedRoadIDList[i];
            }
        }

        private void DisplayIntersectionID()
        {
            this.dataGridView_IntersectionID.Rows.Clear();
            intersectionIDCount = intersectionList.Count;
            for (int i = 0; i < intersectionIDCount; i++)
            {
                this.dataGridView_IntersectionID.Rows.Add();
                this.dataGridView_IntersectionID.Rows[i].Cells[0].Value = intersectionList[i].intersectionID;
            }
        }

        private void DisplayIntersectionInfo()
        {
            this.dataGridView_IntersectionInfo.Rows.Clear();
            int selectedIndex = dataGridView_IntersectionID.CurrentCell.RowIndex;
            roadOfIntersectionAmount = intersectionList[selectedIndex].composedRoads.Count;
            for (int i = 0; i < roadOfIntersectionAmount; i++)
            {
                this.dataGridView_IntersectionInfo.Rows.Add();
                this.dataGridView_IntersectionInfo.Rows[i].Cells[0].Value = 
                    intersectionList[selectedIndex].composedRoads[i].roadID;
                this.dataGridView_IntersectionInfo.Rows[i].Cells[1].Value =
                    intersectionList[selectedIndex].composedRoads[i].configNo;
            }
        }
        //draw
        private void DrawPointOnPanel()
        {
            Graphics g = this.splitContainer_MapEditor.Panel2.CreateGraphics();
            Pen yellowPen = new Pen(Color.Yellow, 3);
        }

        private void GetMousePosition(object sender, MouseEventArgs e)
        {
            Point panelLocClient = this.splitContainer_MapEditor.Panel2.PointToClient(Cursor.Position);
            this.label_Position.Text = "Position : " + panelLocClient.X + ", " + panelLocClient.Y;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            SimulationFileWriter save = new SimulationFileWriter();
            save.SaveMapFile_XML();
        }

        private void button_CreateRoad_Click(object sender, EventArgs e)
        {
            try
            {
                MapEditorRoad editorRoad = new MapEditorRoad(roadIDCount);
                roadList.Add(editorRoad);
                DisplayRoadBasicInfo();
            }
            catch (NullReferenceException ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void button_DeleteRoad_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = dataGridView_RoadBasicInfo.CurrentCell.RowIndex;
                roadList.RemoveAt(selectedIndex);
                //把整個basicInfo更新, order of ID
                for (int i = 0; i < roadIDCount - 1; i++)   //roadIDCount-1因為還沒更新roadIDCount, 還是舊的count值
                {
                    roadList[i].roadID = i;
                }
                DisplayRoadBasicInfo();
            }
            catch (NullReferenceException ex)
            { MessageBox.Show(ex.ToString()); }
        }
        //not implementation
        private void button_ReviseName_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void button_CreatePath_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isAddingNode)
                {
                    button_addNode.Text = "Stop";
                    isAddingNode = true;
                }
                else if (isAddingNode)
                {
                    button_addNode.Text = "New";
                    isAddingNode = false;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void dataGridView_RoadBasicInfo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DisplayOrderOfPath();
                DisplayRoadConnection();
            }
            catch (Exception ex)
            { }
        }
        //paint point on panel
        private void dataGridView_OrderOfPath_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            { }
        }

        private void splitContainer_MapEditor_Panel2_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = dataGridView_RoadBasicInfo.CurrentCell.RowIndex;
                
                if (isAddingNode)
                {
                    roadList[selectedIndex].AddRoadPathID(roadList[selectedIndex].roadPathID.Count);
                    roadList[selectedIndex].AddRoadNode(splitContainer_MapEditor.Panel2.PointToClient(Cursor.Position));
                    DisplayOrderOfPath();
                }
                else if (isCreatingConnection)
                {
                    Point tmpPoint = new Point();
                    tmpPoint = this.splitContainer_MapEditor.Panel2.PointToClient(Cursor.Position);
                    for (int i = 0; i < roadIDCount; i++)
                    {
                        if ((tmpPoint.X <= roadList[i].roadNode[0].X + 10) &&
                            (tmpPoint.X >= roadList[i].roadNode[0].X - 10) &&
                            (tmpPoint.Y <= roadList[i].roadNode[0].Y + 10) &&
                            (tmpPoint.Y >= roadList[i].roadNode[0].Y - 10))
                        {
                            roadList[selectedIndex].AddConnectRoad(roadList[i].roadID);
                        }
                    }
                    DisplayRoadConnection();
                }
                else if (isCreatingRoadOfIntersection)
                {
                    int selectedIntersectionIndex = dataGridView_IntersectionID.CurrentCell.RowIndex;
                    Point tmpPoint = new Point();
                    tmpPoint = this.splitContainer_MapEditor.Panel2.PointToClient(Cursor.Position);
                    for (int i = 0; i < roadIDCount; i++)
                    {

                        if ((tmpPoint.X <= roadList[i].roadNode.Last().X + 10) &&
                            (tmpPoint.X >= roadList[i].roadNode.Last().X - 10) &&
                            (tmpPoint.Y <= roadList[i].roadNode.Last().Y + 10) &&
                            (tmpPoint.Y >= roadList[i].roadNode.Last().Y - 10))
                        {
                            intersectionList[selectedIntersectionIndex].AddRoadListOfIntersection(roadList[i]);
                        }
                    }
                    DisplayIntersectionInfo();
                }
                else { MessageBox.Show("未開啟新增路徑/連接道路"); } //do nothing, 不能畫點
                
               
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }
        
        private void button_DeletePath_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = dataGridView_RoadBasicInfo.CurrentCell.RowIndex;
                int selectedPathIndex = dataGridView_OrderOfPath.CurrentCell.RowIndex;
                roadList[selectedIndex].roadPathID.RemoveAt(selectedPathIndex);
                roadList[selectedIndex].roadNode.RemoveAt(selectedPathIndex);
                for (int i = 0; i < roadPathOrder - 1; i++)
                {
                    roadList[selectedIndex].roadPathID[i] = i;
                }
                DisplayOrderOfPath();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void button_Up_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView_RoadBasicInfo.CurrentCell.RowIndex;
            int row = dataGridView_OrderOfPath.CurrentCell.RowIndex;
            int column = dataGridView_OrderOfPath.CurrentCell.ColumnIndex;
            Point tmpPoint = new Point();

            if (row - 1 < 0)
            {
                dataGridView_OrderOfPath.CurrentCell = dataGridView_OrderOfPath[column, 0];
            }
            else
            {
                dataGridView_OrderOfPath.CurrentCell = dataGridView_OrderOfPath[column, row - 1];
                tmpPoint = roadList[selectedIndex].roadNode[row-1];
                roadList[selectedIndex].roadNode[row - 1] = roadList[selectedIndex].roadNode[row];
                roadList[selectedIndex].roadNode[row] = tmpPoint;
            }
            DisplayOrderOfPath();
        }

        private void button_Down_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView_RoadBasicInfo.CurrentCell.RowIndex;
            int count = dataGridView_OrderOfPath.Rows.Count;
            int row = dataGridView_OrderOfPath.CurrentCell.RowIndex;
            int column = dataGridView_OrderOfPath.CurrentCell.ColumnIndex;
            Point tmpPoint = new Point();

            if (row + 1 > count - 1)
            {
                dataGridView_OrderOfPath.CurrentCell = dataGridView_OrderOfPath[column, count - 1];
            }
            else
            {
                dataGridView_OrderOfPath.CurrentCell = dataGridView_OrderOfPath[column, row + 1];
                tmpPoint = roadList[selectedIndex].roadNode[row + 1];
                roadList[selectedIndex].roadNode[row + 1] = roadList[selectedIndex].roadNode[row];
                roadList[selectedIndex].roadNode[row] = tmpPoint;
            }
            DisplayOrderOfPath();
        }

        private void button_CreateConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isCreatingConnection)
                {
                    button_CreateConnection.Text = "Stop";
                    isCreatingConnection = true;
                }
                else if (isCreatingConnection)
                {
                    button_CreateConnection.Text = "New";
                    isCreatingConnection = false;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void button_DeleteConnection_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = dataGridView_RoadBasicInfo.CurrentCell.RowIndex;
                int selectedConnectionIndex = dataGridView_RoadConnection.CurrentCell.RowIndex;
                roadList[selectedIndex].connectedRoadIDList.RemoveAt(selectedConnectionIndex);
                DisplayRoadConnection();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void button_CreateIntersection_Click(object sender, EventArgs e)
        {
            try
            {
                MapEditorIntersection editorIntersection = new MapEditorIntersection(intersectionIDCount);
                intersectionList.Add(editorIntersection);
                DisplayIntersectionID();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void button_DeleteIntersection_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIntersectionIndex = dataGridView_IntersectionID.CurrentCell.RowIndex;
                intersectionList.RemoveAt(selectedIntersectionIndex);
                for (int i = 0; i < intersectionIDCount - 1; i++)
                {
                    intersectionList[i].intersectionID = i;
                }
                DisplayIntersectionID();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void button_CreateConnectionRoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isCreatingRoadOfIntersection)
                {
                    button_CreateConnectionRoad.Text = "Stop";
                    isCreatingRoadOfIntersection = true;
                }
                else if (isCreatingRoadOfIntersection)
                {
                    button_CreateConnectionRoad.Text = "Add";
                    isCreatingRoadOfIntersection = false;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void button_DeleteConnectionRoad_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIntersectionIndex = dataGridView_IntersectionID.CurrentCell.RowIndex;
                int selectedIntersectionInfoIndex = dataGridView_IntersectionInfo.CurrentCell.RowIndex;
                intersectionList[selectedIntersectionIndex].composedRoads.RemoveAt(selectedIntersectionInfoIndex);
                DisplayIntersectionInfo();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void dataGridView_IntersectionID_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DisplayIntersectionInfo();
            }
            catch (Exception ex)
            { }
        }

        private void textBox_TrafficLightSetting_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
