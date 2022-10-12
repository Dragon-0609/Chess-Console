using System;
using System.Collections.Generic;
using Chess.Interfaces;
using Chess.Scripts.Units;
namespace Chess.Scripts
{
	public class Board : IBoard
	{
		public Cell [] [] Cells;
		public Dictionary <Point, Unit> DefaultUnits = new Dictionary <Point, Unit> ()
		{
			{ new Point (0, 0), new Rook (true) },
			{ new Point (7, 0), new Rook (true) },
			{ new Point (0, 7), new Rook (false) },
			{ new Point (7, 7), new Rook (false) },
			
			{ new Point (1, 0), new Knight (true) },
			{ new Point (6, 0), new Knight (true) },
			{ new Point (1, 7), new Knight (false) },
			{ new Point (6, 7), new Knight (false) },
			
			{ new Point (2, 0), new Bishop (true) },
			{ new Point (5, 0), new Bishop (true) },
			{ new Point (2, 7), new Bishop (false) },
			{ new Point (5, 7), new Bishop (false) },
			
			{ new Point (3, 0), new Queen (true) },
			{ new Point (3, 7), new Queen (false) },
			
			{ new Point (4, 0), new King (true) },
			{ new Point (4, 7), new King (false) },
			
		};

		internal Cell SelectedCell;
		internal Highlighter Highlighter;
		internal Painter Painter;
		internal Point CursorPosition = new Point(0, 0);
		
		public void Init ()
		{
			Highlighter = new Highlighter(this);
			Painter = new Painter(this);
			AddDefaultPawns ();
			InitCells ();
			Painter.Draw ();
		}

		private void AddDefaultPawns ()
		{
			for (int i = 0; i < 8; i++)
			{
				DefaultUnits.Add (new Point (i, 1), new Pawn (true));
				DefaultUnits.Add (new Point (i, 6), new Pawn (false));
			}
		}

		private void InitCells ()
		{
			Cells = new Cell[8] [];
			bool black = false;			
			
			for (int i = 0; i < Cells.Length; i++)
			{
				Cells [i] = new Cell[8];

				for (int u = 0; u < Cells [i].Length; u++)
				{
					Point coordinate = new Point (u, i);
					Cell cell = new Cell (black, coordinate, this);
					if (DefaultUnits.ContainsKey (coordinate))
						cell.Unit = DefaultUnits [coordinate];
					Cells [i] [u] = cell;
					black = !black;
				}
				black = !black;
			}

		}

		public void SelectCell(Point location)
		{
			if (Highlighter.IsInsideBoard(location))
			{
				bool clear = false;

				Cell cell = GetCell(location);
				if (SelectedCell != null && SelectedCell.IsSelected && cell.IsSelected)
				{
					clear = true;
				}
				else if (SelectedCell?.Unit != null && cell.IsHighlighted && SelectedCell.Unit.IsBlack == Player.IsBlack)
				{
					MoveUnit(location);
					Player.IsBlack = !Player.IsBlack;
				}
				else if (cell.Unit != null && Player.IsBlack == cell.Unit.IsBlack)
				{
					cell.IsSelected = true;
				}
				else
				{
					clear = true;
				}

				if (clear)
					ClearHighlighting();
			}
		}

		public void SetSelection(Cell cell)
		{
			SelectedCell = cell;
			Highlighter.GetHighlightings();
		}

		public void RemoveSelection() => Highlighter.RemoveSelection();

		private void MoveUnit(Point location)
		{
			Unit unit = SelectedCell.Unit;
			Cell cell = GetCell(location);
			SelectedCell.Unit = null;
			cell.Unit = unit;
			ClearHighlighting();
		}

		private void ClearHighlighting()
		{
			Highlighter.RemoveSelection();
			Highlighter.ClearHighlighting();
			Painter.Draw();
		}

		internal Cell GetCell(Point location)
		{
			return Cells[location.Y][location.X];
		}
	}
}