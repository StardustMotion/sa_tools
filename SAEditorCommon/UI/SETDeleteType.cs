﻿using SonicRetro.SAModel.SAEditorCommon.DataTypes;
using SonicRetro.SAModel.SAEditorCommon.SETEditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SonicRetro.SAModel.SAEditorCommon.UI
{
	public partial class SETDeleteType : Form
	{
		private ushort deleteType = 0;

		public SETDeleteType()
		{
			InitializeComponent();

			foreach (ObjectDefinition item in LevelData.ObjDefs)
				delTypeDropDown.Items.Add(item.Name);

			delTypeDropDown.SelectedIndex = 0;
		}

		private void cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			deleteType = (ushort)delTypeDropDown.SelectedIndex;

			IEnumerable<SETItem> itemsToDelete = LevelData.SETItems(LevelData.Character).Where<SETItem>(item => item.ID == deleteType);
			foreach (SETItem item in itemsToDelete) LevelData.RemoveSETItem(LevelData.Character, item);

			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
