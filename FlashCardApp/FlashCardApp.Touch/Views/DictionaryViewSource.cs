﻿
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace FlashCardApp.Touch
{
	public class DictionaryViewSource : UITableViewSource
	{
		public DictionaryViewSource ()
		{
		}

		public override int NumberOfSections (UITableView tableView)
		{
			// TODO: return the actual number of sections
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			// TODO: return the actual number of items in the section
			return 1;
		}

		public override string TitleForHeader (UITableView tableView, int section)
		{
			return "Header";
		}

		public override string TitleForFooter (UITableView tableView, int section)
		{
			return "Footer";
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (DictionaryViewCell.Key) as DictionaryViewCell;
			if (cell == null)
				cell = new DictionaryViewCell ();
			
			// TODO: populate the cell with the appropriate data based on the indexPath
			cell.DetailTextLabel.Text = "DetailsTextLabel";
			
			return cell;
		}
	}
}

