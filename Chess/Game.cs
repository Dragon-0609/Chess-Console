using System;
using Chess.Scripts;

namespace Chess
{
	public class Game
	{
		private Board _board = new Board();

		public Game()
		{
			ConsoleHelper.SetCurrentFont("Chess", 20);
			Console.CursorSize = 1;
			_board.Init();
			bool lp = true;
			Painter.SetPosition(1, 1);
			while (lp)
			{
				ConsoleKey key = Console.ReadKey().Key;
				bool movement = IsMovementKey(key);
				if (movement)
				{
					Point point = _board.CursorPosition;
					MoveCursor(key, point);
					_board.Painter.Draw();
					if (_board.Highlighter.IsInsideBoard(point))
					{
						Painter.SetPosition(point.X + 1, point.Y + 1);
					}
					else
					{
						Point p = _board.Highlighter.GetBorderBoard(point);
						Painter.SetPosition(p.X + 1, p.Y + 1);
					}
				}
				else if (key == ConsoleKey.Spacebar)
				{
					_board.SelectCell(_board.CursorPosition);
				} else if (key == ConsoleKey.Q || key == ConsoleKey.E)
				{
					lp = false;
				}
			}
			Painter.SetPosition(0, 9);
		}

		private void MoveCursor(ConsoleKey key, Point point)
		{
			if (key == ConsoleKey.LeftArrow)
				point.X--;
			else if (key == ConsoleKey.RightArrow)
				point.X++;
			if (key == ConsoleKey.UpArrow)
				point.Y--;
			else if (key == ConsoleKey.DownArrow)
				point.Y++;
		}

		private static bool IsMovementKey(ConsoleKey key)
		{
			return key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow || key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow;
		}
	}
}