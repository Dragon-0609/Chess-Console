using System;
using System.Collections.Generic;

namespace Chess.Scripts
{
	public class Highlighter
	{
		private Board _board;
		internal Cell[] _highlightedCells;

		public Highlighter(Board board)
		{
			_board = board;
		}

		internal void GetHighlightings()
		{
			ClearHighlighting();
			if (_board.SelectedCell.Unit != null)
			{
				Turn[] availableTurns = _board.SelectedCell.Unit.AvailableTurns();
				_highlightedCells = GetAvailableCells(availableTurns);
				_board.Painter.Draw();	
			}
		}

		public void ClearHighlighting()
		{
			if (_highlightedCells != null)
			{
				foreach (Cell cell in _highlightedCells)
				{
					cell.IsHighlighted = false;
					if (cell.AtDanger)
						cell.AtDanger = false;
				}
			}
		}

		private Cell[] GetAvailableCells(Turn[] turns)
		{
			List<Cell> cells = new List<Cell>();

			foreach (Turn turn in turns)
			{
				AddCell(turn, _board.SelectedCell.Coordinate, cells);
			}
			
			return cells.ToArray();
		}

		private void AddCell(Turn turn, Point location, List<Cell> cells)
		{
			if (IsInsideBoard(location + turn.Location))
			{
				Point turnLocation = location + turn.Location;

				Cell cell = _board.GetCell(turnLocation);
				if (CheckOccupation(turn, cell))
				{
					if (_board.GetCell(_board.SelectedCell.Coordinate).Unit != null && cell.Unit != null && !turn.blockedWay)
					{
						turn.blockedWay = true;
						cell.AtDanger = true;
					}
					
					cell.IsHighlighted = true;
					cells.Add(cell);
					if (turn.InfinitiveTurn)
						AddCell(turn, turnLocation, cells);
				}
			}
		}

		private bool CheckOccupation(Turn turn, Cell cell)
		{
			if (turn.blockedWay)
				return false;
			if (_board.GetCell(_board.SelectedCell.Coordinate).Unit != null && cell.Unit != null)
			{
				Unit unit = _board.GetCell(_board.SelectedCell.Coordinate).Unit;
				if (unit.IsBlack == cell.Unit.IsBlack)
					return false;
			}
			
			if (turn.Occupation == UnitOccupation.Doesnt)
			{
				return cell.Unit == null;
			}

			if (turn.Occupation == UnitOccupation.Has)
			{
				return cell.Unit != null;
			}
			return true;
		}

		public bool IsInsideBoard(Point location)
		{
			bool inside = location.X >= 0 && location.X <= 7 && location.Y >= 0 && location.Y <= 7;

			return inside;
		}

		public Point GetBorderBoard(Point location)
		{
			if (location.X < 0)
				location.X = 0;
			else if (location.X > 7)
				location.X = 7;
			if (location.Y < 0)
				location.Y = 0;
			else if (location.Y > 7)
				location.Y = 7;
			return location;
		}

		public void RemoveSelection()
		{
			if (_board.SelectedCell != null)
			{
				_board.SelectedCell.IsSelected = false;
				_board.SelectedCell = null;
			}

			if (_highlightedCells != null)
			{
				foreach (Cell highlightedCell in _highlightedCells)
				{
					highlightedCell.IsHighlighted = false;
				}
			}
		}
		
	}
}