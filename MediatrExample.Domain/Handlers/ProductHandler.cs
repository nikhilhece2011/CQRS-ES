using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatrExample.Domain.Interfaces;
using MediatrExample.Domain.Models;

namespace MediatrExample.Domain.Handlers
{
    public class ProductHandler : IRequestHandler<Product, Response>
    {
        private readonly IMediator _mediatr;
        private readonly IProductRepository _productRepository;

        public ProductHandler(IMediator mediatr, IProductRepository productRepository)
        {
            _mediatr = mediatr;
            _productRepository = productRepository;
        }

        public async Task<Response> Handle(Product request, CancellationToken cancellationToken)
        {
            //Salvo o produto no repositório.
            _productRepository.Save(request);

            return new Response(new { message = "Produto inserido com sucessio." });
        }
    }
}
