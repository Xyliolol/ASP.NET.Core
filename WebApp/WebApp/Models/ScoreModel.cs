namespace WebApp.Models
{
    public class ScoreModel
    {
        public Guid ScoreId { get;  private set; }
        public DateTime CreateTime { get; private set; }
        public double Score { get; set; }
        public bool IsClose { get; private set; }

        private Guid ScoreIdGenerate()
        {
            return  Guid.NewGuid();
        }
        public ScoreModel Create()
        {
            var score = new ScoreModel();
            score.ScoreId = ScoreIdGenerate();
            score.CreateTime = DateTime.Now;
            score.Score = 0;
            score.IsClose = false;
            return score;
        }
        public ScoreModel IncludeSheets(ScoreModel score)
        {
            var _score = new ScoreModel();
            _score.ScoreId =score.ScoreId;
            _score.CreateTime = DateTime.Now;
            _score.Score += score.Score;
            _score.IsClose = false;
            return _score;
        }
        public ScoreModel Close(ScoreModel score)
        {
            var _score = new ScoreModel();
            _score.ScoreId = score.ScoreId;
            _score.CreateTime = DateTime.Now;
            _score.Score = score.Score;
            _score.IsClose = true;
            return _score;
        }
    }
}
