using Chess.Scripts;

namespace Chess.Interfaces
{
	public interface IBoard
	{
		void RemoveSelection();
		void SetSelection(Cell cell);
	}
}