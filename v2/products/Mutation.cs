using Demo.Products;
using HotChocolate;
using HotChocolate.Subscriptions;
using System.Threading.Tasks;

namespace PMAG.DataHUB.NavigationService.GraphQlPOC.Types;

public class Mutation
{
    public async Task<Product> AddProduct(
        Product product,
        [Service] ITopicEventSender eventSender,
        [Service] ProductRepository productRepository)
    {
        var addedProduct = productRepository.AddProduct(product);
        await eventSender.SendAsync(nameof(AddProduct), addedProduct);
        return addedProduct;
    }
}
