using Chess.Interfaces;

namespace Chess.Scripts
{
	public class Cell
	{
		private bool _isSelected;
		public bool  IsBlack;
		public bool IsHighlighted;
		public bool AtDanger;
		private Unit  _unit;
		public Point Coordinate;
		public IBoard Board;

		public Cell (Point coordinate, IBoard board)
		{
			Coordinate = coordinate;
			Board = board;
		}

		public Cell (bool black, Point coordinate, IBoard board)
		{
			IsBlack = black;
			Coordinate = coordinate;
			Board = board;
		}

		public Unit Unit
		{
			get
			{
				return _unit;
			}
			set
			{
				_unit = value;
				if (_unit != null)
					_unit.Position = this;
			}
		}

		public bool IsSelected
		{
			get => _isSelected;
			set
			{
				_isSelected = value;
				if (value)
				{
					Board.RemoveSelection();
					Board.SetSelection(this);
				}
			}
		}
	}
}