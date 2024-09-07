using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repository;
using MediatR;
using System.Collections.Generic;

namespace BloodDonationDatabase.Application.Queries.DonorQueries.GetAllDonor
{
    public class GetAllDonorHandler : IRequestHandler<GetAllDonorQuery, ResultViewModel<List<DonorViewModel>>>
    {
        public GetAllDonorHandler(IDonorRepository repository)
        {
            _repository = repository;
        }

        private readonly IDonorRepository _repository;

        public async Task<ResultViewModel<List<DonorViewModel>>> Handle(GetAllDonorQuery request, CancellationToken cancellationToken)
        {
            var donors = await _repository.GetAll();

            var model = donors.Select(DonorViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonorViewModel>>.Success(model);
        }
    }
}
