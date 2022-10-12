namespace Chess.Scripts
{
	public abstract class Unit
	{
		public bool IsBlack;
		public Cell Position;
		protected Unit (bool isBlack)
		{
			IsBlack = isBlack;
		}

		public abstract string Draw ();
		
		
		protected string Correct (string res)
		{
			if (!Position.IsBlack)
				res = res.ToUpper ();
			return res;
		}

		public abstract Turn[] AvailableTurns();
	}
}