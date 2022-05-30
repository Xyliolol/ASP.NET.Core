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
            _context = context;
        }
        public async Task Action(ScoreModel entity) 
        {
            var score = await _context.Scorees.OrderBy(x => x.ScoreId == entity.ScoreId).LastOrDefaultAsync();
            if (score == null)
            {
                throw new ArgumentException("нет данных", entity.ScoreId.ToString());
            }
            score.Close(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Add()
        {
            var score = new ScoreModel();
            _context.Add(score.Create());
            _context.SaveChangesAsync();
        }

        public async Task Close(ScoreModel entity)
        {
            var score = await _context.Scorees.OrderBy(x => x.ScoreId == entity.ScoreId).LastOrDefaultAsync();
            if (score == null)
            {
                throw new ArgumentException("нет данных", entity.ScoreId.ToString());
            }
            score.Close(entity);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<ScoreModel> Get()
        {
           var score = _context.Scorees.ToList();
            return score;
        }
    }
}
