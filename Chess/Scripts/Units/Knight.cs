using System.Collections.Generic;

namespace Chess.Scripts.Units
{
	public class Knight : Unit
	{

		public Knight (bool isBlack) : base (isBlack)
		{
		}

		public override string Draw () => Correct (IsBlack ? "h" : "j");
		public override Turn[] AvailableTurns()
		{
			List<Turn> turns = new List<Turn>()
			{
				new Turn(new Point(-1, -2), false, UnitOccupation.Both),
				new Turn(new Point(1, -2), false, UnitOccupation.Both),
				new Turn(new Point(2, 1), false, UnitOccupation.Both),
				new Turn(new Point(2, -1), false, UnitOccupation.Both),
				new Turn(new Point(-2, 1), false, UnitOccupation.Both),
				new Turn(new Point(-2, -1), false, UnitOccupation.Both),
				new Turn(new Point(-1, 2), false, UnitOccupation.Both),
				new Turn(new Point(1, 2), false, UnitOccupation.Both),
			};
			return turns.ToArray();
		}
	}
}