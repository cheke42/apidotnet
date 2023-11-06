using MagicVilla_API.Datos;
using MagicVilla_API.Models;
using MagicVilla_API.Repository.IRepository;

namespace MagicVilla_API.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaNumberRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public async Task<VillaNumber> Update(VillaNumber entity)
        {
            entity.UpdateDate = DateTime.Now;
            _db.VillasNumber.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
