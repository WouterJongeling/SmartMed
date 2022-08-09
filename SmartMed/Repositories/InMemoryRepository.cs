using AutoMapper;
using SmartMed.Dbo;
using SmartMed.Models;

namespace SmartMed.Repositories
{
    public class InMemoryRepository<TModel, TDbo> : IRepository<TModel> where TModel : ModelBase where TDbo : DboBase
    {
        private readonly IMapper _mapper;
        private readonly List<TDbo> _list;

        public InMemoryRepository(IMapper mapper)
        {
            _mapper = mapper;
            _list = new List<TDbo>();
        }

        public TModel Add(TModel entity)
        {
            TDbo dbo = _mapper.Map<TDbo>(entity);
            dbo.Id = Guid.NewGuid();
            dbo.CreationDate = DateTime.Now;
            _list.Add(dbo);
            TModel newEntity = _mapper.Map<TModel>(dbo);
            return newEntity;
        }

        public void Delete(Guid entityId)
        {
            TDbo? dbo = _list.SingleOrDefault(x => x.Id == entityId);
            if (dbo is null)
            {
                return;
            }
            _list.Remove(dbo);
        }

        public ICollection<TModel> GetAll()
        {
            return new List<TModel>(_list.Select(dbo => _mapper.Map<TModel>(dbo)));
        }

        public TModel? GetById(Guid entityId)
        {
            TDbo? dbo = _list.SingleOrDefault(x => x.Id == entityId);
            if(dbo is null)
            {
                return null;
            }
            return _mapper.Map<TModel>(dbo);
        }
    }
}
