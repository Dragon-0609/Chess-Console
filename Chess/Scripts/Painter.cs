using System;

namespace Chess.Scripts
{
	public class Painter
	{
		private Board _board;
		private ConsoleColor _defaultColor;
		private ConsoleColor _defaultBackColor;
		private ConsoleColor _selectionColor;
		private ConsoleColor _availableColor;
		private ConsoleColor _atDangerColor;

		
		public Painter(Board board)
		{
			_board = board;
			_defaultColor = Console.ForegroundColor;
			_defaultBackColor = Console.BackgroundColor;
			_availableColor = ConsoleColor.DarkGreen;
			_selectionColor = ConsoleColor.DarkYellow;
			_atDangerColor = ConsoleColor.DarkRed;
		}

		internal void Draw()
		{
			Console.Clear();
			DrawCells();
		}

		private void DrawCells()
		{
			foreach (Cell[] cells in _board.Cells)
			{
				SetPosition(1, cells[0].Coordinate.Y + 1);
				foreach (Cell cell in cells)
				{
					DrawCell(cell);
				}
			}

			SetPosition(_board.CursorPosition.X+1, _board.CursorPosition.Y+1);
		}

		public void DrawCell(Cell cell)
		{
			SetColors(cell);

			if (cell.Unit == null)
				Console.Write(cell.IsBlack ? "€" : "+");
			else
				Console.Write(cell.Unit.Draw());
		}

		private void SetColors(Cell cell)
		{
			if (cell.AtDanger)
			{
				SetDangerColors(cell);
			}else if (cell.IsHighlighted)
			{
				SetHighlightedColors(cell);
			} else if (cell.IsSelected)
			{
				SetSelectedColors(cell);
			}
			else
			{
				SetDefaultColors();
			}
		}

		private void SetDangerColors(Cell cell)
		{
			if (cell.IsBlack)
			{
				Console.BackgroundColor = _atDangerColor;
			}
			else
			{
				Console.ForegroundColor = _atDangerColor;
			}
		}

		private void SetHighlightedColors(Cell cell)
		{
			if (cell.IsBlack)
			{
				Console.BackgroundColor = _availableColor;
			}
			else
			{
				Console.ForegroundColor = _availableColor;
			}
		}

		private void SetSelectedColors(Cell cell)
		{
			if (cell.IsBlack)
			{
				Console.BackgroundColor = _selectionColor;
			}
			else
			{
				Console.ForegroundColor = _selectionColor;
			}
		}

		private void SetDefaultColors()
		{
			Console.BackgroundColor = _defaultBackColor;
			Console.ForegroundColor = _defaultColor;
		}

		public static void SetPosition(int x, int y)
		{
			Console.SetCursorPosition(x, y);
		}
	}
}