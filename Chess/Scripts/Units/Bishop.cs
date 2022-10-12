using System.Collections.Generic;

namespace Chess.Scripts.Units
{
	public class Bishop : Unit
	{

		public Bishop (bool isBlack) : base (isBlack)
		{
		}

		public override string Draw () => Correct (IsBlack ? "b" : "n");

		public override Turn[] AvailableTurns()
		{
			List<Turn> turns = new List<Turn>()
			{
				new Turn(new Point(-1, -1), true, UnitOccupation.Both),
				new Turn(new Point(1, -1), true, UnitOccupation.Both),
				new Turn(new Point(-1, 1), true, UnitOccupation.Both),
				new Turn(new Point(1, 1), true, UnitOccupation.Both),
			};
			return turns.ToArray();
		}
	}
}