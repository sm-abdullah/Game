
using Entites;

namespace Business
{
    public class ScoreManager : IScoreManager
    {
        private int _currentScore = 0;
        private const int _positiveScore = 20;
        private const int _negativeScore= 5;
        public void Reset() 
        {
            _currentScore = 0;
        }
        public int ManageScore(ImageDirection direction, Nationality nationality) 
        {
            if ((direction == ImageDirection.LeftBottom && nationality == Nationality.Korean) ||
                     (direction == ImageDirection.LeftTop && nationality == Nationality.Japnaies) ||
                     (direction == ImageDirection.RightTop && nationality == Nationality.Chines) ||
                      (direction == ImageDirection.RightBottom && nationality == Nationality.Thai)
                    )
            {
                this._currentScore += _positiveScore;
            }
            else if (direction != ImageDirection.TopBottom)
            {
                this._currentScore -= _negativeScore;
            }
            return _currentScore;
        }
    }
}
