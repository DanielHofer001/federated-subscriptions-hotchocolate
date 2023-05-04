using HotChocolate.Types;

namespace Demo.Products;

public class ProductType : ObjectType<Product>
{
    protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
    {
        descriptor
            .Field(f => f.Name)
            .Type<StringType>();

        descriptor
            .Field(f => f.Weight)
            .Type<IntType>();

        descriptor
            .Field(f => f.Price)
            .Type<IntType>();

        descriptor
            .Field(f => f.Upc)
            .Type<DecimalType>();
    }
}
