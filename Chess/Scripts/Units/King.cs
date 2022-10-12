using System.Collections.Generic;

namespace Chess.Scripts.Units
{
	public class King : Unit
	{

		public King (bool isBlack) : base (isBlack)
		{
		}

		public override string Draw () => Correct (IsBlack ? "k" : "l");
		public override Turn[] AvailableTurns()
		{
			List<Turn> turns = new List<Turn>()
			{
				new Turn(new Point(-1, -1), false, UnitOccupation.Both),
				new Turn(new Point(1, -1), false, UnitOccupation.Both),
				new Turn(new Point(-1, 1), false, UnitOccupation.Both),
				new Turn(new Point(1, 1), false, UnitOccupation.Both),
				
				new Turn(new Point(-1, 0), false, UnitOccupation.Both),
				new Turn(new Point(1, 0), false, UnitOccupation.Both),
				new Turn(new Point(0, -1), false, UnitOccupation.Both),
				new Turn(new Point(0, 1), false, UnitOccupation.Both),
			};
			return turns.ToArray();
		}
	}
}