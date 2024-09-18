using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repositories;
using BloodDonationDatabase.Core.Repository;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonorCommand.InsertDonor
{
    public class InsertDonorHandler : IRequestHandler<InsertDonorCommand, ResultViewModel<int>>
    {
        public InsertDonorHandler(IDonorRepository repository, ICepRepository cepRepository)
        {
            _repository = repository;
            _cepRepository = cepRepository;
        }

        private readonly IDonorRepository _repository;
        private readonly ICepRepository _cepRepository;

        
        public async Task<ResultViewModel<int>> Handle(InsertDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = request.ToEntity();

            var adress = await _cepRepository.CheckAddress(request.ZipCode);
            if (adress is null)
            {
                return ResultViewModel<int>.Error("Endereço Incorreto! CEP não encontrado");
            }
            
            await _cepRepository.Insert(adress);
            await _repository.Insert(donor);

            return ResultViewModel<int>.Success(donor.Id);
        }
    }
}
