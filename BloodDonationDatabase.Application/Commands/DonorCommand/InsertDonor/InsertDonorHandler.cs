using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repository;
using MediatR;

namespace BloodDonationDatabase.Application.Commands.DonorCommand.InsertDonor
{
    public class InsertDonorHandler : IRequestHandler<InsertDonorCommand, ResultViewModel<int>>
    {
        public InsertDonorHandler(IDonorRepository repository)
        {
            _repository = repository;
        }

        private readonly IDonorRepository _repository;

        
        public async Task<ResultViewModel<int>> Handle(InsertDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = request.ToEntity();

            await _repository.Insert(donor);

            return ResultViewModel<int>.Success(donor.Id);
        }
    }
}
