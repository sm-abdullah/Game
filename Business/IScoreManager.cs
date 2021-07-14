using Entites;


namespace Business
{
    public interface IScoreManager
    {
        int ManageScore(ImageDirection direction, Nationality nationality);
        void Reset();
    }
}
