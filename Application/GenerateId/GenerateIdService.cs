using Domain.Interfaces.Id;

namespace Application.GenerateId
{
    public class GenerateIdService : IGenerateIdUseCase
    {
        public string GenerateGuId()
        {
            return new Guid().ToString();
        }
    }
}
