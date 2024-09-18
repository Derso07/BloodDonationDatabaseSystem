using BloodDonationDatabase.Application.Model;
using BloodDonationDatabase.Core.Repository;
using MediatR;

namespace BloodDonationDatabase.Application.Queries.DonorQueries.GetDonorById
{
    public class GetDonorByIdHandler : IRequestHandler<GetDonorByIdQuery, ResultViewModel<DonorViewModel>>
    {
        public GetDonorByIdHandler(IDonorRepository repository)
        {
            _repository = repository;
        }

        private readonly IDonorRepository _repository;

        public async Task<ResultViewModel<DonorViewModel>> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
        {
            var donor = await _repository.GetById(request.Id);

            if (donor is null) return ResultViewModel<DonorViewModel>.Error("Doador não existe");

            var model = DonorViewModel.FromEntity(donor);

            return ResultViewModel<DonorViewModel>.Success(model);
        }
    }
}
