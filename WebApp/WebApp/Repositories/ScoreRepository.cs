using Microsoft.EntityFrameworkCore;
using WebApp.Interface;
using WebApp.Models;

namespace WebApp.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly MyDBContext _context;
        public ScoreRepository(MyDBContext context)
        {
            this._context = context;
        }
        public void Action(ScoreModel entity)
        {
            var score =  _context.Scorees.OrderBy(x => x.ScoreId == entity.ScoreId).LastOrDefault();
            if (score == null)
            {
                throw new ArgumentException("нет данных", entity.ScoreId.ToString());
            }
            score.Close(entity);
             _context.SaveChanges();
        }

        public void Add(ScoreModel entity)
        {
            _context.Add(entity.Create());
            _context.SaveChanges();
        }

        public void Close(ScoreModel entity)
        {
            var score = _context.Scorees.OrderBy(x => x.ScoreId == entity.ScoreId).LastOrDefault();
            if (score == null)
            {
                throw new ArgumentException("нет данных", entity.ScoreId.ToString());
            }
            score.Close(entity);
            _context.SaveChanges();
        }

        public IEnumerable<ScoreModel> Get()
        {
           var score = _context.Scorees.ToList();
            return score;
        }
    }
}
