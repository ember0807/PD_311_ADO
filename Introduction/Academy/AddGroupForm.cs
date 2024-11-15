﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{
	public partial class AddGroupForm : Form
	{
		public AddGroupForm()
		{
			InitializeComponent();
			comboBoxLearningForm.Items.AddRange(Connector.SelectColumn("form_name", "LearningForms").ToArray());
			comboBoxGroupDirection.Items.AddRange(Connector.SelectColumn("direction_name", "Directions").ToArray());
			SetWeekDays(96);
		}
		public byte GetWeekDays()
		{
			byte days = 0;
			byte day = 1;
			for (byte i = 0; i < checkedListBoxGroupDays.Items.Count; i++)
			{
				//Console.Write(checkedListBoxGroupDays.GetItemCheckState(i) + "\t");
				Console.Write(checkedListBoxGroupDays.GetItemChecked(i) + "\t");
				if (checkedListBoxGroupDays.GetItemChecked(i)) days |= (byte)(day << i); //checkedListBoxGroupDays.GetItemChecked(i);
																						 //day <<= 1;
			}

			Console.WriteLine(days);
			return days;
		}
		public void SetWeekDays(byte days)
		{
			for (byte i = 0; i < checkedListBoxGroupDays.Items.Count; i++)
				checkedListBoxGroupDays.SetItemChecked(i, (days & (1 << i)) != 0);
		}
		private void buttonSaveGroup_Click(object sender, EventArgs e)
		{
			byte days = GetWeekDays();
		}
	}
}