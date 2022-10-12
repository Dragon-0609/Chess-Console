using System.Collections.Generic;

namespace Chess.Scripts.Units
{
	public class Pawn : Unit
	{

		public Pawn (bool isBlack) : base (isBlack)
		{
		}

		public override string Draw () => Correct (IsBlack ? "p" : "o");

		public override Turn[] AvailableTurns()
		{
			List<Turn> turns = new List<Turn>()
			{
				new Turn(IsBlack ? new Point(0, 1) : new Point(0, -1), false, UnitOccupation.Doesnt),
				new Turn(IsBlack ? new Point(-1, 1) : new Point(-1, -1), false, UnitOccupation.Has),
				new Turn(IsBlack ? new Point(1, 1) : new Point(1, -1), false, UnitOccupation.Has),
			};
			return turns.ToArray();
		}
	}
}