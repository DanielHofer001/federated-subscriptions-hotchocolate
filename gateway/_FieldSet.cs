using HotChocolate.Types;

namespace Demo.Gateway;
public class _FieldSet : DirectiveType
{
    protected override void Configure(IDirectiveTypeDescriptor descriptor)
    {
        descriptor.Name("_FieldSet");
        descriptor.Location(DirectiveLocation.Field);
    }
}
