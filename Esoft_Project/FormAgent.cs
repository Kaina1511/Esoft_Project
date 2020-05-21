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
    public partial class FormAgent : Form
    {
        public FormAgent()
        {
            InitializeComponent();
            ShowAgent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AgentSet agentSet = new AgentSet();
                agentSet.FirstName = textBoxFirstName.Text;
                agentSet.MiddleName = textBoxMiddleName.Text;
                agentSet.LastName = textBoxLastName.Text;
                agentSet.DealShare = Convert.ToInt32(textBoxDealShare.Text);
                if (agentSet.FirstName == "")
                {
                    throw new Exception("Поле ИМЯ не заполнено!");
                }
                if (agentSet.LastName == "")
                {
                    throw new Exception("Поле ФАМИЛИЯ не заполнено!");
                }
                if (agentSet.MiddleName == "")
                {
                    throw new Exception("Поле ОТЧЕСТВО не заполнено!");
                }
                if (agentSet.DealShare < 0)
                {
                    throw new Exception("Поле ДОЛЯ ОТ ПРОЦЕНТА может принимать значение от 0 до 100!");
                }
                if (agentSet.DealShare > 100)
                {
                    throw new Exception("Поле ДОЛЯ ОТ ПРОЦЕНТА может принимать значение от 0 до 100!");
                }
                Program.wfedb.AgentSet.Add(agentSet);
                Program.wfedb.SaveChanges();
                ShowAgent();
            }
            catch 
            {
                MessageBox.Show("Убедитесь, что все поля заполненны правильно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ShowAgent()
        {
            listViewAgent.Items.Clear();
            foreach (AgentSet agentSet in Program.wfedb.AgentSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                  {
                      agentSet.Id.ToString(),
                      agentSet.FirstName,
                      agentSet.MiddleName,
                      agentSet.LastName,
                      agentSet.DealShare.ToString()
                  });
                item.Tag = agentSet;
                listViewAgent.Items.Add(item);
            }
            listViewAgent.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void listViewAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAgent.SelectedItems.Count == 1)
            {
                AgentSet agentSet = listViewAgent.SelectedItems[0].Tag as AgentSet;
                agentSet.MiddleName = textBoxMiddleName.Text;
                agentSet.FirstName = textBoxFirstName.Text;
                agentSet.LastName = textBoxLastName.Text;
                agentSet.DealShare = Convert.ToInt32(textBoxDealShare.Text);
            }
            else
            {
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxDealShare.Text = "";
            }
        }

        private void buttonEditt_Click(object sender, EventArgs e)
        {
            {
                if (listViewAgent.SelectedItems.Count == 1)
                {
                    AgentSet agentSet = listViewAgent.SelectedItems[0].Tag as AgentSet;
                    agentSet.FirstName = textBoxFirstName.Text;
                    agentSet.MiddleName = textBoxMiddleName.Text;
                    agentSet.LastName = textBoxLastName.Text;
                    agentSet.DealShare = Convert.ToInt32(textBoxDealShare.Text);
                    Program.wfedb.SaveChanges();
                    ShowAgent();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
                try
                {
                    if (listViewAgent.SelectedItems.Count == 1)
                    {
                        AgentSet agentSet = listViewAgent.SelectedItems[0].Tag as AgentSet;
                        Program.wfedb.AgentSet.Remove(agentSet);
                        Program.wfedb.SaveChanges();
                        ShowAgent();
                    }
                    textBoxFirstName.Text = "";
                    textBoxMiddleName.Text = "";
                    textBoxLastName.Text = "";
                    textBoxDealShare.Text = "";
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить, эта запись используется!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
    }
}
