using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface ICastRepository
{
    Cast GetByID(int id);
}