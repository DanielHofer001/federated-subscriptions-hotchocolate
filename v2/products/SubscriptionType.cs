using Demo.Products;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace PMAG.DataHUB.NavigationService.GraphQlPOC.Types;
public class SubscriptionType : ObjectType
{
    protected override void Configure(IObjectTypeDescriptor descriptor) => descriptor
        .Field(nameof(Mutation.AddProduct))
        .Type<ProductType>()
        .Resolve(context => context.GetEventMessage<Product>())
        .Subscribe(async context =>
        {
            var receiver = context.Service<ITopicEventReceiver>();

            ISourceStream stream =
                await receiver.SubscribeAsync<string, Product>(nameof(Mutation.AddProduct));

            return stream;
        });
}
