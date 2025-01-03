﻿using Domain.Models;
using Infrastructure.Persistence.Entities.Log;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IBaseMapper<M, E> where M : BaseModel where E : PersonEntity
    {
        M ConvertToModel(E entity);
        E ConvertToEntity(M Model);
    }
}
