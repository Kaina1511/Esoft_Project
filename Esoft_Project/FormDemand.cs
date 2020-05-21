using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esoft_Project
{
    public partial class FormDemand : Form
    {
        public FormDemand()
        {
            InitializeComponent();
            ShowAgents();
            ShowClients();
            ShowDemand();
        }
        void ShowAgents()
        {
            comboBoxAgent.Items.Clear();
            foreach (AgentSet agentSet in Program.wfedb.AgentSet)
            {
                string[] item = { agentSet.Id.ToString() + ".", agentSet.FirstName, agentSet.MiddleName,
                    agentSet.LastName };
                comboBoxAgent.Items.Add(string.Join(" ", item));
            }
        }
        void ShowClients()
        {
            comboBoxClient.Items.Clear();
            foreach (ClientsSet clientSet in Program.wfedb.ClientsSet)
            {
                string[] item = { clientSet.Id.ToString() + ".", clientSet.FirstName, clientSet.MiddleName,
                    clientSet.LastName };
                comboBoxClient.Items.Add(string.Join(" ", item));
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                listViewDemand_Apartment.Visible = true;
                textBoxmaxAtag.Visible = true;
                textBoxminAtag.Visible = true;
                textBoxminKoiK.Visible = true;
                textBoxmaxKolK.Visible = true;
                labelmaxAtag.Visible = true;
                labelminAtag.Visible = true;
                labelminKoiK.Visible = true;
                labelmaxKolK.Visible = true;
                listViewDemand_House.Visible = false;
                listViewDemand_Land.Visible = false;
                textBoxminAtagD.Visible = false;
                textBoxmaxAtagD.Visible = false;
                labelminAtagD.Visible = false;
                labelmaxAtagD.Visible = false;
                textBoxMinPrice.Text = "";
                textBoxMaxPrise.Text = "";
                textBoxMaxPl.Text = "";
                textBoxminPl.Text = "";
                textBoxmaxAtag.Text = "";
                textBoxminAtag.Text = "";
                textBoxmaxKolK.Text = "";
                textBoxminKoiK.Text = "";
            }
            if (comboBoxType.SelectedIndex == 1)
            {
                listViewDemand_House.Visible = true;
                textBoxminAtagD.Visible = true;
                textBoxmaxAtagD.Visible = true;
                labelminAtagD.Visible = true;
                labelmaxAtagD.Visible = true;
                listViewDemand_Apartment.Visible = false;
                listViewDemand_Land.Visible = false;
                textBoxmaxAtag.Visible = false;
                textBoxminAtag.Visible = false;
                textBoxminKoiK.Visible = false;
                textBoxmaxKolK.Visible = false;
                labelmaxAtag.Visible = false;
                labelminAtag.Visible = false;
                labelminKoiK.Visible = false;
                labelmaxKolK.Visible = false;
                textBoxMinPrice.Text = "";
                textBoxMaxPrise.Text = "";
                textBoxMaxPl.Text = "";
                textBoxminPl.Text = "";
                textBoxminAtagD.Text = "";
                textBoxmaxAtagD.Text = "";

            }
            if (comboBoxType.SelectedIndex == 2)
            {
                listViewDemand_Land.Visible = true;
                listViewDemand_Apartment.Visible = false;
                listViewDemand_House.Visible = false;
                textBoxmaxAtag.Visible = false;
                textBoxminAtag.Visible = false;
                textBoxminKoiK.Visible = false;
                textBoxmaxKolK.Visible = false;
                labelmaxAtag.Visible = false;
                labelminAtag.Visible = false;
                labelminKoiK.Visible = false;
                labelmaxKolK.Visible = false;
                textBoxminAtagD.Visible = false;
                textBoxmaxAtagD.Visible = false;
                labelminAtagD.Visible = false;
                labelmaxAtagD.Visible = false;
                textBoxMinPrice.Text = "";
                textBoxMaxPrise.Text = "";
                textBoxMaxPl.Text = "";
                textBoxminPl.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxAgent.SelectedItem != null && comboBoxClient != null && comboBoxType != null)
            {
                DemandSet demand = new DemandSet();
                if (comboBoxAgent != null) { demand.IdAgent = Convert.ToInt32(comboBoxAgent.SelectedItem.ToString().Split('.')[0]); }
                if (comboBoxClient != null) { demand.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]); }
                if (textBoxMaxPrise.Text != "") { demand.MaxPrice = Convert.ToInt64(textBoxMaxPrise.Text); }
                if (textBoxMinPrice.Text != "") { demand.MinPrice = Convert.ToInt64(textBoxMinPrice.Text); }
                if (comboBoxType.SelectedIndex == 0)
                {
                    demand.Type = 0;
                    if (textBoxminAtag.Text != "") { demand.MaxFloor = Convert.ToInt32(textBoxmaxAtag.Text); }
                    if (textBoxminAtag.Text != "") { demand.MinFloor = Convert.ToInt32(textBoxminAtag.Text); }
                    if (textBoxmaxKolK.Text != "") { demand.MaxRooms = Convert.ToInt32(textBoxmaxKolK.Text); }
                    if (textBoxminKoiK.Text != "") { demand.MinRooms = Convert.ToInt32(textBoxminKoiK.Text); }
                    if (textBoxMaxPl.Text != "") { demand.MaxArea = Convert.ToInt64(textBoxMaxPl.Text); }
                    if (textBoxminPl.Text != "") { demand.MinArea = Convert.ToInt64(textBoxminPl.Text); }
                }
                else if (comboBoxType.SelectedIndex == 1)
                {
                    demand.Type = 1;
                    if (textBoxminAtagD.Text != "") { demand.MinFloors = Convert.ToInt32(textBoxminAtagD.Text); }
                    if (textBoxmaxAtagD.Text != "") { demand.MaxFloors = Convert.ToInt32(textBoxminAtagD.Text); }
                    if (textBoxMaxPl.Text != "") { demand.MaxArea = Convert.ToInt64(textBoxMaxPl.Text); }
                    if (textBoxminPl.Text != "") { demand.MinArea = Convert.ToInt64(textBoxminPl.Text); }
                }
                else
                {
                    demand.Type = 2;
                    if (textBoxMaxPl.Text != "") { demand.MaxArea = Convert.ToInt64(textBoxMaxPl.Text); }
                    if (textBoxminPl.Text != "") { demand.MinArea = Convert.ToInt64(textBoxminPl.Text); }
                }
                Program.wfedb.DemandSet.Add(demand);
                Program.wfedb.SaveChanges();
                ShowDemand();

            }
            else MessageBox.Show("Данные не выбраны!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void ShowDemand()
        {
            listViewDemand_Apartment.Items.Clear();
            listViewDemand_House.Items.Clear();
            listViewDemand_Land.Items.Clear();
            foreach (DemandSet demand in Program.wfedb.DemandSet)
            {
                if (demand.Type == 0)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                    demand.IdAgent.ToString(),
                    demand.AgentSet.LastName+" "+demand.AgentSet.FirstName+" "+demand.AgentSet.MiddleName,
                    demand.IdClient.ToString(),
                    demand.ClientsSet.LastName+" "+demand.ClientsSet.FirstName+" "+demand.ClientsSet.MiddleName,
                    demand.Type.ToString(),
                    demand.MinPrice.ToString()+" p.",
                    demand.MaxPrice.ToString()+" p.",
                    demand.MinRooms.ToString(),
                    demand.MaxRooms.ToString(),
                    demand.MinArea.ToString(),
                    demand.MaxArea.ToString(),
                    demand.MinFloor.ToString(),
                    demand.MaxFloor.ToString()
                });
                    item.Tag = demand;
                    listViewDemand_Apartment.Items.Add(item);
                }
                else if (demand.Type == 1)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                         demand.IdAgent.ToString(),
                    demand.AgentSet.LastName+" "+demand.AgentSet.FirstName+" "+demand.AgentSet.MiddleName,
                    demand.IdClient.ToString(),
                    demand.ClientsSet.LastName+" "+demand.ClientsSet.FirstName+" "+demand.ClientsSet.MiddleName,
                    demand.Type.ToString(),
                    demand.MinPrice.ToString()+" p.",
                    demand.MaxPrice.ToString()+" p.",
                    demand.MinFloors.ToString(),
                    demand.MaxFloors.ToString(),
                    demand.MinArea.ToString(),
                    demand.MaxArea.ToString()
                    });
                    item.Tag = demand;
                    listViewDemand_House.Items.Add(item);
                }
                else
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                    demand.IdAgent.ToString(),
                    demand.AgentSet.LastName+" "+demand.AgentSet.FirstName+" "+demand.AgentSet.MiddleName,
                    demand.IdClient.ToString(),
                    demand.ClientsSet.LastName+" "+demand.ClientsSet.FirstName+" "+demand.ClientsSet.MiddleName,
                    demand.Type.ToString(),
                    demand.MinPrice.ToString()+" p.",
                    demand.MaxPrice.ToString()+" p.",
                    demand.MinArea.ToString(),
                    demand.MaxArea.ToString()
                    });
                    item.Tag = demand;
                    listViewDemand_Land.Items.Add(item);
                }
                listViewDemand_Apartment.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listViewDemand_House.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                listViewDemand_Land.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
            {
                if (listViewDemand_Apartment.SelectedItems.Count == 1)
                {
                    DemandSet demand = listViewDemand_Apartment.SelectedItems[0].Tag as DemandSet;
                    demand.IdAgent = Convert.ToInt32(comboBoxAgent.SelectedItem.ToString().Split('.')[0]);
                    demand.IdClient= Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                    demand.MinPrice= Convert.ToInt64(textBoxMinPrice.Text);
                    demand.MaxPrice= Convert.ToInt64(textBoxMaxPrise.Text);
                    demand.MinRooms= Convert.ToInt32(textBoxminKoiK.Text);
                    demand.MaxRooms= Convert.ToInt32(textBoxmaxKolK.Text);
                    demand.MinArea= Convert.ToInt64(textBoxminPl.Text);
                    demand.MaxArea= Convert.ToInt64(textBoxMaxPl.Text);
                    demand.MinFloor= Convert.ToInt32(textBoxminAtag.Text);
                    demand.MaxFloor = Convert.ToInt32(textBoxmaxAtag.Text);
                    Program.wfedb.SaveChanges();
                    ShowDemand();
                }
            }
            else if (comboBoxType.SelectedIndex == 1)
            {
                if (listViewDemand_House.SelectedItems.Count == 1)
                {
                    DemandSet demand =  listViewDemand_House.SelectedItems[0].Tag as DemandSet;
                    demand.IdAgent = Convert.ToInt32(comboBoxAgent.SelectedItem.ToString().Split('.')[0]);
                    demand.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                    demand.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                    demand.MaxPrice = Convert.ToInt64(textBoxMaxPrise.Text);
                    demand.MinArea = Convert.ToInt64(textBoxminPl.Text);
                    demand.MaxArea = Convert.ToInt64(textBoxMaxPl.Text);
                    demand.MinFloors= Convert.ToInt32(textBoxminAtagD.Text);
                    demand.MaxFloors= Convert.ToInt32(textBoxminAtagD.Text);
                }

                Program.wfedb.SaveChanges();
                ShowDemand();
            }
            else
            {
                if (listViewDemand_Land.SelectedItems.Count == 1)
                {
                    DemandSet demand = listViewDemand_Land.SelectedItems[0].Tag as DemandSet;
                    demand.IdAgent = Convert.ToInt32(comboBoxAgent.SelectedItem.ToString().Split('.')[0]);
                    demand.IdClient = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                    demand.MinPrice = Convert.ToInt64(textBoxMinPrice.Text);
                    demand.MaxPrice = Convert.ToInt64(textBoxMaxPrise.Text);
                    demand.MinArea = Convert.ToInt64(textBoxminPl.Text);
                    demand.MaxArea = Convert.ToInt64(textBoxMaxPl.Text);
                    Program.wfedb.SaveChanges();
                    ShowDemand();
                }
            }
        }

        private void listViewDemand_Apartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDemand_Apartment.SelectedItems.Count == 1)
            {
                DemandSet demand = listViewDemand_Apartment.SelectedItems[0].Tag as DemandSet;
                textBoxMinPrice.Text = demand.MinPrice.ToString();
                textBoxMaxPrise.Text = demand.MaxPrice.ToString();
                textBoxMaxPl.Text = demand.MaxArea.ToString();
                textBoxminPl.Text = demand.MinArea.ToString();
                textBoxmaxAtag.Text = demand.MaxFloor.ToString();
                textBoxminAtag.Text = demand.MinFloor.ToString();
                textBoxmaxKolK.Text = demand.MaxRooms.ToString();
                textBoxminKoiK.Text = demand.MaxRooms.ToString();
            }
            else
            {
                textBoxMinPrice.Text = "";
                textBoxMaxPrise.Text = "";
                textBoxMaxPl.Text = "";
                textBoxminPl.Text = "";
                textBoxmaxAtag.Text = "";
                textBoxminAtag.Text = "";
                textBoxmaxKolK.Text = "";
                textBoxminKoiK.Text = "";
            }
        }

        private void listViewDemand_House_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDemand_House.SelectedItems.Count == 1)
            {
                DemandSet demand = listViewDemand_House.SelectedItems[0].Tag as DemandSet;
                textBoxMinPrice.Text = demand.MinPrice.ToString();
                textBoxMaxPrise.Text = demand.MaxPrice.ToString();
                textBoxMaxPl.Text = demand.MaxArea.ToString();
                textBoxminPl.Text = demand.MinArea.ToString();
                textBoxmaxAtagD.Text = demand.MaxFloors.ToString();
                textBoxminAtagD.Text = demand.MinFloors.ToString();
            }
            else
            {
                textBoxMinPrice.Text = "";
                textBoxMaxPrise.Text = "";
                textBoxMaxPl.Text = "";
                textBoxminPl.Text = "";
                textBoxminAtagD.Text = "";
                textBoxmaxAtagD.Text="";
            }
        }

        private void listViewDemand_Land_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDemand_Land.SelectedItems.Count == 1)
            {
                DemandSet demand = listViewDemand_Land.SelectedItems[0].Tag as DemandSet;
                textBoxMinPrice.Text = demand.MinPrice.ToString();
                textBoxMaxPrise.Text = demand.MaxPrice.ToString();
                textBoxMaxPl.Text = demand.MaxArea.ToString();
                textBoxminPl.Text = demand.MinArea.ToString();
            }
            else
            {
                textBoxMinPrice.Text = "";
                textBoxMaxPrise.Text = "";
                textBoxMaxPl.Text = "";
                textBoxminPl.Text = "";
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxType.SelectedIndex == 0)
                {
                    if (listViewDemand_Apartment.SelectedItems.Count == 1)
                    {
                        DemandSet demand = listViewDemand_Apartment.SelectedItems[0].Tag as DemandSet;
                        Program.wfedb.DemandSet.Remove(demand);
                        Program.wfedb.SaveChanges();
                        ShowDemand();
                    }
                    textBoxMinPrice.Text = "";
                    textBoxMaxPrise.Text = "";
                    textBoxMaxPl.Text = "";
                    textBoxminPl.Text = "";
                    textBoxmaxAtag.Text = "";
                    textBoxminAtag.Text = "";
                    textBoxmaxKolK.Text = "";
                    textBoxminKoiK.Text = "";
                }
                else if (comboBoxType.SelectedIndex == 1)
                {
                    if (listViewDemand_House.SelectedItems.Count == 1)
                    {
                        DemandSet demand = listViewDemand_House.SelectedItems[0].Tag as DemandSet;
                        Program.wfedb.DemandSet.Remove(demand);
                        Program.wfedb.SaveChanges();
                        ShowDemand();
                    }
                    textBoxMinPrice.Text = "";
                    textBoxMaxPrise.Text = "";
                    textBoxMaxPl.Text = "";
                    textBoxminPl.Text = "";
                    textBoxminAtagD.Text = "";
                    textBoxmaxAtagD.Text = "";
                }
                else
                {
                    if (listViewDemand_Land.SelectedItems.Count == 1)
                    {
                        DemandSet demand = listViewDemand_Land.SelectedItems[0].Tag as DemandSet;
                        Program.wfedb.DemandSet.Remove(demand);
                        Program.wfedb.SaveChanges();
                        ShowDemand();
                    }
                    textBoxMinPrice.Text = "";
                    textBoxMaxPrise.Text = "";
                    textBoxMaxPl.Text = "";
                    textBoxminPl.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
