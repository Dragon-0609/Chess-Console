namespace Chess.Scripts
{
	public class Turn
	{
		public Point Location;
		public UnitOccupation Occupation;
		public bool InfinitiveTurn;
		public bool blockedWay = false;

		public Turn(Point location, bool infinitiveTurn, UnitOccupation occupation)
		{
			Location = location;
			InfinitiveTurn = infinitiveTurn;
			Occupation = occupation;
		}
	}

	public enum UnitOccupation
	{
		Has,
		Doesnt,
		Both
	}
}