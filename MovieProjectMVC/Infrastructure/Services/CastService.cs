using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class CastService : ICastService
{
    private readonly ICastRepository _repository;
    public CastService(ICastRepository repository)
    {
        _repository = repository;
    }
    public Cast GetCastDetails(int id)
    {
        return _repository.GetByID(id);
    }
}