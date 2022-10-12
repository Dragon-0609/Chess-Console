using System.Collections.Generic;

namespace Chess.Scripts.Units
{
	public class Rook : Unit
	{

		public Rook (bool isBlack) : base (isBlack)
		{
		}

		public override string Draw () => Correct (IsBlack ? "r" : "t");
		public override Turn[] AvailableTurns()
		{
			List<Turn> turns = new List<Turn>()
			{
				new Turn(new Point(-1, 0), true, UnitOccupation.Both),
				new Turn(new Point(1, 0), true, UnitOccupation.Both),
				new Turn(new Point(0, -1), true, UnitOccupation.Both),
				new Turn(new Point(0, 1), true, UnitOccupation.Both),
			};
			return turns.ToArray();
		}
	}
}